terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=2.46.0"
    }
  }
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
}

data "azurerm_resource_group" "resource" {
  name = var.resource_group_name
}

data "azurerm_ssh_public_key" "ssh"{
    name = var.ssh_key_name
    resource_group_name = data.azurerm_resource_group.resource.name
}

data "template_file" "deploy" {
  template = "${file("deploy.tpl")}"
  vars = {
    postgres_password = "${var.postgres_password}"
  }
}

# Create a virtual network within the resource group
resource "azurerm_virtual_network" "shelter_network" {
  name                = "shelter-network"
  resource_group_name = data.azurerm_resource_group.resource.name
  location            = data.azurerm_resource_group.resource.location
  address_space       = ["10.0.0.0/16"]
}

resource "azurerm_subnet" "shelter_network_subnet" {
  name                 = "internal"
  resource_group_name  = data.azurerm_resource_group.resource.name
  virtual_network_name = azurerm_virtual_network.shelter_network.name
  address_prefixes     = ["10.0.2.0/24"]
}

resource "azurerm_public_ip" "shelter_ip" {
  name                = "ShelterIP"
  location            = data.azurerm_resource_group.resource.location
  resource_group_name = data.azurerm_resource_group.resource.name
  allocation_method   = "Static"
}

resource "azurerm_network_interface" "shelter_network_interface" {
  name                = "shelter-nic"
  location            = data.azurerm_resource_group.resource.location
  resource_group_name = data.azurerm_resource_group.resource.name

  ip_configuration {
    name                          = "internal"
    subnet_id                     = azurerm_subnet.shelter_network_subnet.id
    private_ip_address_allocation = "Dynamic"
    public_ip_address_id = azurerm_public_ip.shelter_ip.id
  }
}

resource "azurerm_dns_zone" "shelter_dns" {
  name                = "animal-shelter.ga"
  resource_group_name = data.azurerm_resource_group.resource.name
}

resource "azurerm_dns_a_record" "shelter" {
  name                = "@"
  zone_name           = azurerm_dns_zone.shelter_dns.name
  resource_group_name = data.azurerm_resource_group.resource.name
  ttl                 = 300
  target_resource_id  = azurerm_public_ip.shelter_ip.id
}

resource "azurerm_virtual_machine" "shelter_machine" {
  name                = "shelter-machine"
  resource_group_name = data.azurerm_resource_group.resource.name
  location            = data.azurerm_resource_group.resource.location
  vm_size             = "Standard_B1ms"
  network_interface_ids = [
    azurerm_network_interface.shelter_network_interface.id,
  ]
  delete_data_disks_on_termination = true
  delete_os_disk_on_termination = true

  os_profile  {
    computer_name  = "shelter"
    admin_username = "adminuser"
    custom_data    = base64encode(data.template_file.deploy.rendered)
  }

  os_profile_linux_config {
    disable_password_authentication = true
    ssh_keys {
      path     = "/home/adminuser/.ssh/authorized_keys"
      key_data = replace(data.azurerm_ssh_public_key.ssh.public_key, "\r\n", "")
    }
  }

  storage_os_disk {
    name              = "myosdisk1"
    caching           = "ReadWrite"
    create_option     = "FromImage"
    managed_disk_type = "StandardSSD_LRS"
  }

  storage_image_reference {
    publisher = "OpenLogic"
    offer     = "CentOS"
    sku       = "8_3"
    version   = "latest"
  }
}

output "public_ip_address" {
  value = azurerm_public_ip.shelter_ip.ip_address
  description = "The public IP address of the main server instance."
}

output "dns_nameserveses" {
  value = azurerm_dns_zone.shelter_dns.name_servers
  description = "The nameserversese of the DNS Zone."
}

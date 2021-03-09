variable "hcloud_token" {}
variable "postgres_password" {
  type        = string
  description = "Password for Shelter Database."
}
variable "ssh_key_name" {
  type        = string
  description = "Ssh key name from the Hetzner account."
}

data "hcloud_ssh_key" "ssh_key" {
  name = var.ssh_key_name
}

data "template_file" "deploy" {
  template = "${file("deploy.tpl")}"
  vars = {
    postgres_password = "${var.postgres_password}"
  }
}

terraform {
  required_providers {
    hcloud = {
      source = "hetznercloud/hcloud"
      version = "1.24.1"
    }
  }
}

provider "hcloud" {
  token = var.hcloud_token
}

resource "hcloud_server" "node1" {
  name = "node1"
  image = "centos-8"
  server_type = "cx11"
  location = "hel1"
  ssh_keys = [ data.hcloud_ssh_key.ssh_key.id ]
  user_data = "${data.template_file.deploy.rendered}"
}

output "server_ip" {
  value = hcloud_server.node1.ipv4_address
}
variable "postgres_password" {
  type        = string
  description = "Password for Shelter Database."
}

variable "resource_group_name" {
  type        = string
  description = "An exsiting azure resource group in the account."
  default = "shelter-app"
}

variable "ssh_key_name" {
  type        = string
  description = "Ssh key name from the Azure account."
  default = "shelter-app"
}

variable "dns_address" {
  type        = string
  description = "DNS address of the application."
  default = "animal-shelter.ga"
}

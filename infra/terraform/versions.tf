terraform {
  required_version = ">=1.3.9"
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "3.46.0"
    }

    azuread = {
      source  = "hashicorp/azuread"
      version = "2.36.0"
    }

    random = {
      source  = "hashicorp/random"
      version = "3.4.3"
    }
  }

  backend "azurerm" {
    resource_group_name  = "tf-storage-rg"
    storage_account_name = "tfstorageahmedavid"
    container_name       = "tfstates"
    key                  = "terraform.tfstate"
  }
}

provider "azurerm" {
  features {
      resource_group {
       prevent_deletion_if_contains_resources = false
     }
  }
}

resource "random_pet" "aksrandom" {

}

resource "azuread_group" "aks_administrators" {
  display_name     = "${azurerm_resource_group.aks_rg.name}-cluster-administrators"
  security_enabled = true
  mail_enabled     = false
}


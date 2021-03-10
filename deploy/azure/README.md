# Microsoft Azure Deployment

This project can be deployed on Azure with terraform.

## Prescriptions
Before applying one of the solutions an Azure Account have to be created.

To be able to use terraform functional with Azure Cloud, download and install Azure cli from [official web-site](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli).

In cmd run command ```az login``` and login in your Azure Account.

To see more details about installation - open the folder with a solution you need.

## Existing solutions
### Simple

The simpliest and unscalable cloud architecture with 1 VM, network configuration and DNS zone. 

### Three layer architecture (developing...)

Highly scalable and flexible architecture with separated front-end, back-end and Database resources.
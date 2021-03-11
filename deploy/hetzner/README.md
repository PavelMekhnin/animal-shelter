# Hetzner Deployment

This project can be deployed on Hetzner with terraform.

This terraform solution will be deployed on one VM without any additional services.

DNS configuration have to be set by yourself in your domain provider.

## Prescriptions

Before applying one of the solutions an Hetzner have to be created. Use [link](https://accounts.hetzner.com/login) to create it.

To be able to use terraform functional with Hetzner, generate API Key in your Hetzner Account and save it in secured place on your PC (DO NOT COMMINT IT IN ANY REPOSITORY).

Download and install Terraform on your work pc from [official web-site](https://www.terraform.io/downloads.html).

Generate a SSH key and add it to the Hetzner account.

## Deployment Steps

1) Open this folder in cmd or PowerShell

2) Run command ```terraform init```

3) Run command ```terraform apply```

4) Terraform will ask you to type several input variables:

    *the API Key which you have created before

    *password to PostgreSQL
    
    *the SSH key which you have generated before;

5) After terraform finish deployment you will see a public IP of VM with the application, which could be connected with your SSH Key

6) Approximately in 5-10 minutes the application will be available through the IP

7) And now you are a happy owner of own shelter web-site!
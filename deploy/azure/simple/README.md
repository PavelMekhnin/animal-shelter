# Microsoft Azure Deployment - Simple Solution

## Prescriptions

1) In Azure Account create a source group

2) Generate and add a new SSH in Azure Account

## Deployment Steps

1) Open this folder in cmd or PowerShell

2) Run command 
```sh
terraform init
```

3) Before running terraform deployment - variables should be modified in the file ```/variables.tf```. Raplace names of a source group and a ssh key with one's created before. Also change DNS address on your own.

4) Run command 
```sh
terraform apply
```

5) Terraform will ask you to type a password for PostgreSQL Database

6) After terraform finish deployment you will see a public IP of VM with the application, which could be connected with your SSH Key

7) Also terraform will print list of the nameservers which have to be copied in the particular field in your DNS account

8) Approximately in 5-10 minutes the application will be available through your DNS address or the public IP

9) And now you are a happy owner of own shelter web-site!
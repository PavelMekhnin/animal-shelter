#!/bin/bash
set -e
echo "---Sheter App Deployment---"
echo "Creating a deployment derictory ..."
cd /home
if [ -d apps ] 
then
    rm -r apps
fi
mkdir apps
cd apps
echo "The deployment derictory home/apps has been created"

echo "Installing git ..."
    dnf install git -y

echo "Cloning the application's source code from GitHub ..."
git clone https://github.com/PavelMekhnin/animal-shelter.git
echo "The source code has been cloned"

echo "Updating OS ..."
dnf update -y

echo "Installing docker ..."
dnf config-manager --add-repo https://download.docker.com/linux/centos/docker-ce.repo
dnf update -y
dnf install docker-ce --nobest -y

systemctl start docker
sudo systemctl enable --now docker
echo "Docker has been installed successfully"

curl -L "https://github.com/docker/compose/releases/download/1.28.4/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose
chmod +x /usr/local/bin/docker-compose

echo "Starting the application with docker-compose ..."
cd animal-shelter

export POSTGRES_PASSWORD=${postgres_password}
docker-compose up
echo "The application has been started"
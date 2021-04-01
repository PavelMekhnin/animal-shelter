FROM node:14-alpine

WORKDIR /app

ENV PATH /app/node_modules/.bin:$PATH

COPY package.json ./
COPY package-lock.json ./
RUN npm install npm@latest
RUN npm install --silent

COPY . ./

# start app
CMD ["npm", "start"]
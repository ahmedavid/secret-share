# base image
FROM node:16.15.0 as build

# set working directory
WORKDIR /app

# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH

# install and cache app dependencies
COPY package.json /app/package.json
RUN npm install
RUN npm install -g @angular/cli@14.0.7

# add app
COPY . /app

# generate build
RUN npm run start

# production environment
# FROM nginx:1.16.0-alpine
# COPY --from=build /app/dist/your-project-name /usr/share/nginx/html
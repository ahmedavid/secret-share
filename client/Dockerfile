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
# RUN ng build --prod
EXPOSE 4200
ENTRYPOINT ["ng", "serve" "-host=0.0.0.0" "--port=4200" "--disable-host-check"]

# production environment
# FROM nginx:1.16.0-alpine
# COPY --from=build /app/dist/client /usr/share/nginx/html
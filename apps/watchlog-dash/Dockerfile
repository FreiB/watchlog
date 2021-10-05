
FROM node:latest as build

EXPOSE 4200

# Set the working directory
WORKDIR /usr/local/app

# Add the source code to app
COPY ./ /usr/local/app/

RUN npm install -g nx

# Install all the dependencies
RUN npm install

# Generate the build of the application
# RUN nx serve watchlog-dash

ENTRYPOINT [ "nx", "serve", "watchlog-dash" ]



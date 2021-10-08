# Stage 1: Compile and Build angular codebase

# Use official node image as the base image
FROM node:latest as build

# Set the working directory
WORKDIR /usr/local/app

# Add the source code to app
COPY ./ /usr/local/app/

#RUN npm uninstall @nx-dotnet/core --save

#RUN sed -i '/\"prepare\"/,/"/ d; /^$/d' package.json
#RUN sed -i '/\"prepare\": \"/,/"/ d; /^$/d' package.json

#RUN cat package.json

RUN apt-get --assume-yes update && apt-get --assume-yes install jq

RUN jq 'del(.scripts.prepare)' package.json > _.json && mv _.json package.json

# RUN jq -r 'del(.["nx-dotnet"])' package.json > _.json && mv _.json package.json

# Install all the dependencies
RUN npm install

# Generate the build of the application
RUN npx nx build watchlog-dash


# Stage 2: Serve app with nginx server

# Use official nginx image as the base image
FROM nginx:latest

COPY --from=build /usr/local/app/nginx/nginx.conf.template /etc/nginx/templates/nginx.conf.template

# Copy the build output to replace the default nginx contents.
COPY --from=build /usr/local/app/dist/apps/watchlog-dash /usr/share/nginx/html

# Expose port 80
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . ./
# Node config
ENV NODE_VERSION=22
ENV NVM_DIR=/root/.nvm
# Node install
RUN apt install -y curl
RUN curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.39.0/install.sh | bash
RUN . "$NVM_DIR/nvm.sh" && nvm install ${NODE_VERSION}
RUN . "$NVM_DIR/nvm.sh" && nvm use v${NODE_VERSION}
RUN . "$NVM_DIR/nvm.sh" && nvm alias default v${NODE_VERSION}
RUN bash -ic "dotnet publish -c Release -o output"

FROM nginx:alpine
WORKDIR /data/www
COPY --from=build /app/output/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf

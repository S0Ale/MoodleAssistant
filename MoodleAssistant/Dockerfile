FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Restore
COPY ["MoodleAssistant.csproj", "package.json", "package-lock.json", "./"]
RUN dotnet restore "./MoodleAssistant.csproj"

# Node config
ENV NODE_VERSION=22
ENV NVM_DIR=/root/.nvm

# Copy and publish
COPY . .
WORKDIR /source/.
# Node install
RUN apt install -y curl
RUN curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.39.0/install.sh | bash
RUN . "$NVM_DIR/nvm.sh" && nvm install ${NODE_VERSION}
RUN . "$NVM_DIR/nvm.sh" && nvm use v${NODE_VERSION}
RUN . "$NVM_DIR/nvm.sh" && nvm alias default v${NODE_VERSION}
RUN bash -ic 'dotnet publish "./MoodleAssistant.csproj" -c Release -o /app --no-restore'

# Final - image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "MoodleAssistant.dll"]

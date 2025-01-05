FROM node:latest AS node-base
RUN echo "NODE Version:" && node --version
RUN echo "NPM Version:" && npm --version

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY ["MoodleAssistant.csproj", "package.json", "package-lock.json", "./"]
RUN dotnet restore "./MoodleAssistant.csproj"

COPY . .
WORKDIR /source/.
COPY --from=node-base / /
RUN npm install
RUN dotnet publish "./MoodleAssistant.csproj" -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "MoodleAssistant.dll"]

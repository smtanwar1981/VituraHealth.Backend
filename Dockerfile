# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY VituraHealth/*.csproj ./VituraHealth/
COPY VituraHealth.Application/*.csproj ./VituraHealth.Application/
COPY VituraHealth.Domain/*.csproj ./VituraHealth.Domain/
COPY VituraHealth.Infrastructure/*.csproj ./VituraHealth.Infrastructure/
COPY VituraHealth.UnitTests/*.csproj ./VituraHealth.UnitTests/
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT [ "dotnet", "VituraHealth.Api.dll" ]
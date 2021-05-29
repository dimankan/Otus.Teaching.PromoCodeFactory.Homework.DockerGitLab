FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base

WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
RUN ls -a
COPY [".", "./"]
RUN dotnet restore "Otus.Teaching.PromoCodeFactory.WebHost/Otus.Teaching.PromoCodeFactory.WebHost.csproj"
COPY . .
WORKDIR "/src/Otus.Teaching.PromoCodeFactory.WebHost"
RUN dotnet build "Otus.Teaching.PromoCodeFactory.WebHost.csproj" -c Release -o /app/build
RUN dotnet tool install --global dotnet-ef --version 3.1.4
ENV PATH="${PATH}:/root/.dotnet/tools"
CMD dotnet ef database update ${MIGRATION_NAME} --verbose

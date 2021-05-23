FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
RUN ls -a
COPY ["./src", "./"]
RUN dotnet restore "Otus.Teaching.PromoCodeFactory.WebHost/Otus.Teaching.PromoCodeFactory.WebHost.csproj"
COPY . .
WORKDIR "/src/Otus.Teaching.PromoCodeFactory.WebHost"
RUN dotnet build "Otus.Teaching.PromoCodeFactory.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Otus.Teaching.PromoCodeFactory.WebHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Otus.Teaching.PromoCodeFactory.WebHost.dll"]

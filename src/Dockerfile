FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=HTTP://*:5000
EXPOSE 5000


FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Otus.Teaching.PromoCodeFactory.WebHost/Otus.Teaching.PromoCodeFactory.WebHost.csproj", "Otus.Teaching.PromoCodeFactory.WebHost/"]
COPY ["Otus.Teaching.PromoCodeFactory.Core/Otus.Teaching.PromoCodeFactory.Core.csproj", "Otus.Teaching.PromoCodeFactory.Core/"]
COPY ["Otus.Teaching.PromoCodeFactory.DataAccess/Otus.Teaching.PromoCodeFactory.DataAccess.csproj", "Otus.Teaching.PromoCodeFactory.DataAccess/"]
RUN dotnet restore "Otus.Teaching.PromoCodeFactory.WebHost/Otus.Teaching.PromoCodeFactory.WebHost.csproj"
COPY . .
WORKDIR "/src/Otus.Teaching.PromoCodeFactory.WebHost"
RUN dotnet build "Otus.Teaching.PromoCodeFactory.WebHost.csproj" -c Development -o /app/build

FROM build AS publish
RUN dotnet publish "Otus.Teaching.PromoCodeFactory.WebHost.csproj" -c Development -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Otus.Teaching.PromoCodeFactory.WebHost.dll"]
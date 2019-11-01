FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src

# copy everything else and build app
COPY ProductCatalogApi.csproj ProductCatalogApi/
RUN dotnet restore ProductCatalogApi/ProductCatalogApi.csproj
WORKDIR /src/ProductCatalogApi
COPY . .
RUN dotnet build ProductCatalogApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ProductCatalogApi.csproj -c Release -o /app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductCatalogApi.dll"]
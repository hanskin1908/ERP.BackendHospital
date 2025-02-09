FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar y restaurar como capas distintas
COPY *.sln .
COPY ERP.Domain/*.csproj ./ERP.Domain/
COPY ERP.Application/*.csproj ./ERP.Application/
COPY ERP.Infrastructure/*.csproj ./ERP.Infrastructure/
COPY ERP.API/*.csproj ./ERP.API/

RUN dotnet restore

# Copiar todo lo demás y construir
COPY ERP.Domain/. ./ERP.Domain/
COPY ERP.Application/. ./ERP.Application/
COPY ERP.Infrastructure/. ./ERP.Infrastructure/
COPY ERP.API/. ./ERP.API/

WORKDIR /app/ERP.API
RUN dotnet publish -c Release -o out

# Construir imagen de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/ERP.API/out ./

ENV ASPNETCORE_URLS=http://+:${PORT}

ENTRYPOINT ["dotnet", "ERP.API.dll"]
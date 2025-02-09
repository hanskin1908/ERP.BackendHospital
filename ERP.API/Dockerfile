# Especificamos versión exacta del SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0.101-bookworm-slim AS build
WORKDIR /app

# Copiar csproj y restaurar dependencias
COPY ["ERP.Domain/ERP.Domain.csproj", "ERP.Domain/"]
COPY ["ERP.Application/ERP.Application.csproj", "ERP.Application/"]
COPY ["ERP.Infrastructure/ERP.Infrastructure.csproj", "ERP.Infrastructure/"]
COPY ["ERP.API/ERP.API.csproj", "ERP.API/"]

RUN dotnet restore "ERP.API/ERP.API.csproj"

# Copiar el resto del código
COPY . .

# Construir y publicar
WORKDIR "/app/ERP.API"
RUN dotnet publish "ERP.API.csproj" -c Release -o /app/publish

# Imagen final con versión exacta del runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0.1-bookworm-slim
WORKDIR /app
COPY --from=build /app/publish .

# Configuración del puerto
ENV ASPNETCORE_URLS=http://+:${PORT}

ENTRYPOINT ["dotnet", "ERP.API.dll"]
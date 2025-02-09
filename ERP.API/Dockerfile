FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy AS base
WORKDIR /app
EXPOSE ${PORT}

FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build
WORKDIR /src

# Copiar proyectos individualmente
COPY ["ERP.Domain/ERP.Domain.csproj", "ERP.Domain/"]
COPY ["ERP.Application/ERP.Application.csproj", "ERP.Application/"]
COPY ["ERP.Infrastructure/ERP.Infrastructure.csproj", "ERP.Infrastructure/"]
COPY ["ERP.API/ERP.API.csproj", "ERP.API/"]

# Restaurar dependencias
RUN dotnet restore "ERP.API/ERP.API.csproj"

# Copiar todo el código fuente
COPY . .

# Construir la aplicación
WORKDIR "/src/ERP.API"
RUN dotnet build "ERP.API.csproj" -c Release -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish "ERP.API.csproj" -c Release -o /app/publish

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ERP.API.dll"]
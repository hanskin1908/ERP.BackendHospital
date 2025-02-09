FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE ${PORT}

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar archivos .csproj y restaurar dependencias
COPY ["ERP.API/ERP.API.csproj", "ERP.API/"]
COPY ["ERP.Application/ERP.Application.csproj", "ERP.Application/"]
COPY ["ERP.Domain/ERP.Domain.csproj", "ERP.Domain/"]
COPY ["ERP.Infrastructure/ERP.Infrastructure.csproj", "ERP.Infrastructure/"]
RUN dotnet restore "ERP.API/ERP.API.csproj"

# Copiar el resto del código
COPY . .
WORKDIR "/src/ERP.API"

# Construir la aplicación
RUN dotnet build "ERP.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ERP.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ERP.API.dll"]
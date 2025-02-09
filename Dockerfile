FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copiar el archivo de solución primero
COPY ERP.Backend.sln .

# Copiar archivos de proyecto
COPY ERP.Domain/ ERP.Domain/
COPY ERP.Application/ ERP.Application/
COPY ERP.Infrastructure/ ERP.Infrastructure/
COPY ERP.API/ ERP.API/

# Restaurar dependencias usando el archivo de solución
RUN dotnet restore ERP.Backend.sln

# Copiar el resto de archivos y publicar
COPY . .
RUN dotnet publish ERP.API/ERP.API.csproj -c Release -o /app --no-restore

# Construir imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:${PORT}

ENTRYPOINT ["dotnet", "ERP.API.dll"]

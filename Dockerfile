# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copiar archivos de solución y proyecto
COPY global.json . # Asegurar compatibilidad con .NET 8.0
COPY *.sln .
COPY ERP.Domain/ ERP.Domain/
COPY ERP.Application/ ERP.Application/
COPY ERP.Infrastructure/ ERP.Infrastructure/
COPY ERP.API/ ERP.API/

# Restaurar dependencias con SDK 8.0
RUN dotnet restore --use-current-runtime

# Copiar el resto del código fuente
COPY . .

# Compilar en modo Release
RUN dotnet publish ERP.API/ERP.API.csproj -c Release -o /app --no-restore

# Etapa final: Imagen ligera de .NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

# Expone el puerto para Railway
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Punto de entrada
ENTRYPOINT ["dotnet", "ERP.API.dll"]

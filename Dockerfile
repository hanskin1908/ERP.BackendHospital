FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copiar los archivos de proyecto
COPY ERP.Domain/ERP.Domain.csproj ERP.Domain/
COPY ERP.Application/ERP.Application.csproj ERP.Application/
COPY ERP.Infrastructure/ERP.Infrastructure.csproj ERP.Infrastructure/
COPY ERP.API/ERP.API.csproj ERP.API/
COPY ERP.Backend.sln .

# Restaurar dependencias
RUN dotnet restore ERP.API/ERP.API.csproj

# Copiar el resto del código fuente
COPY . .

# Publicar la aplicación
RUN dotnet publish ERP.API/ERP.API.csproj -c Release -o /app --no-restore

# Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE ${PORT}

ENTRYPOINT ["dotnet", "ERP.API.dll"]
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copiar global.json primero
COPY global.json .
COPY *.sln .

# Copiar los archivos de proyecto y restaurar dependencias
COPY ERP.Domain/*.csproj ERP.Domain/
COPY ERP.Application/*.csproj ERP.Application/
COPY ERP.Infrastructure/*.csproj ERP.Infrastructure/
COPY ERP.API/*.csproj ERP.API/

RUN dotnet restore

# Copiar el resto de archivos y publicar
COPY . .
RUN dotnet publish ERP.API/ERP.API.csproj -c Release -o /app --no-restore

# Construir imagen final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:${PORT}

ENTRYPOINT ["dotnet", "ERP.API.dll"]
# Primera etapa - Restaurar dependencias
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS restore
WORKDIR /src
COPY ["ERP.Domain/*.csproj", "ERP.Domain/"]
COPY ["ERP.Application/*.csproj", "ERP.Application/"]
COPY ["ERP.Infrastructure/*.csproj", "ERP.Infrastructure/"]
COPY ["ERP.API/*.csproj", "ERP.API/"]
COPY ["ERP.Backend.sln", "."]
RUN dotnet restore "ERP.API/ERP.API.csproj"

# Segunda etapa - Build
FROM restore AS build
COPY . .
RUN dotnet build "ERP.API/ERP.API.csproj" -c Release -o /app/build --no-restore

# Tercera etapa - Publish
FROM build AS publish
RUN dotnet publish "ERP.API/ERP.API.csproj" -c Release -o /app/publish --no-restore /p:UseAppHost=false

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE ${PORT}

# Agregar script de inicio con mensaje
COPY <<EOF /app/start.sh
#!/bin/sh
echo "Iniciando la aplicación..."
dotnet ERP.API.dll
echo "Aplicación iniciada exitosamente en el puerto \${PORT}"
EOF

RUN chmod +x /app/start.sh
ENTRYPOINT ["/app/start.sh"]
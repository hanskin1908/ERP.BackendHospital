@echo off
REM --------------------------------------------------
REM Creación de la solución y proyectos del backend ERP
REM --------------------------------------------------

echo Creando la solución ERP.Backend.sln...
dotnet new sln -n ERP.Backend

echo Creando el proyecto ERP.Domain...
dotnet new classlib -n ERP.Domain

echo Creando el proyecto ERP.Application...
dotnet new classlib -n ERP.Application

echo Creando el proyecto ERP.Infrastructure...
dotnet new classlib -n ERP.Infrastructure

echo Creando el proyecto ERP.API...
dotnet new webapi -n ERP.API

echo Creando el proyecto ERP.Tests (xUnit)...
dotnet new xunit -n ERP.Tests

echo Agregando proyectos a la solución...
dotnet sln ERP.Backend.sln add ERP.Domain\ERP.Domain.csproj
dotnet sln ERP.Backend.sln add ERP.Application\ERP.Application.csproj
dotnet sln ERP.Backend.sln add ERP.Infrastructure\ERP.Infrastructure.csproj
dotnet sln ERP.Backend.sln add ERP.API\ERP.API.csproj
dotnet sln ERP.Backend.sln add ERP.Tests\ERP.Tests.csproj

echo.
echo Creando la estructura de carpetas...

REM ---------------------------
REM Estructura para ERP.Domain
REM ---------------------------
mkdir ERP.Domain\Autenticacion\Entidades
mkdir ERP.Domain\Menu\Entidades
mkdir ERP.Domain\Suscripcion\Entidades
mkdir ERP.Domain\Pacientes\Entidades
mkdir ERP.Domain\Citas\Entidades
mkdir ERP.Domain\Facturacion\Entidades

REM -------------------------------
REM Estructura para ERP.Application
REM -------------------------------
mkdir ERP.Application\Autenticacion\DTOs
mkdir ERP.Application\Autenticacion\Interfaces
mkdir ERP.Application\Autenticacion\Servicios

mkdir ERP.Application\Menu\DTOs
mkdir ERP.Application\Menu\Interfaces
mkdir ERP.Application\Menu\Servicios

mkdir ERP.Application\Suscripcion\DTOs
mkdir ERP.Application\Suscripcion\Interfaces
mkdir ERP.Application\Suscripcion\Servicios

mkdir ERP.Application\Pacientes\DTOs
mkdir ERP.Application\Pacientes\Interfaces
mkdir ERP.Application\Pacientes\Servicios

mkdir ERP.Application\Citas\DTOs
mkdir ERP.Application\Citas\Interfaces
mkdir ERP.Application\Citas\Servicios

mkdir ERP.Application\Facturacion\DTOs
mkdir ERP.Application\Facturacion\Interfaces
mkdir ERP.Application\Facturacion\Servicios

REM ----------------------------------
REM Estructura para ERP.Infrastructure
REM ----------------------------------
mkdir ERP.Infrastructure\Data
mkdir ERP.Infrastructure\Autenticacion\Repositorios
mkdir ERP.Infrastructure\Menu\Repositorios
mkdir ERP.Infrastructure\Suscripcion\Repositorios
mkdir ERP.Infrastructure\Pacientes\Repositorios
mkdir ERP.Infrastructure\Citas\Repositorios
mkdir ERP.Infrastructure\Facturacion\Repositorios
mkdir ERP.Infrastructure\Integraciones

REM -----------------------
REM Estructura para ERP.API
REM -----------------------
mkdir ERP.API\Controllers
mkdir ERP.API\Middleware
mkdir ERP.API\Configuracion

REM ----------------------
REM Estructura para ERP.Tests
REM ----------------------
mkdir ERP.Tests\Domain.Tests
mkdir ERP.Tests\Application.Tests
mkdir ERP.Tests\Infrastructure.Tests
mkdir ERP.Tests\API.Tests

echo.
echo Creando archivos con contenido de ejemplo...

REM ----------------------------------------------------
REM Archivos para ERP.Domain -> Autenticacion -> Entidades
REM ----------------------------------------------------
echo // Archivo: Usuario.cs > ERP.Domain\Autenticacion\Entidades\Usuario.cs
echo // Archivo: Rol.cs > ERP.Domain\Autenticacion\Entidades\Rol.cs
echo // Archivo: UsuarioRol.cs > ERP.Domain\Autenticacion\Entidades\UsuarioRol.cs

REM ------------------------------------------------
REM Archivos para ERP.Domain -> Menu -> Entidades
REM ------------------------------------------------
echo // Archivo: Menu.cs > ERP.Domain\Menu\Entidades\Menu.cs
echo // Archivo: MenuRol.cs > ERP.Domain\Menu\Entidades\MenuRol.cs

REM -----------------------------------------------------
REM Archivos para ERP.Domain -> Suscripcion -> Entidades
REM -----------------------------------------------------
echo // Archivo: Suscripcion.cs > ERP.Domain\Suscripcion\Entidades\Suscripcion.cs

REM ---------------------------------------------------
REM Archivos para ERP.Domain -> Pacientes -> Entidades
REM ---------------------------------------------------
echo // Archivo: Paciente.cs > ERP.Domain\Pacientes\Entidades\Paciente.cs
echo // Archivo: HistoriaClinica.cs > ERP.Domain\Pacientes\Entidades\HistoriaClinica.cs

REM --------------------------------------------------
REM Archivos para ERP.Domain -> Citas -> Entidades
REM --------------------------------------------------
echo // Archivo: Cita.cs > ERP.Domain\Citas\Entidades\Cita.cs
echo // Archivo: AgendaMedica.cs > ERP.Domain\Citas\Entidades\AgendaMedica.cs

REM ------------------------------------------------------
REM Archivos para ERP.Domain -> Facturacion -> Entidades
REM ------------------------------------------------------
echo // Archivo: Factura.cs > ERP.Domain\Facturacion\Entidades\Factura.cs
echo // Archivo: Pago.cs > ERP.Domain\Facturacion\Entidades\Pago.cs

REM ----------------------------------------------------------
REM Archivos para ERP.Application -> Autenticacion -> DTOs
REM ----------------------------------------------------------
echo // Archivo: LoginDTO.cs > ERP.Application\Autenticacion\DTOs\LoginDTO.cs
echo // Archivo: UsuarioDTO.cs > ERP.Application\Autenticacion\DTOs\UsuarioDTO.cs

REM ---------------------------------------------------------------
REM Archivos para ERP.Application -> Autenticacion -> Interfaces
REM ---------------------------------------------------------------
echo // Archivo: IAutenticacionServicio.cs > ERP.Application\Autenticacion\Interfaces\IAutenticacionServicio.cs
echo // Archivo: IAutenticacionRepositorio.cs > ERP.Application\Autenticacion\Interfaces\IAutenticacionRepositorio.cs

REM -------------------------------------------------------------
REM Archivos para ERP.Application -> Autenticacion -> Servicios
REM -------------------------------------------------------------
echo // Archivo: AutenticacionServicio.cs > ERP.Application\Autenticacion\Servicios\AutenticacionServicio.cs

REM ---------------------------------------------------
REM Archivos para ERP.Application -> Menu -> DTOs
REM ---------------------------------------------------
echo // Archivo: MenuDTO.cs > ERP.Application\Menu\DTOs\MenuDTO.cs

REM ---------------------------------------------------------
REM Archivos para ERP.Application -> Menu -> Interfaces
REM ---------------------------------------------------------
echo // Archivo: IMenuServicio.cs > ERP.Application\Menu\Interfaces\IMenuServicio.cs
echo // Archivo: IMenuRepositorio.cs > ERP.Application\Menu\Interfaces\IMenuRepositorio.cs

REM ------------------------------------------------------
REM Archivos para ERP.Application -> Menu -> Servicios
REM ------------------------------------------------------
echo // Archivo: MenuServicio.cs > ERP.Application\Menu\Servicios\MenuServicio.cs
echo // Archivo: MenuMapeador.cs > ERP.Application\Menu\Servicios\MenuMapeador.cs

REM ---------------------------------------------------------
REM Archivos para ERP.Application -> Suscripcion -> DTOs
REM ---------------------------------------------------------
echo // Archivo: SuscripcionDTO.cs > ERP.Application\Suscripcion\DTOs\SuscripcionDTO.cs

REM ---------------------------------------------------------------
REM Archivos para ERP.Application -> Suscripcion -> Interfaces
REM ---------------------------------------------------------------
echo // Archivo: ISuscripcionServicio.cs > ERP.Application\Suscripcion\Interfaces\ISuscripcionServicio.cs
echo // Archivo: ISuscripcionRepositorio.cs > ERP.Application\Suscripcion\Interfaces\ISuscripcionRepositorio.cs

REM ----------------------------------------------------------------
REM Archivos para ERP.Application -> Suscripcion -> Servicios
REM ----------------------------------------------------------------
echo // Archivo: SuscripcionServicio.cs > ERP.Application\Suscripcion\Servicios\SuscripcionServicio.cs

REM ---------------------------------------------------------
REM Archivos para ERP.Application -> Pacientes -> DTOs
REM ---------------------------------------------------------
echo // Archivo: PacienteDTO.cs > ERP.Application\Pacientes\DTOs\PacienteDTO.cs

REM --------------------------------------------------------------
REM Archivos para ERP.Application -> Pacientes -> Interfaces
REM --------------------------------------------------------------
echo // Archivo: IPacienteServicio.cs > ERP.Application\Pacientes\Interfaces\IPacienteServicio.cs

REM ------------------------------------------------------------
REM Archivos para ERP.Application -> Pacientes -> Servicios
REM ------------------------------------------------------------
echo // Archivo: PacienteServicio.cs > ERP.Application\Pacientes\Servicios\PacienteServicio.cs

REM ------------------------------------------------------
REM Archivos para ERP.Application -> Citas -> DTOs
REM ------------------------------------------------------
echo // Archivo: CitaDTO.cs > ERP.Application\Citas\DTOs\CitaDTO.cs

REM ---------------------------------------------------------
REM Archivos para ERP.Application -> Citas -> Interfaces
REM ---------------------------------------------------------
echo // Archivo: ICitaServicio.cs > ERP.Application\Citas\Interfaces\ICitaServicio.cs

REM -------------------------------------------------------
REM Archivos para ERP.Application -> Citas -> Servicios
REM -------------------------------------------------------
echo // Archivo: CitaServicio.cs > ERP.Application\Citas\Servicios\CitaServicio.cs

REM -----------------------------------------------------------
REM Archivos para ERP.Application -> Facturacion -> DTOs
REM -----------------------------------------------------------
echo // Archivo: FacturaDTO.cs > ERP.Application\Facturacion\DTOs\FacturaDTO.cs

REM --------------------------------------------------------------
REM Archivos para ERP.Application -> Facturacion -> Interfaces
REM --------------------------------------------------------------
echo // Archivo: IFacturacionServicio.cs > ERP.Application\Facturacion\Interfaces\IFacturacionServicio.cs

REM -----------------------------------------------------------
REM Archivos para ERP.Application -> Facturacion -> Servicios
REM -----------------------------------------------------------
echo // Archivo: FacturacionServicio.cs > ERP.Application\Facturacion\Servicios\FacturacionServicio.cs

REM ----------------------------------------------------
REM Archivos para ERP.Infrastructure -> Data
REM ----------------------------------------------------
echo // Archivo: ContextoDatos.cs > ERP.Infrastructure\Data\ContextoDatos.cs

REM --------------------------------------------------------------------
REM Archivos para ERP.Infrastructure -> Autenticacion -> Repositorios
REM --------------------------------------------------------------------
echo // Archivo: AutenticacionRepositorio.cs > ERP.Infrastructure\Autenticacion\Repositorios\AutenticacionRepositorio.cs

REM ---------------------------------------------------------------
REM Archivos para ERP.Infrastructure -> Menu -> Repositorios
REM ---------------------------------------------------------------
echo // Archivo: MenuRepositorio.cs > ERP.Infrastructure\Menu\Repositorios\MenuRepositorio.cs

REM -----------------------------------------------------------------
REM Archivos para ERP.Infrastructure -> Suscripcion -> Repositorios
REM -----------------------------------------------------------------
echo // Archivo: SuscripcionRepositorio.cs > ERP.Infrastructure\Suscripcion\Repositorios\SuscripcionRepositorio.cs

REM ---------------------------------------------------------------
REM Archivos para ERP.Infrastructure -> Pacientes -> Repositorios
REM ---------------------------------------------------------------
echo // Archivo: PacienteRepositorio.cs > ERP.Infrastructure\Pacientes\Repositorios\PacienteRepositorio.cs

REM ------------------------------------------------------------
REM Archivos para ERP.Infrastructure -> Citas -> Repositorios
REM ------------------------------------------------------------
echo // Archivo: CitaRepositorio.cs > ERP.Infrastructure\Citas\Repositorios\CitaRepositorio.cs

REM -----------------------------------------------------------------
REM Archivos para ERP.Infrastructure -> Facturacion -> Repositorios
REM -----------------------------------------------------------------
echo // Archivo: FacturaRepositorio.cs > ERP.Infrastructure\Facturacion\Repositorios\FacturaRepositorio.cs

REM -----------------------------------------------
REM Archivos para ERP.API -> Controllers
REM -----------------------------------------------
echo // Archivo: AutenticacionController.cs > ERP.API\Controllers\AutenticacionController.cs
echo // Archivo: MenuController.cs > ERP.API\Controllers\MenuController.cs
echo // Archivo: SuscripcionController.cs > ERP.API\Controllers\SuscripcionController.cs
echo // Archivo: PacientesController.cs > ERP.API\Controllers\PacientesController.cs
echo // Archivo: CitasController.cs > ERP.API\Controllers\CitasController.cs
echo // Archivo: FacturacionController.cs > ERP.API\Controllers\FacturacionController.cs

REM -----------------------------------------------------
REM Archivos para ERP.API -> Middleware (placeholder)
REM -----------------------------------------------------
echo // Archivo: MiddlewarePlaceholder.txt > ERP.API\Middleware\MiddlewarePlaceholder.txt

REM -------------------------------------------------------
REM Archivos para ERP.API -> Configuracion (placeholder)
REM -------------------------------------------------------
echo // Archivo: ConfiguracionPlaceholder.txt > ERP.API\Configuracion\ConfiguracionPlaceholder.txt

REM ---------------------------------------------------------
REM Archivos para ERP.Tests (placeholders para pruebas)
REM ---------------------------------------------------------
mkdir ERP.Tests\Domain.Tests 2>nul
mkdir ERP.Tests\Application.Tests 2>nul
mkdir ERP.Tests\Infrastructure.Tests 2>nul
mkdir ERP.Tests\API.Tests 2>nul
echo // Archivo: Domain.TestsPlaceholder.txt > ERP.Tests\Domain.Tests\TestsPlaceholder.txt
echo // Archivo: Application.TestsPlaceholder.txt > ERP.Tests\Application.Tests\TestsPlaceholder.txt
echo // Archivo: Infrastructure.TestsPlaceholder.txt > ERP.Tests\Infrastructure.Tests\TestsPlaceholder.txt
echo // Archivo: API.TestsPlaceholder.txt > ERP.Tests\API.Tests\TestsPlaceholder.txt

echo.
echo Estructura de proyectos y carpetas creada satisfactoriamente.
pause

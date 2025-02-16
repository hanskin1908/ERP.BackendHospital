# 🏥 Backend del Sistema de Gestión Clínica

Bienvenido al repositorio del **backend** de nuestro sistema de gestión clínica. Este proyecto está diseñado para optimizar la administración de citas, pacientes, empleados y facturación en clínicas médicas.  

- **Lenguaje principal:** C#  
- **Framework:** .NET 8  
- **Base de Datos:** SQL Server  
- **Arquitectura:** Basada en capas con principios SOLID  
- **Patrones de diseño utilizados:** Repository Pattern, Dependency Injection, Unit of Work  
- **Autenticación y Seguridad:** JSON Web Token (JWT) y políticas de acceso por roles  

---

## 🚀 **Estructura del Proyecto**
Este backend sigue una arquitectura **modular** y **escalable**, separando las responsabilidades en diferentes capas:

### 📂 **Módulos Principales**
- **ERP.API** _(Capa de Presentación)_ - Expone endpoints RESTful
- **ERP.Application** _(Capa de Aplicación)_ - Contiene la lógica de negocio
- **ERP.Domain** _(Capa de Dominio)_ - Define las entidades principales
- **ERP.Infrastructure** _(Capa de Infraestructura)_ - Implementación de repositorios y base de datos

---

## 🔑 **Principales Funcionalidades**

### 📅 **Gestíon de Citas Médicas**
- Creación, edición y cancelación de citas
- Control de disponibilidad en la agenda médica
- Asociación de citas con médicos y pacientes

### 👨‍⚕️ **Gestión de Pacientes y Empleados**
- Registro de pacientes y su historial clínico
- Registro de médicos, recepcionistas y especialidades

### 💳 **Facturación y Pagos**
- Generación de facturas automáticas
- Registro de pagos y actualización de estados
- Reportes de cuentas por cobrar y pagar

---

## 🔄 **Principios y Patrones Aplicados**

### **✅ Principios SOLID**
- **S** - Responsabilidad única: Cada clase tiene una sola responsabilidad.
- **O** - Abierto/Cerrado: Fácil extensibilidad sin modificar código existente.
- **L** - Sustitución de Liskov: Uso de interfaces para independencia de implementación.
- **I** - Segregación de Interfaces: Interfaces específicas para cada funcionalidad.
- **D** - Inversión de Dependencias: Uso de inyección de dependencias.

### **✅ Patrones de Diseño**
- **Repository Pattern** - Abstracción de la persistencia de datos.
- **Unit of Work** - Control transaccional en operaciones de base de datos.
- **Dependency Injection** - Modularidad y fácil prueba de componentes.

---

## 🔗 **Endpoints API REST**
Los endpoints siguen el estándar **RESTful**, organizados por funcionalidad:

| Acción | Método HTTP | Ruta |
|--------|------------|------|
| 🔐 Iniciar Sesión | `POST` | `/api/auth/login` |
| 👤 Obtener Perfil Usuario | `GET` | `/api/usuarios/{id}` |
| ✅ Crear Cita | `POST` | `/api/citas` |
| ⚕️ Listar Citas por Médico | `GET` | `/api/citas/medico/{idMedico}` |
| 👨‍⚕️ Registrar Paciente | `POST` | `/api/pacientes` |
| 💳 Generar Factura | `POST` | `/api/facturacion/generar` |

---

## 🔒 **Credenciales de Acceso (Usuarios de Prueba)**

| Rol          | Usuario      | Contraseña  |
|-------------|------------|-------------|
| Administrador | `admin` | `admin123` |
| Médico       | `medico` | `medico123` |

⚠ **Nota:** Se recomienda cambiar estas credenciales en producción por razones de seguridad.

---

## 🛠️ **Configuración y Ejecución**

### **Requisitos Previos**
- .NET 8 SDK
- SQL Server
- Visual Studio o VS Code

### **Pasos de Instalación**

1. **Clonar el repositorio**  
```bash
git clone https://github.com/tu-repositorio/backend-clinica.git
cd backend-clinica
```
2. **Configurar la base de datos**  
   - Crear una base de datos en SQL Server  
   - Ajustar la cadena de conexión en `appsettings.json`  
3. **Ejecutar Migraciones**  
```bash
dotnet ef database update
```
4. **Ejecutar la API**  
```bash
dotnet run --project ERP.API
```
5. **Probar la API con Swagger**  
   - `http://localhost:5000/swagger/index.html`

---

## 🚀 **Despliegue con Docker**

1. **Construir la imagen Docker**  
```bash
docker build -t backend-clinica .
```
2. **Ejecutar el contenedor**  
```bash
docker run -p 5000:5000 backend-clinica
```

Para desplegar en **Railway**, asegúrate de que tu archivo `Dockerfile` esté configurado correctamente y sube el proyecto a GitHub.

---

## 👨‍🎓 **Contribuciones**
Este sistema está en desarrollo continuo. Si deseas contribuir:
1. Realiza un **fork** del repositorio  
2. Crea una **rama** con tu mejora  
3. Abre un **Pull Request**  

---

## 📃 **Conclusión**
Este backend está diseñado con una arquitectura escalable, siguiendo buenas prácticas de desarrollo, principios **SOLID** y patrones de diseño reconocidos. Continuaremos expandiendo el sistema con nuevas funcionalidades como **telemedicina, mensajería interna, integración con WhatsApp y dashboards avanzados**. 🚀

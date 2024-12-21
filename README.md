# Booking.API

Booking.API es una API de gestión de reservas de clientes desarrollada utilizando Clean Architecture y el patrón de diseño CQRS.

## Características
- **Clean Architecture & Patrón CQRS**: 
  - **Clean Architecture**: Asegura una base de código mantenible y escalable.
  - **CQRS (Command Query Responsibility Segregation)**:  Separa las operaciones de lectura y escritura para mejorar la escalabilidad y mantener una arquitectura limpia y organizada.
- **Integración con SQL Server**: Proporciona soporte robusto para bases de datos.
- **Inyección de Dependencias**: Mejora la testabilidad y flexibilidad.
- **FluentValidation**: Valida las entradas de la API de manera eficiente.
- **Manejo Global de Excepciones**: Garantiza respuestas de error consistentes.
- **Integración con Servicios Externos**: Envío de correos electrónicos.
- **Próximas Implementaciones**:
  - **Seguridad**:
    - Seguridad basada en roles para la gestión de secretos.
    - JWT para generar tokens de autorización.
    - Always Encrypted para asegurar datos sensibles en la base de datos.

## Endpoints

### Reservas
- **POST /Booking/Create**: Crea una nueva reserva.
- **GET /Booking/Get-All**: Recupera una lista de todas las reservas.
- **GET /Booking/Get-By-DocumentNumber**: Recupera una lista de reservas filtradas por número de documento.
- **GET /Booking/Get-By-Type**: Recupera una lista de reservas filtradas por su tipo.

### Clientes
- **POST /Customer/Create**: Crea un nuevo cliente.
- **PUT /Customer/Update**: Actualiza la información de un cliente existente.
- **DELETE /Customer/Delete/{customerId}**: Elimina un cliente por su ID.
- **GET /Customer/Get-All**: Recupera una lista de clientes.
- **GET /Customer/Get-By-Id/{customerId}**: Recupera un cliente por su ID.
- **GET /Customer/Get-By-DocumentNumber/{documentNumber}**: Recupera un cliente por su número de documento.

### Usuarios
- **POST /User/Create**: Crea un nuevo usuario.
- **PUT /User/Update**: Actualiza la información de un usuario existente.
- **PUT /User/Update-Password**: Actualiza la contraseña de un usuario.
- **DELETE /User/Delete/{userId}**: Elimina un usuario por su ID.
- **GET /User/Get-All**: Recupera una lista de usuarios.
- **GET /User/Get-by-Id/{userId}**: Recupera un usuario por su ID.
- **GET /User/Get-by-Username-Password/{username}/{password}**: Recupera un usuario por su nombre de usuario y contraseña.

## Esquemas

### Modelos Base
- **BaseResponseModel**

### Modelos de Reserva
- **CreateBookingModel**
- **GetAllBookingModel**
- **GetBookingByDocumentNumberModel**
- **GetBookingByTypeModel**

### Modelos de Cliente
- **CreateCustomerModel**
- **GetAllCustomerModel**
- **GetCustomerByDocumentNumberModel**
- **GetCustomerByIdModel**
- **UpdateCustomerModel**

### Modelos de Usuario
- **CreateUserModel**
- **GetAllUserModel**
- **GetUserByIdModel**
- **GetUserByUsernameAndPasswordModel**
- **UpdateUserModel**
- **UpdateUserPasswordModel**

### Manejo de Errores
- **ProblemDetails**

## Comenzando

### Requisitos Previos
- .NET 9.0
- SQL Server

### Instalación
1. Clona el repositorio:
   ```sh
   git clone https://github.com/tetohc/Booking.API.git

2. Navega al directorio del proyecto:
   ```sh
   cd Booking.API
   
3. Restaura las dependencias:
   ```sh
   dotnet restore

### Configuración
- Actualiza el archivo appsettings.json con tu cadena de conexión de SQL Server.

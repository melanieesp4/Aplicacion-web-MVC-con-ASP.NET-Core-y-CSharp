# 📚 ListadoBecasApp – Aplicación Web MVC con ASP.NET Core y C#

Este proyecto es una aplicación web desarrollada con el patrón **MVC**, utilizando **ASP.NET Core**, **C#**, **Entity Framework Core** y **SQL Server**.  
Permite gestionar becas: listarlas, filtrarlas por carrera, crear, editar y eliminar registros desde un panel administrativo.

---

## 🚀 Características principales

- ✔ Listado de becas con búsqueda y filtrado por carrera  
- ✔ CRUD completo desde una sección administrativa  
- ✔ Arquitectura limpia usando DTOs, AutoMapper y capas separadas  
- ✔ Entity Framework Core para acceso a datos  
- ✔ Bootstrap 5 para el diseño  
- ✔ Uso de Repository Pattern + Dependency Injection  

---

## 🛠 Tecnologías principales

- **ASP.NET Core MVC 8**  
- **C# 12**  
- **Entity Framework Core**  
- **AutoMapper**  
- **SQL Server**  
- **LINQ**  
- **Bootstrap 5**  
- **Repository Pattern**  
- **Dependency Injection**

---

## ▶️ Cómo ejecutar el proyecto localmente

### 1️⃣ Clonar el repositorio

```bash
git clone https://github.com/melanieesp4/Aplicacion-web-MVC-con-ASP.NET-Core-y-CSharp.git
```

---

## 🗄 Restaurar la base de datos

Dentro del repositorio encontrarás una carpeta llamada **Database**, que contiene el archivo `.bak` necesario para restaurar la base de datos.

### ➤ Para restaurarla en SQL Server Management Studio 20:

1. Abrir **SQL Server Management Studio (SSMS)**  
2. Clic derecho en **Databases → Restore Database…**  
3. Seleccionar **Device** y cargar el archivo `.bak` proporcionado  
4. Confirmar el nombre de la base de datos (por ejemplo: `ProyectoFrameworkDB`)  
5. Clic en **OK** para restaurar

Una vez restaurada, ya puedes conectar el proyecto a la base.

---

## 🔧 Configurar la cadena de conexión

En el archivo `appsettings.json` modifica la sección:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=MI_SERVIDOR;Database=ProyectoFrameworkDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Reemplaza **MI_SERVIDOR** por tu instancia local.

---

## ▶️ Ejecución del proyecto

### Si usas Visual Studio:

1. Abrir la solución  
2. Seleccionar IIS Express o el perfil del proyecto  
3. Ejecutar con **F5**  

### Si usas CLI:

```bash
dotnet run
```

---

## 📂 Estructura del proyecto

- **Controllers** – Control del flujo de la aplicación  
- **Services** – Lógica de negocio  
- **Repositories** – Acceso a datos  
- **DTOs** – Transferencia de datos  
- **Models** – Entidades  
- **Views** – Interfaces Razor  

---

## ➕ Próximas mejoras

- Paginación  
- Validaciones avanzadas  
- Autenticación y autorización  
- Pruebas unitarias  
- Despliegue en la nube  

---

## 📄 Licencia

Proyecto académico. Libre uso para fines educativos.

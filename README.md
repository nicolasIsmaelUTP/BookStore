# BookStore - Aplicación Web ASP.NET Core (MVC) para Gestión de Libros

Bienvenido al repositorio de **BookStore**, una aplicación web desarrollada utilizando ASP.NET Core (MVC) y C#. Esta aplicación te permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) relacionadas con la información de libros, autores, géneros y editoriales.

## Características Principales

- **Operaciones CRUD:** La aplicación ofrece una interfaz de usuario intuitiva que te permite agregar, editar y eliminar información de libros, autores, géneros y editoriales. Estas operaciones se realizan a través de formularios y vistas diseñadas en ASP.NET Core MVC.

- **Separación de Responsabilidades:** La arquitectura del proyecto sigue los principios de separación de responsabilidades, utilizando las carpetas tradicionales de **Models**, **Views** y **Controllers**. Además, he creado una carpeta llamada **Repositories** para implementar la lógica de negocio. Cada entidad en el modelo tiene su propio servicio correspondiente en esta carpeta.

- **Persistencia de Datos:** La aplicación utiliza el Entity Framework para la persistencia de datos. Aunque originalmente lo configuré con SQL Server como base de datos, en este repositorio se encuentra configurada para utilizar SQLite, lo que simplifica la configuración y permite que otros desarrolladores puedan ejecutarla fácilmente en sus máquinas.

## Estructura del Proyecto

El proyecto está organizado de la siguiente manera:

- **Models:** Define las clases de modelo para libros, autores, géneros y editoriales.
- **Views:** Contiene las vistas de la interfaz de usuario utilizando el lenguaje de marcado Razor.
- **Controllers:** Incluye los controladores que manejan las acciones y la lógica de la aplicación.
- **wwwroot:** Almacena recursos estáticos.
- **Repositories:** Contiene la lógica de negocio y servicios para cada entidad en el modelo.

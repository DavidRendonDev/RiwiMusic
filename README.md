# RiwiMusic

🎵 Sistema de Gestión de Conciertos - RiwiMusic

Este es un sistema de gestión de conciertos simple desarrollado en C# y .NET, utilizando una arquitectura de consola. La aplicación permite gestionar conciertos, clientes y la venta de tiquetes de forma interactiva a través de un menú de consola. Es una solución de escritorio ligera, ideal para un entorno de aprendizaje o para la gestión interna de eventos a pequeña escala.

💻 Tecnologías y Requisitos

    Lenguaje de Programación: C#

    Framework: .NET

    Editor de Código: RIDER

    Entorno de Ejecución: Consola de comandos

🚀 Funcionalidades

El sistema ofrece un menú principal que centraliza las siguientes funcionalidades:

    Gestión de Conciertos:

        Registrar nuevos conciertos con detalles como nombre, artista, fecha, lugar y precio.

        Listar todos los conciertos disponibles.

        Editar la información de un concierto existente.

        Eliminar un concierto.

    Gestión de Clientes:

        Registrar nuevos clientes.

        Listar los clientes registrados.

        Editar la información de un cliente.

        Eliminar un cliente.

    Gestión de Tiquetes:

        Registrar la compra de tiquetes, asociándola a un cliente y un concierto.

        Listar los tiquetes que se han vendido.

        Editar la cantidad de tiquetes en una compra.

        Eliminar una compra.

    Historial de Compras:

        Consultar el historial de compras de un cliente específico.

📁 Estructura del Proyecto

El proyecto sigue una estructura modular simple para facilitar su comprensión y mantenimiento:

RiwiMusic/
├── models/
│   ├── Cliente.cs
│   ├── Concierto.cs
│   └── Compra.cs
├── Program.cs
└── RiwiMusic.csproj

    models/: Contiene las clases (entidades) del negocio (Cliente, Concierto, Compra).

    Program.cs: El archivo principal que contiene la lógica de la aplicación: el menú, la lógica de los métodos principales y la gestión de datos en memoria.

🛠️ Cómo Ejecutar el Proyecto

Sigue estos pasos para poner en marcha la aplicación:

    Abre el proyecto en tu editor de código RIDER.

    Abre la terminal de RIDER.

    Ejecuta el siguiente comando para compilar y ejecutar la aplicación:

Bash

dotnet run

    La aplicación se iniciará en la consola y mostrará el menú principal.

📝 Notas Adicionales

    La aplicación utiliza listas estáticas para almacenar los datos, lo que significa que la información se pierde al cerrar el programa. Esto es ideal para un entorno de aprendizaje y demostración.

    El código está diseñado para ser claro y conciso, utilizando funciones y métodos simples, lo que facilita su comprensión para estudiantes de programación.

    El proyecto incluye datos de ejemplo iniciales (datos "seed") para que no inicie completamente vacío y puedas probar las funcionalidades de inmediato.

👤 Autor

David Estevan Rendon Sanchez

    CODER RIWI


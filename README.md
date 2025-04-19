# GameRouletteApi


Descripción:

Este proyecto consiste en el desarrollo de una api para cumplir las acciones del Juego de Ruleta de un casino incluyendo Separación de capas clara (Onion Architecture).


Onion Architecture:

Infrastructure (Capa de procesos en base de datos) - Aqui se hacen las  implementaciones de las interfaces que están en Application es decir que implementa el acceso real a base de datos con Entity Framework Core (DbContext).

Domain (Capa de Dominio) - Aquí defines tus entidades puras y helpers de ayuda (User, bet, Result) - esta capa es la mas profunda y no depende de una externa.

Aplication (Capa de logica de negocio) - Aquí defines interfaces que representan los servicios de aplicación que manejan la lógica general esta capa no conoce los detalles del manejo de la base de datos.

Presentation (Capa que contiene los controladores) - Es decir que es la api Rest misma con sus end points expuestos en la web.

Tecnologías Utilizadas

-ASP.NET Core 8

-Entity Framework Core

-PostgreSQL (DB alojada en Tembo)

-Railway (deploy de API).


Probar demo online aqui:

https://apigameroulette-production.up.railway.app/api/(user o bet)/(nombre del usuario)


 Instalación Local para probar el codigo en tu maquina:

 # Clonar repositorio
  git clone https://github.com/Jeffersonp4/Prueba_Tecnica-Jefferson_ApiGameRoulette.git


 # Restaurar paquetes
  dotnet restore

 # Ejecutar
 dotnet run --project RoulettePresentation/RoulettePresentation.csproj

La api localmente inicia:
https://localhost:7123 cambiarlo en appsettings.Development.json

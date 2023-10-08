<p align="center">
  <img width="626" height="134" src="https://github.com/GerSam05/GalponIndustrial/assets/146037370/6623ae64-08b3-46f2-b04b-74edfbade9e8"><br>
  <img src="https://komarev.com/ghpvc/?username=gersam05&label=Profile%20views&color=0e75b6&style=flat" alt="gersam05" />
</p>


# 🔧🔩API Restfull FerreNewWorld

## Introducción
- **FerreNewWorld** es una **API Restfull** de tipo almacén desarrollada a partir de la necesidad de mantener un registro actualizado del inventario de los productos que se comercializan por parte de la empresa Ferretera **FerreNewWorld**.
- Todo esto con operaciones sencillas y remotas de tipo **CRUD** en una única tabla (img:1) almacenada en una base de datos.
- La Api posee un único controlador “**ProductoController**” para realizar acciones en la tabla “**Producto**”.
- La metodología utilizada fué **Stored Procedures** (Procedimientos Almacenados) con **Microsoft SQL Server Management Studio** (img:2), además de los Paquetes **Microsoft.Data.SqlClient** (5.1.1) y **Newtonsoft.Json**.
- Por la propia funcionabilidad de la Api, así como por los requerimientos de los clientes, se optó en esta ocasión por prescindir de las tareas asíncronas, de las clases capa y del almacenamiento de la cadena de conexión en el archivo **appsettings.json**.
- Se procuró en todo momento elaborar una Api lo más compacta posible y con la menor cantidad de código sin interferir en el funcionamiento de sus procesos; para ello los métodos **Post**(), **Put**() y **Delete**() del controlador realizan llamados  a un mismo método de la clase **DbDatos**.
- La Api posee una clase "**APIResponse**" con métodos, encargada de retornar una respuesta estandarizada para todas las peticiones realizadas desde los endpoints.


<br>

## Tecnologías utilizadas

<p align="left"> <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> <a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="40" height="40"/> </a> <a href="https://git-scm.com/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="40" height="40"/> </a> <a href="https://www.microsoft.com/en-us/sql-server" target="_blank" rel="noreferrer"> <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="40" height="40"/> </a> <a href="https://postman.com" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/getpostman/getpostman-icon.svg" alt="postman" width="40" height="40"/> </a> </p>
<br>

## Imágenes

Tablas de la base de datos:

![Tabla 1](https://github.com/GerSam05/FerreNewWorld/assets/146037370/28b0f914-d825-4b09-ae74-9593041dcbc6)
> Imagen 1: Query "Select * from Producto"
<br>

![sp](https://github.com/GerSam05/FerreNewWorld/assets/146037370/dd57b0aa-06d7-497b-8715-54211a090b7c)
> Imagen 2: Stored Procedures utilizados para las consultas
<br>

---

Espero que el repositorio les sea de utilidad👍🏻💡!!!...
 
> 📁 Todos mis proyectos estan disponibles en [![GitHub repository](https://img.shields.io/badge/repository-github-orange)](https://github.com/GerSam05?tab=repositories)

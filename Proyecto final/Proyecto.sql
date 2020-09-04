create database Unitec

use Unitec

use proyecto

create table Solicitudes
(
Personal varchar(50) primary key,
Cliente varchar(50),
Numero varchar (12),
Correo varchar (30),
Empresa varchar (50),
Direccion varchar (50),
Descripcion varchar (250),
Costo varchar (10),
)

insert into Solicitudes values ('Jesus','sad','das','sas','sas','sas','sas','dfsad')

select * from Solicitudes
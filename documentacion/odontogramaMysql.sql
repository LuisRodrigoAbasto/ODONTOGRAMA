--drop database odontograma

create database odontograma
go
use odontograma
go


create table paciente(
pacienteID int primary key auto_increment,
nombre varchar(50),
apellido varchar(50),
ci varchar(20),
telefono varchar(20),
fechaNacimiento date,
direccion varchar(200),
sexo varchar(20),
estado int
);
create table users(
usuarioID int primary key auto_increment,
nombre varchar(50),
apellido varchar(50),
tipo varchar(20),
usuario varchar (50),
password varchar(50),
estado int
);

create table atencion(
atencionID int primary key auto_increment,
pacienteID int,
empleadoID int,
odontologoID int,
fecha date,
hora time,
importe decimal(20,2),
descripcion varchar(300),
tipo varchar(50),
estado int,
foreign key(pacienteID)references paciente(pacienteID),
foreign key(empleadoID)references users(usuarioID),
foreign key(odontologoID)references users(usuarioID)
);

create table odontograma(
odontogramaID int primary key auto_increment,
fechaInicio date,
fechaFinal date,
montoTotal decimal(20,2),
tratamiento varchar(50),
estado int
);

create  table diente(
dienteID int primary key,
nombre varchar(50),
vector int,
estado int
)
;

create table tratamiento(
tratamientoID int primary key auto_increment,
nombre varchar(50),
color varchar(50),
precio decimal(20,2),
tipo varchar(20),
estado int
);

create table parte(
parteID int primary key,
nombre varchar(50),
estado int
);

create table odontograma_detalle(
odontogramaID int,
dienteID int,
parteID int,
diagnosticoID int,
procedimientoID int,
realizado varchar(10),
estado int,
primary key(odontogramaID,dienteID,parteID,diagnosticoID,procedimientoID),
foreign key(odontogramaID)references odontograma(odontogramaID),
foreign key(dienteID)references diente(dienteID),
foreign key(parteID)references parte(parteID),
foreign key(diagnosticoID)references tratamiento(tratamientoID),
foreign key(procedimientoID)references tratamiento(tratamientoID)
);


create table atencion_detalle(
atencionID int,
odontogramaID int,
dienteID int,
parteID int,
diagnosticoID int,
procedimientoID int,
realizado varchar(10),
estado int,
primary key(atencionID,odontogramaID,dienteID,parteID,diagnosticoID,procedimientoID),
foreign key(atencionID)references atencion(atencionID),
foreign key(odontogramaID,dienteID,parteID,diagnosticoID,procedimientoID)references odontograma_detalle(odontogramaID,dienteID,parteID,diagnosticoID,procedimientoID)
);

insert into users values('Luis Rodrigo','Abasto Torres','administrador','admin','123',1)
select *from users

insert into parte values(1,'Oclusal',1);
insert into parte values(2,'Vestibular',1);
insert into parte values(3,'Mesial',1);
insert into parte values(4,'Lingual o Palatino',1);
insert into parte values(5,'Distal',1);

insert into diente values(11,'Incisivo Central Superior Derecho',7,1)
insert into diente values(12,'Incisivo lateral Superior Derecho',6,1) 
insert into diente values(13,'Canino Superior Derecho',5,1)
insert into diente values(14,'Primer Premolar Superior Derecho',4,1)
insert into diente values(15,'Segundo Premolar Superior Derecho',3,1) 
insert into diente values(16,'Primer Molar Superior Derecho',2,1)
insert into diente values(17,'Segundo Molar Superior Derecho',1,1)
insert into diente values(18,'Tercer Molar Superior Derecho',0,1)

--Izquierda del paciente CUADRANTE 2

insert into diente values(21,'Incisivo Central Superior Izquierdo',8,1)
insert into diente values(22,'Incisivo lateral Superior Izquierdo',9,1) 
insert into diente values(23,'Canino Superior Izquierdo',10,1)
insert into diente values(24,'Primer Premolar Superior Izquierdo',11,1)
insert into diente values(25,'Segundo Premolar Superior Izquierdo',12,1) 
insert into diente values(26,'Primer Molar Superior Izquierdo',13,1)
insert into diente values(27,'Segundo Molar Superior Izquierdo',14,1)
insert into diente values(28,'Tercer Molar Superior Izquierdo',15,1)


insert into diente values(51,'Incisivo Central Superior Derecho Niños',20,1)
insert into diente values(52,'Incisivo lateral Superior Derecho Niños',19,1) 
insert into diente values(53,'Canino Superior Derecho Niños',18,1)
insert into diente values(54,'Primer Molar superior Derecho Niños',17,1)
insert into diente values(55,'Segundo Molar superior Derecho Niños',16,1) 



--Diente Superior Izquierdo  CUADRANTE 6

insert into diente values(61,'Incisivo Central Superior Izquierda Niños',21,1)
insert into diente values(62,'Incisivo lateral Superior Izquierda Niños',22,1) 
insert into diente values(63,'Canino Superior Izquierda Niños',23,1)
insert into diente values(64,'Primer Molar Superior Izquierda Niños',24,1)
insert into diente values(65,'Segundo Molar Superior Izquierda Niños',25,1)

--Diente Inferior Derecho Abajo  CUADRANTE 7

insert into diente values(81,'Incisivo Central Inferior Derecho Niños',30,1)
insert into diente values(82,'Incisivo lateral Inferior Derecho Niños',29,1) 
insert into diente values(83,'Canino Inferior Derecho Niños',28,1)
insert into diente values(84,'Primer Molar Inferior Derecho Niños',27,1)
insert into diente values(85,'Segundo Molar Inferior Derecho Niños',26,1) 

--Diente Inferior izquierdo Abajo CUADRANTE 8

insert into diente values(71,'Incisivo Central Inferior Izquierda Niños',31,1)
insert into diente values(72,'Incisivo lateral Inferior Izquierda Niños',32,1) 
insert into diente values(73,'Canino Inferior Izquierda Niños',33,1)
insert into diente values(74,'Primer Molar Inferior Izquierda Niños',34,1)
insert into diente values(75,'Segundo Molar Inferior Izquierda Niños',35,1) 

--Derecha INFERIOR del paciente CUADRANTE 3

insert into diente values(41,'Incisivo Central Inferior Derecho',43,1)
insert into diente values(42,'Incisivo lateral Inferior Derecho',42,1) 
insert into diente values(43,'Canino Inferior Derecho',41,1)
insert into diente values(44,'Primer Premolar Inferior Derecho',40,1)
insert into diente values(45,'Segundo Premolar Inferior Derecho',39,1) 
insert into diente values(46,'Primer Molar Inferior Derecho',38,1)
insert into diente values(47,'Segundo Molar Inferior Derecho',37,1)
insert into diente values(48,'Tercer Molar Inferior Derecho',36,1)

---Izquierda Inferior del Paciene CUADRANTE 4

insert into diente values(31,'Incisivo Central Inferior Izquierda',44,1)
insert into diente values(32,'Incisivo lateral Inferior Izquierda',45,1) 
insert into diente values(33,'Canino Inferior Izquierda',46,1)
insert into diente values(34,'Primer Premolar Inferior Izquierda',47,1)
insert into diente values(35,'Segundo Premolar Inferior Izquierda',48,1) 
insert into diente values(36,'Primer Molar Inferior Izquierda',49,1)
insert into diente values(37,'Segundo Molar Inferior Izquierda',50,1)
insert into diente values(38,'Tercer Molar Inferior Izquierda',51,1)



select *from tratamiento
select *from diente
select *from cita

select *from paciente
 

insert into tratamiento values('caries','Red',null,1,30,1) 
insert into tratamiento values('malaga','Blue',null,2,50,1) 
insert into tratamiento values('corona','Orange',null,2,60,1)

select *from diente
select *from parte 
select *from odontograma

select *from paciente
select *from cita_detalle

insert into odontograma values('25/03/2019','Orange',null,2,60,1)



 insert into cita_detalle values(1,1,'s',30)
 insert into paciente values('paciente1','coco coca','11254521','65652542','03/03/1996','barrio de mayo','M',1)
 insert into cita values(1,1,'2004-05-23T14:25:10','2004-05-23T15:25:10','paciente llego presentando dolor de lengua',1)
 insert into agenda values(1,'2004-05-23T08:25:10','2004-05-23T12:00:00','horaTrabajo lunes a viernes',1)
 insert into odontograma values('01/05/2018','paciente presenta daño seberos',1,null)
 insert into users values('Jose luis','mamani villca','administrador','Jose luis','123123',1)

 insert into odontograma values('07/06/2016','pacientes sid',1,null)
 insert into agenda values(1,'2019-07-06T08:06:05','2019-07-06T08:08:05','trabaja por las mañanas',1)
 insert into cita values(2,2,'2016-05-23T14:25:10','2016-05-23T15:25:10','paciente llego presentando sangria',1)
 insert into cita_detalle values(4,2,'s',10)

 select *from cita
 select *from cita_detalle
 select *from agenda
 select *from users

 select *from paciente
 select *from odontograma_detalle
 select *from tratamiento
 select *from parte 
 select *from odontograma
 select *from diente
 

 insert into odontograma_detalle values(4,21,1,1,'no',1,null,null)
  insert into odontograma_detalle values(4,22,2,2,'no',1,null,null)
  insert into odontograma_detalle values(4,23,4,3,'no',1,null,null)

select  p.nombre,p.apellido,u.nombre as odontologo,c.horaInicio,c.horaFin, 
ct.asistencia, ct.abono, o.fecha,d.dienteID as Numero_Diente,d.nombre as nombre_diente,pr.nombre as parte_diente,t.nombre as nombre_tratamiento,t.tipo,t.precio, od.realizado
from paciente as p, cita as c, agenda as a, users as u, cita_detalle as ct, odontograma as o, 
tratamiento as t, diente as d, parte as pr, odontograma_detalle as od
where p.pacienteID=c.pacienteID and u.usuarioID=a.agendaID and c.agendaID=a.agendaID and c.citaID=ct.citaID and 
ct.odontogramaID=o.odontogramaID and od.odontogramaID=o.odontogramaID and t.tratamientoID=od.tratamientoID and 
d.dienteID=od.dienteID and pr.parteID=od.parteID and o.odontogramaID=3
order by o.odontogramaID


---Odontograma sin el paciente
select o.fecha,d.dienteID as Numero_Diente,d.nombre as nombre_diente,pr.nombre as parte_diente,t.nombre as nombre_tratamiento,t.tipo,t.precio, od.realizado
from odontograma as o,tratamiento as t, diente as d, parte as pr, odontograma_detalle as od
where o.odontogramaID=od.odontogramaID and t.tratamientoID=od.tratamientoID and 
d.dienteID=od.dienteID and pr.parteID=od.parteID and o.odontogramaID=3
order by o.odontogramaID

select *from diente

select *from paciente
GO



create proc pacientes_odontogramas
@odontogramaID int
as
select p.nombre,p.apellido,u.nombre as odontologo, o.fecha,d.dienteID as Numero_Diente,d.nombre as nombre_diente,
pr.nombre as parte_diente,t.nombre as nombre_tratamiento,t.tipo,t.precio, od.realizado
from paciente as p, cita as c, agenda as a, users as u, cita_detalle as ct, odontograma as o, 
tratamiento as t, diente as d, parte as pr, odontograma_detalle as od
where p.pacienteID=c.pacienteID and u.usuarioID=a.usuarioID and c.agendaID=a.agendaID and c.citaID=ct.citaID and 
ct.odontogramaID=o.odontogramaID and od.odontogramaID=o.odontogramaID and t.tratamientoID=od.tratamientoID and 
d.dienteID=od.dienteID and pr.parteID=od.parteID and o.odontogramaID=@odontogramaID
 

exec pacientes_odontogramas 3

delete proc pacientes_odontogramas

go

create proc mostrarPaciente
as 
select top 200 *from paciente
where estado=1
order by pacienteID desc

go

create proc mostrarDiente
as 
select top 200 *from diente
where estado=1
order by dienteID desc

go

create proc mostrarTratamiento
as 
select top 200 *from tratamiento
where estado=1
order by tratamientoID desc


--mostrar el historial de odontogramas dado el paciente/




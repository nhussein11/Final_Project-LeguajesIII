---Base de datos destinada al proyecto final de Lenguajes 3---
----------------------------------------------------------
create database Torneo_Futbol
use Torneo_Futbol
----------------------------------------------------------
use master
drop database Torneo_Futbol
----------------------------------------------------------
create table Jugador(
	id_jugador int primary key IDENTITY(001,1) not null,
	nombre_jugador varchar(50) null,
	apellido_jugador varchar(50) null,
	telefono_jugador varchar(50) null,
	direccion_jugador varchar(50) null,
	mail_jugador varchar(50) null,
	rojas_jugador int null,
	amarillas_jugador int null,
	goles_jugador int null,
	username_jugador varchar(50),
	password_jugador varchar(50),
)
create table Equipo(
	id_equipo int primary key IDENTITY(01,1) not null,
	nombre_equipo varchar(50) null,
	puntos_equipo int null,
)
create table Partido(
	id_partido int primary key IDENTITY(1,1) not null,
	fecha_partido date null,
	hora_partido datetime null,
	lugar_partidod varchar(50) null,
	resultado_partido varchar(50) null,

)
create table Arbitro(
	id_arbitro int primary key IDENTITY(0001,1) not null,
	nombre_arbitro varchar(50) null,
	apellido_arbitro varchar(50) null,
	username_arbitro varchar(50) null,
	password_arbitro varchar(50) null,
)
create table Administrador(
	id_administrador int primary key IDENTITY(0001,1) not null,
	nombre_administrador varchar(50) null,
	apellido_administrador varchar (50) null,
	username_administrador varchar (50) null,
	password_administrador varchar (50) null,
	mail_administrador varchar(50) null,
)
----------------------------------------------------------
alter table Jugador add id_equipo int
alter table Jugador add constraint fk_id_equipo foreign key (id_equipo)  references Equipo (id_equipo)
---DUDA: a partido le atribuyo la fk de equipo o al reves
alter table Partido add id_equipo1 int
alter table Partido add constraint fk_id_equipo1 foreign key (id_equipo1)  references Equipo (id_equipo)
alter table Partido add id_equipo2 int
alter table Partido add constraint fk_id_equipo2 foreign key (id_equipo2)  references Equipo (id_equipo)
alter table Partido add id_arbitro int
alter table Partido add constraint fk_id_arbitro foreign key (id_arbitro) references Arbitro(id_arbitro)

alter table Partido add id_administrador int 
alter table Partido add constraint fk_id_administrador foreign key (id_administrador) references Administrador(id_administrador)
----------------------------------------------------------
DBCC CHECKIDENT ('Equipo', RESEED, 0)
insert Equipo (nombre_equipo, puntos_equipo) 
values 
 ('River Plate','0'),
 ('Boca Juniors','0'),
 ('Racing','0'),
 ('Independiente','0'),
 ('San Lorenzo','0'),
 ('Colón','0'),
 ('Velez','0'),
 ('Talleres','0'),
 ('Estudiantes','0'),
 ('Rosario Central','0'),
 ('Gimnasia y Esgrima LP','0'),
 ('Platense','0');

select * from Equipo
delete Equipo


----------------------------------------------------------
DBCC CHECKIDENT ('Jugador', RESEED, 0)
insert Jugador (nombre_jugador, apellido_jugador, telefono_jugador, direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador,username_jugador,password_jugador,id_equipo)
values 
('Franco','Armani','1111111111','Bs As Capital','farmani@gmail.com','0','0','0','farmani','farmani123','1'),
('Robert','Rojas','1111111112','Bs As Capital','rrojas@gmail.com','0','0','0','rrojas','rrojas123','1'),
('Fabrizio','Angilieri','1111111113','fangilieri@gmail.com','Bs As Capital','0','0','0','fangilieri','fangilieri123','1'),
('Jonathan','Maidana','1111111114','Bs As Capital','jmaidana@gmail.com','0','0','0','jmaidana','jmaidana123','1'),
('Hector','Martinez','1111111115','Bs As Capital','hmartinez@gmail.com','0','0','0','hmartinez','hmartinez123','1'),
('Joaquin','Arzura','1111111116','Bs As Capital','jarzura@gmail.com','0','0','0','jarzura','jarzura123','1'),
('Enzo','Fernandez','1111111117','Bs As Capital','efernandez@gmail.com','0','0','0','efernandez','efernandez123','1'),
('Bruno','Zuculini','1111111118','Rosario Capital','bzuculini@gmail.com','0','0','0','bzuculini','bzuculini123','1'),
('Agustin','Palavecino','1111111119','Rosario Capital','apalavecino@gmail.com','0','0','0','apalavecino','apalavecino123','1'),
('Lucas','Beltran','1111111110','Rosario Capital','lbeltran@gmail.com','0','0','0','lbeltran','lbeltran123','1'),
('Lucas','Pratto','1111111011','Rosario Capital','lbeltran@gmail.com','0','0','0','lpratto','lpratto123','1');

select * from Jugador where Jugador.id_equipo='1';

insert Jugador (nombre_jugador, apellido_jugador, telefono_jugador, direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador,username_jugador,password_jugador,id_equipo)
values 
('Agustin','Rossi','2222222221','Bs As Capital','arossi@gmail.com','0','0','0','arossi','arossi123','2'),
('Lisandro','Lopez','2222222222','Bs As Capital','llopez@gmail.com','0','0','0','llopez','llopez123','2'),
('Carlos','Zambrano','2222222223','Bs As Capital','czambrano@gmail.com','0','0','0','czambrano','czambrano123','2'),
('Marcos','Rojo','2222222224','Bs As Capital','mrojo@gmail.com','0','0','0','mrojo','mrojo123','2'),
('Frank','Fabra','2222222225','Bs As Capital','ffabra@gmail.com','0','0','0','ffabra','ffabra123','2'),
('Edwin','Cardona','2222222226','Bs As Capital','ecardona@gmail.com','0','0','0','ecardona','ecardona123','2'),
('Gonzalo','Maroni','2222222227','Bs As Capital','gmaroni@gmail.com','0','0','0','gmaroni','gmaroni123','2'),
('Jorman','Campuzano','2222222228','Bs As Capital','jcampuzano@gmail.com','0','0','0','jcampuzano','jcampuzano123','2'),
('Sebastian','Villa','2222222229','Bs As Capital','svilla@gmail.com','0','0','0','svilla','svilla123','2'),
('Cristian','Pavon','2222222210','Bs As Capital','cpavon@gmail.com','0','0','0','cpavon','cpavon123','2'),
('Exequiel','Obando','2222222211','Bs As Capital','eobando@gmail.com','0','0','0','eobando','eobando123','2');

select * from Jugador where Jugador.id_equipo='2'

insert Jugador (nombre_jugador, apellido_jugador, telefono_jugador, direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador,username_jugador,password_jugador,id_equipo)
values 
('Gabriel','Arias','3333333331','Bs As Capital','garias@gmail.com','0','0','0','garias','garias123','3'),
('Juan','Caceres','3333333332','Bs As Capital','jcaceres@gmail.com','0','0','0','jcaceres','jcaceres123','3'),
('Alexis','Soto','3333333333','Bs As Capital','asoto@gmail.com','0','0','0','asoto','asoto123','3'),
('Ivan','Pillud','3333333334','Bs As Capital','ipillud@gmail.com','0','0','0','ipillud','ipillud123','3'),
('Eugenio','Mena','3333333335','Bs As Capital','emena@gmail.com','0','0','0','emena','emena123','3'),
('Lucas','Orban','3333333336','Bs As Capital','lorban@gmail.com','0','0','0','lorban','lorban123','3'),
('Ezequiel','Schelotto','3333333337','Bs As Capital','eschelotto@gmail.com','0','0','0','eschelotto','eschelotto123','3'),
('Leonado','Sigali','3333333338','Bs As Capital','lsigali@gmail.com','0','0','0','lsigali','lsigali123','3'),
('Enzo','Copetti','3333333339','Bs As Capital','ecopetti@gmail.com','0','0','0','ecopetti','ecopetti123','3'),
('Tomas','Chancalay','3333333310','Bs As Capital','tchancalay@gmail.com','0','0','0','tchancalay','tchancalay123','3'),
('Maximiliano','Lovera','3333333311','Bs As Capital','mlovera@gmail.com','0','0','0','mlovera','mlovera123','3');
		
select * from Jugador where Jugador.id_equipo='3'

insert Jugador (nombre_jugador, apellido_jugador, telefono_jugador, direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador,username_jugador,password_jugador,id_equipo)
values 
('Sebastian','Sosa','4444444441','Bs As Capital','ssosa@gmail.com','0','0','0','ssosa','ssosa123','4'),
('Joaquin','Laso','4444444442','Bs As Capital','jlaso@gmail.com','0','0','0','jlaso','jlaso123','4'),
('Thomas','Ortega','4444444443','Bs As Capital','tortega@gmail.com','0','0','0','tortega','tortega123','4'),
('Gonzalo','Asis','4444444444','Bs As Capital','gasis@gmail.com','0','0','0','gasis','gasis123','4'),
('Sergio','Barreto','4444444445','Bs As Capital','sbarreto@gmail.com','0','0','0','sbarreto','sbarreto123','4'),
('Andres','Roa','4444444446','Bs As Capital','aroa@gmail.com','0','0','0','aroa','aroa123','4'),
('Alan','Velasco','4444444447','Bs As Capital','avelasco@gmail.com','0','0','0','avelasco','avelasco123','4'),
('Domingo','Blanco','4444444448','Bs As Capital','dblanco@gmail.com','0','0','0','dblanco','dblanco123','4'),
('Sebastian','Palacios','4444444449','Bs As Capital','spalacios@gmail.com','0','0','0','spalacios','spalacios123','4'),
('Francisco','Pizzini','4444444410','Bs As Capital','fpizzini@gmail.com','0','0','0','fpizzini','fpizzini123','4'),
('Silvio','Romero','4444444411','Bs As Capital','sromero@gmail.com','0','0','0','sromero','sromero123','4');
			
select * from Jugador where Jugador.id_equipo='4'

insert Jugador (nombre_jugador, apellido_jugador, telefono_jugador, direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador,username_jugador,password_jugador,id_equipo)
values 
('Sebastian','Torrico','5555555551','Bs As Capital','storrico@gmail.com','0','0','0','storrico','storrico123','5'),
('Federico','Gattoni','5555555552','Bs As Capital','fgattoni@gmail.com','0','0','0','fgattoni','fgattoni123','5'),
('Gino','Peruzzi','5555555553','Bs As Capital','gperuzzi@gmail.com','0','0','0','gperuzzi','gperuzzi123','5'),
('Bruno','Pitton','5555555554','Bs As Capital','bpitton@gmail.com','0','0','0','bpitton','bpitton123','5'),
('Oscar','Romero','5555555555','Bs As Capital','oromero@gmail.com','0','0','0','oromero','oromero123','5'),
('Diego','Rodriguez','5555555556','Bs As Capital','drodriguez@gmail.com','0','0','0','drodriguez','drodriguez123','5'),
('Angel','Romero','5555555557','Bs As Capital','aromero@gmail.com','0','0','0','aromero','aromero123','5'),
('Jalil','Elias','5555555558','Bs As Capital','jelias@gmail.com','0','0','0','jelias','jelias123','5'),
('Franco','Di Santo','5555555559','Bs As Capital','fdisanto@gmail.com','0','0','0','fdisanto','fdisanto123','5'),
('Lucas','Melano','5555555510','Bs As Capital','lmelano@gmail.com','0','0','0','lmelano','lmelano123','5'),
('Mariano','Peralta','5555555511','Bs As Capital','mperalta@gmail.com','0','0','0','mperalta','mperalta123','5');
		
select * from Jugador where Jugador.id_equipo='5'

insert Jugador (nombre_jugador, apellido_jugador, telefono_jugador, direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador,username_jugador,password_jugador,id_equipo)
values 
('Leonardo','Burian','6666666661','Bs As Capital','lburian@gmail.com','0','0','0','lburian','lburian123','6'),
('Gonzalo','Piovi','6666666662','Bs As Capital','gpiovi@gmail.com','0','0','0','gpiovi','gpiovi123','6'),
('Pablo','Goltz','6666666663','Bs As Capital','pgoltz@gmail.com','0','0','0','pgoltz','pgoltz123','6'),
('Facundo','Garces','6666666664','Bs As Capital','fgarces@gmail.com','0','0','0','fgarces','fgarces123','6'),
('Rafael','Delgado','6666666665','Bs As Capital','fdelgado@gmail.com','0','0','0','fdelgado','fdelgado123','6'),
('Alexis','Castro','6666666666','Bs As Capital','acastro@gmail.com','0','0','0','acastro','acastro123','6'),
('Federico','Lertora','6666666667','Bs As Capital','flertora@gmail.com','0','0','0','flertora','flertora123','6'),
('Eric','Meza','6666666668','Bs As Capital','emeza@gmail.com','0','0','0','emeza','emeza123','6'),
('Nicolas','Leguizamon','6666666669','Bs As Capital','nleguizamon@gmail.com','0','0','0','nleguizamon','nleguizamon123','6'),
('Santiago','Pierotti','6666666610','Bs As Capital','spierotti@gmail.com','0','0','0','spierotti','spierotti123','6'),
('Tomas','Sandoval','6666666611','Bs As Capital','tsandoval@gmail.com','0','0','0','tsandoval','tsandoval123','6');

select * from Jugador where Jugador.id_equipo='6'

insert Jugador (nombre_jugador, apellido_jugador, telefono_jugador, direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador,username_jugador,password_jugador,id_equipo)
values 
('Lucas','Hoyos','7777777771','Bs As Capital','lhoyos@gmail.com','0','0','0','lhoyos','lhoyos123','7'),
('Matias','De los santos','7777777772','Bs As Capital','mdelossantos@gmail.com','0','0','0','mdelossantos','mdelossantos123','7'),
('Lautaro','Giannetti','7777777773','Bs As Capital','lgiannetti@gmail.com','0','0','0','lgiannetti','lgiannetti123','7'),
('Tomas','Guidara','7777777774','Bs As Capital','tguidara@gmail.com','0','0','0','tguidara','tguidara123','7'),
('Miguel','Brizuela','7777777775','Bs As Capital','mbrizuela@gmail.com','0','0','0','mbrizuela','mbrizuela123','7'),
('Francisco','Ortega','7777777776','Bs As Capital','fortega@gmail.com','0','0','0','fortega','fortega123','7'),
('Ricardo','Centurion','7777777777','Bs As Capital','rcenturion@gmail.com','0','0','0','rcenturion','rcenturion123','7'),
('Thiago','Almada','7777777778','Bs As Capital','talmada@gmail.com','0','0','0','talmada','talmada123','7'),
('Cristian','Tarragona','7777777779','Bs As Capital','ctarragona@gmail.com','0','0','0','ctarragona','ctarragona123','7'),
('Lucas','Janson','7777777710','Bs As Capital','ljanson@gmail.com','0','0','0','ljanson','ljanson123','7'),
('Agustin','Bouzat','7777777711','Bs As Capital','abouzat@gmail.com','0','0','0','abouzat','abouzat123','7');

select * from Jugador where Jugador.id_equipo='7'

insert Jugador (nombre_jugador, apellido_jugador, telefono_jugador, direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador,username_jugador,password_jugador,id_equipo)
values 
('Marcos','Diaz','8888888881','Bs As Capital','mdiaz@gmail.com','0','0','0','mdiaz','mdiaz123','8'),
('Rafael','Perez','8888888882','Bs As Capital','rperez@gmail.com','0','0','0','rperez','rperez123','8'),
('Pedro','Hincapie','8888888883','Bs As Capital','phincapie@gmail.com','0','0','0','phincapie','phincapie123','8'),
('Nahuel','Tenaglia','8888888884','Bs As Capital','ntenaglia@gmail.com','0','0','0','ntenaglia','ntenaglia123','8'),
('Octavio','Moscarelli','8888888885','Bs As Capital','omoscarelli@gmail.com','0','0','0','omoscarelli','omoscarelli123','8'),
('Federico','Navarro','8888888886','Bs As Capital','fnavarro@gmail.com','0','0','0','fnavarro','fnavarro123','8'),
('Juan','Mendez','8888888887','Bs As Capital','jmendez@gmail.com','0','0','0','jmendez','jmendez123','8'),
('Enzo','Diaz','8888888888','Bs As Capital','ediaz@gmail.com','0','0','0','ediaz','ediaz123','8'),
('Francis','Mac Aliister','8888888889','Bs As Capital','fmacallister@gmail.com','0','0','0','fmacallister','fmacallister123','8'),
('Diego','Valoyes','8888888810','Bs As Capital','dvaloyes@gmail.com','0','0','0','dvaloyes','dvalores123','8'),
('Carlos','Auzqui','8888888811','Bs As Capital','cauzqui@gmail.com','0','0','0','cauzqui','cauzqui123','8');
				  
select * from Jugador where Jugador.id_equipo='8'

insert Jugador (nombre_jugador, apellido_jugador, telefono_jugador, direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador,username_jugador,password_jugador,id_equipo)
values 
('Mariano','Andujar','9999999991','Bs As Capital','mandujar@gmail.com','0','0','0','mandujar','mandujar123','9'),
('Agustin','Rogel','9999999992','Bs As Capital','arogel@gmail.com','0','0','0','arogel','arogel123','9'),
('Leonardo','Godoy','9999999993','Bs As Capital','lgodoy@gmail.com','0','0','0','lgodoy','lgodoy123','9'),
('Juan','Sanchez Miño','9999999994','Bs As Capital','jsanchezmiño@gmail.com','0','0','0','jsanchezmiño','jsanchezmiño123','9'),
('Fabian','Noguera','9999999995','Bs As Capital','fnoguera@gmail.com','0','0','0','fnoguera','fnoguera123','9'),
('Mauro','Diaz','9999999996','Bs As Capital','mdiaz@gmail.com','0','0','0','mdiaz','mdiaz123','9'),
('Nicolas','Pasquini','9999999997','Bs As Capital','mpasquini@gmail.com','0','0','0','mpasquini','mpasquini123','9'),
('Manuel','Castro','9999999998','Bs As Capital','mcastro@gmail.com','0','0','0','mcastro','mcastro123','9'),
('Federico','Gonzalez','9999999999','Bs As Capital','fgonzalez@gmail.com','0','0','0','fgonzalez','fgonzalez123','9'),
('Pablo','Sabbag','9999999910','Bs As Capital','psabbag@gmail.com','0','0','0','psabbag','psabbag123','9'),
('Leandro','Diaz','9999999911','Bs As Capital','ldiaz@gmail.com','0','0','0','ldiaz','ldiaz123','9');

select * from Jugador where Jugador.id_equipo='9'
	
insert Jugador (nombre_jugador, apellido_jugador, telefono_jugador, direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador,username_jugador,password_jugador,id_equipo)
values 
('Jorge','Broun','10000000001','Bs As Capital','jbroun@gmail.com','0','0','0','jbroun','jbroun123','10'),
('Nicolas','Ferreyra','10000000002','Bs As Capital','nferreyra@gmail.com','0','0','0','nferreyra','nferreyra123','10'),
('Lautaro','Blanco','10000000003','Bs As Capital','lblanco@gmail.com','0','0','0','lblanco','lblanco123','10'),
('Damian','Martinez','10000000004','Bs As Capital','dmartinez@gmail.com','0','0','0','dmartinez','dmartinez123','10'),
('Fernando','Torrent','10000000005','Bs As Capital','ftorrent@gmail.com','0','0','0','ftorrent','ftorrent123','10'),
('Rodrigo','Villagra','10000000006','Bs As Capital','rvillagra@gmail.com','0','0','0','rvillagra','rvillagra123','10'),
('Diago','Zabala','10000000007','Bs As Capital','dzabala@gmail.com','0','0','0','dzabala','dzabala123','10'),
('Emiliano','Veccchio','10000000008','Bs As Capital','evecchio@gmail.com','0','0','0','evecchio','evecchio123','10'),
('Alan','Marinelli','10000000009','Bs As Capital','amarinelli@gmail.com','0','0','0','amarinelli','amarinelli123','10'),
('Marco','Ruben','10000000010','Bs As Capital','mruben@gmail.com','0','0','0','mruben','mruben123','10'),
('Lucas','Gamba','10000000011','Bs As Capital','lgamba@gmail.com','0','0','0','lgamba','lgamba123','10');

select * from Jugador where Jugador.id_equipo='10'		
	
insert Jugador (nombre_jugador, apellido_jugador, telefono_jugador, direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador,username_jugador,password_jugador,id_equipo)
values 
('Rodrigo','Rey','11000000001','Bs As Capital','rrey@gmail.com','0','0','0','rrey','rrey123','11'),
('Leonardo','Morales','11000000002','Bs As Capital','lmorales@gmail.com','0','0','0','lmorales','lmorales123','11'),
('Maximiliano','Coronel','11000000003','Bs As Capital','mcoronel@gmail.com','0','0','0','mcoronel','mcoronel123','11'),
('German','Guiffrey','11000000004','Bs As Capital','gguiffrey@gmail.com','0','0','0','gguiffrey','gguiffrey123','11'),
('Lucas','Licht','11000000005','Bs As Capital','llicht@gmail.com','0','0','0','llicht','llicht123','11'),
('Brahian','Aleman','11000000006','Bs As Capital','baleman@gmail.com','0','0','0','baleman','baleman123','11'),
('Matias','Miranda','11000000007','Bs As Capital','mmiranda@gmail.com','0','0','0','mmiranda','mmiranda123','11'),
('Antonio','Napolitano','11000000008','Bs As Capital','anapolitano@gmail.com','0','0','0','anapolitano','anapolitano123','11'),
('Luis','Rodriguez','11000000009','Bs As Capital','lrodriguez@gmail.com','0','0','0','lrodriguez','lrodriguez123','11'),
('Johan','Carbonero','11000000010','Bs As Capital','jcarbonero@gmail.com','0','0','0','jcarbonero','jcarbonero123','11'),
('Erik','Ramirez','11000000011','Bs As Capital','eramirez@gmail.com','0','0','0','eramirez','eramirez123','11');
		
select * from Jugador where Jugador.id_equipo='11'	

insert Jugador (nombre_jugador, apellido_jugador, telefono_jugador, direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador,username_jugador,password_jugador,id_equipo)
values 
('Jorge','de Olivera','12000000001','Bs As Capital','jdeolivera@gmail.com','0','0','0','jdeolivera','jdeolivera123','12'),
('Augusto','Schott','12000000002','Bs As Capital','aschott@gmail.com','0','0','0','aschott','aschott123','12'),
('Juan','Infante','12000000003','Bs As Capital','jinfante@gmail.com','0','0','0','jinfante','jinfante123','12'),
('Luciano','Recalde','12000000004','Bs As Capital','lrecalde@gmail.com','0','0','0','lrecalde','lrecalde123','12'),
('Stefano','Callegari','12000000005','Bs As Capital','scallegari@gmail.com','0','0','0','scallegari','scallegari123','12'),
('Ivan','Gomez','12000000006','Bs As Capital','igomez@gmail.com','0','0','0','igomez','igomez123','12'),
('Julian','Marcioni','12000000007','Bs As Capital','jmarcioni@gmail.com','0','0','0','jmarcioni','jmarcioni123','12'),
('Mauro','Bogado','12000000008','Bs As Capital','mbogado@gmail.com','0','0','0','mbogado','mbogado123','12'),
('Matias','Tissera','12000000009','Bs As Capital','mtissera@gmail.com','0','0','0','mtissera','mtissera123','12'),
('Facundo','Curuchet','12000000010','Bs As Capital','fcuruchet@gmail.com','0','0','0','fcuruchet','fcuruchet123','12'),
('Nadir','Zeineddin','12000000011','Bs As Capital','nzeineddin@gmail.com','0','0','0','nzeineddin','nzeineddin123','12');
	
select * from Jugador where Jugador.id_equipo='12'	

----------------------------------------------------------
DBCC CHECKIDENT ('Arbitro', RESEED, 0)
insert Arbitro(nombre_arbitro, apellido_arbitro, username_arbitro,password_arbitro)
values
('Dario','Herrera','dherrera','dherrera123'),
('Nestor','Pitana','npitana','npitana123'),
('German','Delfino','gdelfino','gdelfino123'),
('Patricio','Loustau','ploustau','ploustau123'),
('Fernando','Rapallini','frapallini','frapallini123'),
('Diego','Ceballos','dceballos','dceballos123');

select * from Arbitro
----------------------------------------------------------
DBCC CHECKIDENT ('Administrador', RESEED, 0)
insert Administrador(nombre_administrador, apellido_administrador, username_administrador,password_administrador,mail_administrador)
values
('Nicolas','Hussein','nhussein','nhussein123','nicolashussein14@gmail.com'),
('Juan','Rodriguez','jrodriguez','jrodriguez123','jrodriguez@gmail.com');

select * from Administrador
use Torneo_Futbol
----------------------------------------------------------
SELECT nombre_jugador,apellido_jugador,telefono_jugador,direccion_jugador, mail_jugador, rojas_jugador, amarillas_jugador, goles_jugador, username_jugador,password_jugador FROM Jugador WHERE username_jugador='svilla' AND password_jugador='svilla123'

SELECT COUNT(1) FROM Jugador WHERE username_jugador='"+username+"' AND password_jugador='"+password+"'

use Torneo_Futbol
select * from Partido
DBCC CHECKIDENT ('Noticia', RESEED, 0)
delete Noticia
create table Noticia(
	id_noticia int primary key IDENTITY(001,1) not null,
	titulo_noticia varchar(50) null,
	cuerpo_noticia varchar(250) null,
)
alter table Noticia alter column cuerpo_noticia varchar(350) null
insert Partido(fecha_partido,hora_partido,lugar_partidod,id_equipo1,id_equipo2,id_arbitro) values ('','','','','','')
insert Noticia(titulo_noticia,cuerpo_noticia) values ('La selección argentina campeona de la Copa America','¡Argentina campeón de América! La Argentina de Lionel Messi logró su primer título después de 28 años ante Brasil y lo hizo en el Maracaná, el templo del fútbol sudamericano, al vencerlo por 1-0 en la final de la CONMEBOL Copa América.')
insert Noticia(titulo_noticia,cuerpo_noticia) values ('Boca - Atletico Mineiro','A casi un día del partido, se publicó la conversación de los árbitros mientras analizaban el gol anulado al Pulpito González. Hoy Rojas y López fueron suspendidos por "errores graves en el ejercicio de sus funciones"')
insert Noticia(titulo_noticia,cuerpo_noticia) values ('River','feo')
SELECT count(1) FROM Noticia
select * from Noticia order by id_noticia desc
use Torneo_Futbol
select * from Regla
create table Regla(
	id_regla int primary key IDENTITY(001,1) not null,
	titulo_regla varchar(50) null,
	cuerpo_regla varchar(250) null,
)
DBCC CHECKIDENT ('Regla', RESEED, 0)
delete Regla
insert Regla(titulo_regla,cuerpo_regla) values 
('Tarjetas','Amarillas: 2 permitidas, Rojas: 1, etc.'),
('Arbitros','Obligatoriamente 2 por partidos'),
('Duracion','2 tiempos de 40 minutos cada uno');

use Torneo_Futbol

select count(1) from Equipo

SELECT * FROM Equipo WHERE nombre_equipo='River Plate'
alter table Partido alter column fecha_partido varchar(50);
alter table Partido alter column hora_partido varchar(50);

sp_help Partidoe
delete Partido




delete Partido
DBCC CHECKIDENT ('Partido', RESEED, 0)

select id_partido, fecha_partido, hora_partido, lugar_partidod, e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2 order by id_partido asc
select e1.nombre_equipo, e2.nombre_equipo from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2  where id_partido>60  order by id_partido asc
select * from Partido
alter table Partido add Amonestados varchar(50) null;
alter table Partido add Expulsados varchar(50) null;
alter table Partido add GolesRealizados varchar(50) null;
select * from Equipo
select apellido_jugador, nombre_jugador from Jugador inner join Equipo on Jugador.id_equipo=Equipo.id_equipo where nombre_equipo=@nombre_equipo


insert Partido(resultado_partido, Amonestados, Expulsados, GolesRealizados) values('2-1','fasfsafds','fsafas','dasda') where id_partido='1';
update Partido set resultado_partido=@rdo_partido, Amonestados=@amonestados,Expulsados=@expulsados, GolesRealizados=@goles_realizados  where id_equipo1=@id_equipo1 and id_equipo2=@id_equipo2;
update Partido set resultado_partido='2-1', Amonestados='prueba',Expulsados='prueba', GolesRealizados='prueba'  where id_equipo1='1' and id_equipo2='7';
update Partido set resultado_partido=NULL, Amonestados=NULL,Expulsados=NULL, GolesRealizados=NULL  where resultado_partido is not null;
select * from Partido
select id_partido, resultado_partido, GolesRealizados, Amonestados, Expulsados from Partido WHERE resultado_partido is not null order by id_partido asc
SELECT count(1) FROM Partido
sp_help Partido
select * from Partido

use Torneo_Futbol
create table Comentario(
	id_comentario int primary key IDENTITY(001,1) not null,
	nombre_comentario varchar(50) null,
	apellido_comentario varchar(50) null,
	mail_comentario varchar(50) null,
	titulo_comentario varchar(50) null,
	cuerpo_comentario varchar(250) null,
)
delete from Comentario where titulo_comentario=@titulo_comentario
select * from Comentario
delete from Comentario where titulo_comentario is null
insert Comentario(nombre_comentario,apellido_comentario,mail_comentario,titulo_comentario,cuerpo_comentario) values ('dasdsa','dasdssa','dadasd','Titulo ','fsafasafsa')
select nombre_jugador,apellido_jugador,username_jugador,password_jugador,mail_jugador,telefono_jugador,direccion_jugador,goles_jugador,amarillas_jugador,rojas_jugador, nombre_equipo from Jugador inner join Equipo on Jugador.id_equipo=Equipo.id_equipo
select * from Arbitro
select * from Arbitro where username_arbitro=@username_arbitro AND password_arbitro=@password_arbitro


select * from Regla 
update Administrador set nombre_administrador=@nombre_admin, apellido_administrador=@apellido_admin, username_administrador=@user_admin, password_administrador=@password_admin, mail_administrador=@mail_admin where username_administrador=@user_admin_viejo and password_administrador=@password_admin_vieja
update Administrador set username_administrador='nhussein' where username_administrador='nhussein11' and password_administrador='nhussein123'
update Jugador set username_jugador=@user_jug, password_jugador=@password_jug, telefono_jugador=@telefono_jug, direccion_jugador=@direccion_jug, mail_jugador=@mail_jug where username_jugador=@user_admin_viejo and password_jugador=@password_admin_vieja

update Arbitro set username_arbitro=@user_arb, password_arbitro=@password_arb where username_arbitro=@user_arb_viejo and password_arbitro=@password_arb_vieja 
select * from Arbitro
update Jugador set username_jugador='svilla'where username_jugador='svilla11' and password_jugador='svilla123'

update Jugador set goles_jugador=goles_jugador+1 where nombre_jugador=@nombre_jugador and apellido_jugador=@apellido_jugador

update Jugador set goles_jugador=3, amarillas_jugador=3, rojas_jugador=2 where id_equipo='2'
DELETE FROM Regla WHERE titulo_regla='dsadsa'
select * from Regla
select * from Equipo
select * from Partido
select * from Jugador
select id_partido, fecha_partido, hora_partido, lugar_partidod, e1.nombre_equipo, e2.nombre_equipo, (Arbitro.nombre_arbitro+' '+Arbitro.apellido_arbitro) from Partido inner join Equipo e1 on e1.id_equipo=id_equipo1 inner join Equipo e2 on e2.id_equipo=id_equipo2 inner join Arbitro on Partido.id_arbitro=Arbitro.id_arbitro order by id_partido asc

insert Regla (titulo_regla,cuerpo_regla) values ('Cambios','Durante el desarrollo del juego se permiten realizar 3 interrupciones en las cuales se permitirá realizar cambios ilimitados')
alter table Regla alter column cuerpo_regla varchar(500) null


select top 1(mail_administrador), (mail_jugador) from Jugador, Administrador where username_administrador='nhussein' or username_jugador='nhussein'
select password_administrador from Administrador where username_administrador=@us
select password_jugador from Jugador where username_jugador=@us

update Equipo set puntos_equipo=puntos_equipo+3 where nombre_equipo='Boca Juniors'
update Equipo set puntos_equipo=puntos_equipo+1 where nombre_equipo=@nombre_equipo
update Equipo set puntos_equipo=0 where nombre_equipo=@nombre_equipo

select * from Equipo order by puntos_equipo desc, nombre_equipo asc
select id_jugador, apellido_jugador, nombre_jugador,goles_jugador,amarillas_jugador,rojas_jugador, nombre_equipo from Jugador inner join Equipo on Jugador.id_equipo=Equipo.id_equipo  order by  Equipo.id_equipo
select * from Jugador inner join Equipo on Jugador.id_equipo=Equipo.id_equipo  order by Equipo.id_equipo
select * from Jugador

insert Jugador(nombre_jugador,apellido_jugador,username_jugador,password_jugador,goles_jugador,rojas_jugador,amarillas_jugador,id_equipo) values (@nombre_jug,@apellido_jug,@user_jug,@pass_jug,'0','0','0',@id_Eq)

select id_equipo from Equipo where nombre_equipo=@nombre_eq
'Platense'
delete Jugador where nombre_jugador='lucas' and apellido_jugador='hussein' and id_equipo='12'

select id_jugador, apellido_jugador, nombre_jugador,direccion_jugador,telefono_jugador,mail_jugador from Jugador

select id_jugador, apellido_jugador, nombre_jugador, direccion_jugador, telefono_jugador, mail_jugador, nombre_equipo from Jugador inner join Equipo on Jugador.id_equipo=Equipo.id_equipo  order by  Equipo.id_equipo
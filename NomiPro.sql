Create database NomiPro

Create table CARGOS
(
ID_Cargos			int identity (1,1), -- PK --
Nombre				varchar (45),
Estado				varchar (45),
Valor_cargo			int
)

Insert into CARGOS values
('Paulina', 'Activa', 500000)

Create table HORARIO
(
ID_Horario			int identity (1,1), -- PK --
Tipo_Horario		varchar (45),
Hora_Trabajo		varchar (45),
)

Insert into HORARIO values
('Tarde', '12PM-8PM'),
('Mañana', '6AM-11AM'),
('Noche','7PM-4AM'),
('Mañana-Noche', '7AM-7PM')



Create table TIPO_VINCULACION
(
ID_Vinculacion		int identity (1,1), -- PK --
Descripcion			varchar (45),
Estado				varchar (45)
)

Insert into TIPO_VINCULACION values
('Obra labor', 'Activo'),
('Tiempo indefinido', 'Activo')

Create table EMPLEADOS
(
ID_Emple			int identity (1,1), -- PK --
Nombre				varchar (45),
Apellido			varchar (45),
Correo				varchar (45),
Telefono			int,
Tipo_Documento		varchar (45),
Numero_Documento	int,
ID_Cargos			int, -- FK CARGOS --
ID_Vinculacion		int, -- FK Tipo_Vinculacion --
ID_Horario			int, -- FK HORARIO --
Estado				varchar (45)
)

Insert into EMPLEADOS (Nombre, Apellido,Correo,Telefono,Tipo_Documento,Numero_Documento,ID_Cargos,ID_Vinculacion,ID_Horario,Estado)values
('Henry Andres', 'Ramirez', 'Henry@hotmail.com', 301357790, 'Cedula', 1017252657, 1,2,4, 'Activo')

alter table EMPLEADOS drop column Apellido
select*from EMPLEADOS
exec sp_columns EMPLEADOS

Create table PARAFISCALES
(
ID_Parafiscales		int identity (1,1), -- PK --
Nombre				varchar (45),
Valor				int,
Estado				varchar (45)
)

Create table PARAXEMPLE
(
ID_PAEM				int identity (1,1), -- PK --
ID_Parafiscales		int, -- FK PARAFISCALES --
ID_EmpleP			int, -- FK EMPLEADOS --
Mes					varchar (45)
)

Create table CONTROL_PAGO
(
ID_Control_Pago		int identity (1,1), -- PK --
ID_EmpleCP			int, -- FK EMPLEADOS --
Valor_Horas_Extra	int,
Valor_Parafiscal	int,
Mes					varchar (45)
)

Create table HORA_EXTRAS
(
ID_HExtras			int identity (1,1), -- PK --
Nombre				varchar (45),
Valor				int,
Estado				varchar (45)
)

Create table HETRAXEMPLEADO
(
ID_HEXE				int identity (1,1), -- PK --
ID_Emple			int, -- FK EMPLEADOS --
ID_HExtras			int, 
Numero_Horas		int,
Mes					varchar (45)
)

Create table NOMINA
(
ID_Nomina			int identity (1,1), -- PK --
ID_EmpleN			int, -- FK EMPLEADOS --
ID_CargoN			int, -- FK CARGO --
ID_Control_PagoN	int, -- FK CONTROL_PAGO --
Mes					varchar (45),
Estado				varchar (45),
Subtotal			int,
Total				int
)

		 								-- L L A V E S		P R I M A R I A S --
Alter table EMPLEADOS			Add constraint PK_ID_Emple			PRIMARY KEY (ID_Emple)
Alter table CARGOS				Add constraint PK_ID_Cargos			PRIMARY KEY (ID_Cargos)
Alter table HORARIO				Add constraint PK_ID_Horario		PRIMARY KEY (ID_Horario)
Alter table PARAFISCALES		Add constraint PK_ID_Parafiscales	PRIMARY KEY (ID_Parafiscales)
Alter table PARAXEMPLE			Add constraint PK_ID_PAEM			PRIMARY KEY (ID_PAEM)
Alter table CONTROL_PAGO		Add constraint PK_ID_Control_Pago	PRIMARY KEY (ID_Control_Pago)
Alter table HETRAXEMPLEADO		Add constraint PK_ID_HEXE			PRIMARY KEY (ID_HEXE)
Alter table HORA_EXTRAS			Add constraint PK_ID_Hextras		PRIMARY KEY (ID_Hextras)
Alter table TIPO_VINCULACION	Add constraint PK_ID_Vinculacion	PRIMARY KEY (ID_Vinculacion)
Alter table NOMINA				Add constraint PK_ID_Nomina			PRIMARY KEY (ID_Nomina)

										-- L L A V E S		F O R A N E A S --
Alter table NOMINA				Add constraint FK_ID_EmpleN			FOREIGN KEY (ID_EmpleN)			References EMPLEADOS		(ID_Emple)
Alter table NOMINA				Add constraint FK_ID_CargoN			FOREIGN KEY (ID_CargoN)			References CARGOS			(ID_Cargos)
Alter table NOMINA				Add constraint FK_ID_Control_PagoN	FOREIGN KEY	(ID_Control_PagoN)	References CONTROL_PAGO		(ID_Control_Pago)
Alter table HETRAXEMPLEADO		Add constraint FK_ID_Emple			FOREIGN KEY (ID_Emple)			References EMPLEADOS		(ID_Emple)
Alter table HETRAXEMPLEADO		Add constraint FK_HORA_EXTRAS		FOREIGN KEY (ID_HExtras)		References HORA_EXTRAS		(ID_Hextras)
Alter table EMPLEADOS			Add constraint FK_ID_Cargos			FOREIGN KEY (ID_Cargos)			References CARGOS			(ID_Cargos)
Alter table EMPLEADOS			Add constraint FK_ID_Vinculacion	FOREIGN KEY (ID_Vinculacion)	References TIPO_VINCULACION	(ID_Vinculacion)
Alter table EMPLEADOS			Add constraint FK_ID_Horario		FOREIGN KEY (ID_Horario)		References HORARIO			(ID_Horario)
Alter table PARAXEMPLE			Add constraint FK_ID_Parafiscales	FOREIGN KEY (ID_Parafiscales)	References PARAFISCALES		(ID_Parafiscales)
Alter table PARAXEMPLE			Add constraint FK_ID_EmpleP			FOREIGN KEY (ID_EmpleP)			References EMPLEADOS		(ID_Emple)
Alter table CONTROL_PAGO		Add constraint FK_ID_EmpleCP		FOREIGN KEY (ID_EmpleCP)		References EMPLEADOS		(ID_Emple)


---------- F U N C I O N E S ----------

select * from EMPLEADOS

Select GETDATE ();
Select DATEPART(MONTH, GETDATE());
Select SUBSTRING('Henry Andres', 7,6); 
Select STUFF('Henry',5, 3, 'Andres');
Select LOWER('PAULINA');
Select UPPER('tarde-noche');
Select REPLACE('Henry@hotmail','hotmail','gmail');
Select REVERSE('301357790');
Select REPLICATE(' Horarios ',5);
Select DAY(GETDATE());


Select DATEDIFF(DAY,'2019/08/06','2019/08/13')




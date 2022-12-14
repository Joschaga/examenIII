--SQL Queries Examen Final Programación II - Martes Noche

--Creamos la Base de Datos
create database VehiculosExamenFinal
use VehiculosExamenFinal

--Creamos las Tablas
create table Usuarios
(
	Id_Usuarios int identity (1,1),
	Usuario nvarchar (50) not null unique,
	Clave nvarchar (30) not null,
	Nombre nvarchar (50) not null,
	Apellido nvarchar (50) not null
	constraint pk_idUsu primary key(Id_Usuarios)
)

create table Placa
(
	IdPlaca int identity (1,1),
	NumPlaca nvarchar (6),
	IdUsuario int,
	Monto money default 0
	constraint pkidPlaca primary key (IdPlaca)
	constraint fk_idPlaca foreign key(IdUsuario) references Usuarios(Id_Usuarios)
)

--Creamos SPs para tabla Usuarios
create procedure ConsultarUsuarios
	as
		begin
		select * from Usuarios
		end

create procedure IngresarUsuarios
	@Usuario nvarchar(50) = '',
	@Clave nvarchar(30) = '',
	@Nombre nvarchar(50) = '',
	@Apellido nvarchar(50) = ''
	as
		begin
			insert into Usuarios (Usuario, Clave, Nombre, Apellido) values (@Usuario, @Clave, @Nombre, @Apellido)
		end

create procedure BorrarUsuarios
	@Usuario nvarchar (50)
	as
		begin
			delete Usuarios where Usuario = @Usuario
		end

create procedure ActualizarUsuarios
	@Usuario nvarchar(50) = '',
	@Clave nvarchar(30) = '',
	@Nombre nvarchar(50) = '',
	@Apellido nvarchar(50) = ''
	as
		begin
			update Usuarios set Clave = @Clave, Nombre = @Nombre, Apellido = @Apellido where Usuario = @Usuario;
		end

--Creamos SPs para tabla Placa
create procedure ConsultarPlaca
	as
		begin
		select * from Placa
		end

create procedure IngresarPlaca
	@NumPlaca nvarchar(6),
	@IdUsuario int,
	@Monto money
	as
		begin
			insert into Placa (NumPlaca, IdUsuario, Monto) values (@NumPlaca, @IdUsuario, @Monto)
		end

create procedure BorrarPlaca
	@NumPlaca nvarchar (6)
	as
		begin
			delete Placa where NumPlaca = @NumPlaca
		end

create procedure ActualizarPlaca
	@NumPlaca nvarchar(50) = '',
	@IdUsuario nvarchar(30) = '',
	@Monto nvarchar(50) = ''
	as
		begin
			update Placa set NumPlaca = @NumPlaca, IdUsuario = @IdUsuario, Monto = @Monto where NumPlaca = @NumPlaca;
		end

--Creamos SP para Reporte de Pago
create procedure ReportePlacaUsuario
	@NumPlaca nvarchar(50) = ''
	as
		begin
			select U.Nombre, U.Apellido, P.NumPlaca, P.Monto, P.Monto*0.13 as IVA, P.Monto*1.13 as Total
			from Placa P
			inner join Usuarios U on P.IdUsuario = U.Id_Usuarios
			where P.NumPlaca = @NumPlaca
		end

--Creamos SP para Validar Login
create procedure ConsultarLogin
	@Usuario nvarchar(50) = '',
	@Clave nvarchar(30) = ''	
	as
		begin
			select * from Usuarios where Usuario = @Usuario and Clave = @Clave
		end
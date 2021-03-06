USE [master]
GO
/****** Object:  Database [PruebaQuantum]    Script Date: 11/01/2022 1:18:22 p. m. ******/
CREATE DATABASE [PruebaQuantum]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PruebaQuantum', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PruebaQuantum.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PruebaQuantum_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PruebaQuantum_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PruebaQuantum] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PruebaQuantum].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PruebaQuantum] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PruebaQuantum] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PruebaQuantum] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PruebaQuantum] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PruebaQuantum] SET ARITHABORT OFF 
GO
ALTER DATABASE [PruebaQuantum] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PruebaQuantum] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PruebaQuantum] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PruebaQuantum] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PruebaQuantum] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PruebaQuantum] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PruebaQuantum] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PruebaQuantum] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PruebaQuantum] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PruebaQuantum] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PruebaQuantum] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PruebaQuantum] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PruebaQuantum] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PruebaQuantum] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PruebaQuantum] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PruebaQuantum] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PruebaQuantum] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PruebaQuantum] SET RECOVERY FULL 
GO
ALTER DATABASE [PruebaQuantum] SET  MULTI_USER 
GO
ALTER DATABASE [PruebaQuantum] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PruebaQuantum] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PruebaQuantum] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PruebaQuantum] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PruebaQuantum] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PruebaQuantum', N'ON'
GO
ALTER DATABASE [PruebaQuantum] SET QUERY_STORE = OFF
GO
USE [PruebaQuantum]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 11/01/2022 1:18:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[identificacion] [varchar](20) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturaDetalles]    Script Date: 11/01/2022 1:18:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturaDetalles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idfactura] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [decimal](10, 2) NOT NULL,
	[valorUnitario] [decimal](10, 2) NOT NULL,
	[valorunitarioIva] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_facturaDetalles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaEncabezados]    Script Date: 11/01/2022 1:18:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaEncabezados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[fechaVenta] [datetime] NOT NULL,
	[fechaEnvio] [datetime] NOT NULL,
 CONSTRAINT [PK_FacturaEncabezado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 11/01/2022 1:18:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](128) NOT NULL,
	[ValorVentaConIva] [decimal](18, 0) NOT NULL,
	[CantidadUnidadesInventario] [int] NOT NULL,
	[PorcentajeIVAAplicado] [decimal](3, 2) NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[facturaDetalles]  WITH CHECK ADD  CONSTRAINT [FK__facturaDe__idfac__3C69FB99] FOREIGN KEY([idfactura])
REFERENCES [dbo].[FacturaEncabezados] ([id])
GO
ALTER TABLE [dbo].[facturaDetalles] CHECK CONSTRAINT [FK__facturaDe__idfac__3C69FB99]
GO
ALTER TABLE [dbo].[facturaDetalles]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[Productos] ([Id])
GO
ALTER TABLE [dbo].[FacturaEncabezados]  WITH CHECK ADD FOREIGN KEY([idCliente])
REFERENCES [dbo].[Clientes] ([id])
GO
/****** Object:  StoredProcedure [dbo].[BuscarClientes]    Script Date: 11/01/2022 1:18:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
create procedure [dbo].[BuscarClientes]
@identificacion varchar(20)
as
begin
	SELECT  [id]
		  ,[identificacion]
		  ,[nombre]
		  ,[Apellido]
          ,[Direccion]
          ,[telefono]
	FROM [PruebaQuantum].[dbo].[Clientes] where Identificacion =@identificacion
end
GO
/****** Object:  StoredProcedure [dbo].[InsertarClientes]    Script Date: 11/01/2022 1:18:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[InsertarClientes]
	  @identificacion varchar(20)
	,@nombre varchar(50)
		  ,@Apellido varchar(50)
          ,@Direccion varchar(50)
          ,@telefono varchar(50)
as
begin
	insert into clientes([identificacion] ,[nombre] ,[Apellido] ,[Direccion],[telefono])values(	  @identificacion
		  ,@nombre ,@Apellido,@Direccion,@telefono)
	declare @id int
	set @id=@@IDENTITY
	select id , [identificacion] ,[nombre] ,[Apellido] ,[Direccion],[telefono] from Clientes where id=@id
end
GO
/****** Object:  StoredProcedure [dbo].[Insertardetalles]    Script Date: 11/01/2022 1:18:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Insertardetalles]
 @idfactura int
      ,@idProducto int
      ,@cantidad decimal(10,2)
      ,@valorUnitario decimal(10,2)
      ,@valorunitarioIva decimal(10,2)
as 
begin
	begin tran
	insert into facturaDetalles([idfactura],[idProducto],[cantidad],[valorUnitario],[valorunitarioIva])
	values(@idfactura,@idProducto,@cantidad,@valorUnitario,@valorunitarioIva)
	declare @total int,@existencia int
	select @existencia=CantidadUnidadesInventario  from Productos where Id =@idProducto
	set @total=@existencia- TRY_CAST( @cantidad as int)
	update Productos set  CantidadUnidadesInventario= @total where Id =@idProducto
	if @total<=0
	begin
		rollback tran
		RAISERROR ('No hay producto en stock',16,1)	
		return
	end
	commit

end
GO
/****** Object:  StoredProcedure [dbo].[InsertarEncabezado]    Script Date: 11/01/2022 1:18:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InsertarEncabezado]
@idCliente int
,@fechaVenta datetime
,@fechaEnvio datetime
as 
begin
	insert into FacturaEncabezados([idCliente],[fechaVenta],[fechaEnvio])
	values(@idCliente,@fechaVenta,@fechaEnvio)
	select @@IDENTITY
end
GO
/****** Object:  StoredProcedure [dbo].[Listarproducto]    Script Date: 11/01/2022 1:18:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE procedure [dbo].[Listarproducto]
as 
begin
SELECT [Id]
      ,[Nombre]
      ,[ValorVentaConIva]
	  ,valorventaconiva/(1+[PorcentajeIVAAplicado])ValorentaSinIVA
      ,[CantidadUnidadesInventario]
      ,[PorcentajeIVAAplicado]
  FROM [PruebaQuantum].[dbo].
  [Productos]
end
GO
USE [master]
GO
ALTER DATABASE [PruebaQuantum] SET  READ_WRITE 
GO
INSERT INTO [dbo].[Producto] VALUES ('Audifonos',320000,1000,0.16)
INSERT INTO [dbo].[Producto] VALUES ('Mouse',118000,1000,0.16)
INSERT INTO [dbo].[Producto] VALUES ('Teclado',80000,1000,0.16)
INSERT INTO [dbo].[Producto] VALUES ('Monitor',875000,1000,0.16)
INSERT INTO [dbo].[Producto] VALUES ('Windows 10 Enterprise Licence',1250000,1000,0.16)
INSERT INTO [dbo].[Producto] VALUES ('ThinkPAd 395 ',475000,1000,0.16)
INSERT INTO [dbo].[Producto] VALUES ('ASUS L790',2850000,1000,0.16)
INSERT INTO [dbo].[Producto] VALUES ('ACER T890',320000,1000,0.16)
INSERT INTO [dbo].[Producto] VALUES ('MSI 750',6500000,1000,0.16)
INSERT INTO [dbo].[Producto] VALUES ('Lenovo A100',3500000,1000,0.16)

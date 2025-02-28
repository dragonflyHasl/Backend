USE [master]
GO
/****** Object:  Database [EcoStoreDB]    Script Date: 24/02/2025 07:27:32 ******/
CREATE DATABASE [EcoStoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EcoStoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\EcoStoreDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EcoStoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\EcoStoreDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [EcoStoreDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EcoStoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EcoStoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EcoStoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EcoStoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EcoStoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EcoStoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [EcoStoreDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EcoStoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EcoStoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EcoStoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EcoStoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EcoStoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EcoStoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EcoStoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EcoStoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EcoStoreDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EcoStoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EcoStoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EcoStoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EcoStoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EcoStoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EcoStoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EcoStoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EcoStoreDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EcoStoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [EcoStoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EcoStoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EcoStoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EcoStoreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EcoStoreDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EcoStoreDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EcoStoreDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [EcoStoreDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [EcoStoreDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 24/02/2025 07:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 24/02/2025 07:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [uniqueidentifier] NULL,
	[ProductoId] [int] NULL,
	[Cantidad] [int] NOT NULL,
	[FechaAgregado] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 24/02/2025 07:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](500) NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesOrden]    Script Date: 24/02/2025 07:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesOrden](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrdenId] [uniqueidentifier] NULL,
	[ProductoId] [int] NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordenes]    Script Date: 24/02/2025 07:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordenes](
	[Id] [uniqueidentifier] NOT NULL,
	[UsuarioId] [uniqueidentifier] NULL,
	[FechaOrden] [datetime] NULL,
	[MontoTotal] [decimal](18, 2) NOT NULL,
	[Estado] [nvarchar](20) NULL,
	[DireccionEnvio] [nvarchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 24/02/2025 07:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](500) NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[CategoriaId] [int] NULL,
	[EsEcologico] [bit] NOT NULL,
	[UrlImagen] [nvarchar](500) NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 24/02/2025 07:27:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [uniqueidentifier] NOT NULL,
	[Correo] [nvarchar](100) NOT NULL,
	[HashPassword] [varbinary](max) NOT NULL,
	[SalPassword] [varbinary](max) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Rol] [nvarchar](20) NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrito] ADD  DEFAULT (getdate()) FOR [FechaAgregado]
GO
ALTER TABLE [dbo].[Categorias] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Ordenes] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Ordenes] ADD  DEFAULT (getdate()) FOR [FechaOrden]
GO
ALTER TABLE [dbo].[Ordenes] ADD  DEFAULT ('Pendiente') FOR [Estado]
GO
ALTER TABLE [dbo].[Productos] ADD  DEFAULT ((1)) FOR [EsEcologico]
GO
ALTER TABLE [dbo].[Productos] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ('Usuario') FOR [Rol]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([Id])
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[DetallesOrden]  WITH CHECK ADD FOREIGN KEY([OrdenId])
REFERENCES [dbo].[Ordenes] ([Id])
GO
ALTER TABLE [dbo].[DetallesOrden]  WITH CHECK ADD FOREIGN KEY([ProductoId])
REFERENCES [dbo].[Productos] ([Id])
GO
ALTER TABLE [dbo].[Ordenes]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categorias] ([Id])
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD CHECK  (([Cantidad]>(0)))
GO
ALTER TABLE [dbo].[DetallesOrden]  WITH CHECK ADD CHECK  (([Cantidad]>(0)))
GO
ALTER TABLE [dbo].[Ordenes]  WITH CHECK ADD CHECK  (([Estado]='Cancelado' OR [Estado]='Entregado' OR [Estado]='Enviado' OR [Estado]='Procesando' OR [Estado]='Pendiente'))
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD CHECK  (([Precio]>(0)))
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD CHECK  (([Stock]>=(0)))
GO
USE [master]
GO
ALTER DATABASE [EcoStoreDB] SET  READ_WRITE 
GO

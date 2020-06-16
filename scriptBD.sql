USE [master]
GO
EXEC sp_configure 'default language', 0;
GO
RECONFIGURE;
GO
/*Change to mixed autentification*/
EXEC xp_instance_regwrite 
    N'HKEY_LOCAL_MACHINE', 
    N'Software\Microsoft\MSSQLServer\MSSQLServer', 
    N'LoginMode', 
    REG_DWORD, 
    2;
GO
/****** Object:  Database [SGEA]    Script Date: 13/06/2020 21:18:18 ******/
CREATE DATABASE [SGEA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SGEA', FILENAME = N'C:\BasesDatos\SGEA\DATA\SGEA.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SGEA_log', FILENAME = N'C:\BasesDatos\SGEA\LOG\SGEA_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SGEA] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SGEA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SGEA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SGEA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SGEA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SGEA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SGEA] SET ARITHABORT OFF 
GO
ALTER DATABASE [SGEA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SGEA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SGEA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SGEA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SGEA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SGEA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SGEA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SGEA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SGEA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SGEA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SGEA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SGEA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SGEA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SGEA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SGEA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SGEA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SGEA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SGEA] SET RECOVERY FULL 
GO
ALTER DATABASE [SGEA] SET  MULTI_USER 
GO
ALTER DATABASE [SGEA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SGEA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SGEA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SGEA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SGEA] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SGEA', N'ON'
GO
USE [SGEA]
GO
/****** Object:  User [userSGEA]    Script Date: 13/06/2020 21:18:19 ******/
CREATE LOGIN [userSGEA] WITH PASSWORD = 'FEI20sis11*';  
GO 
CREATE USER [userSGEA] FOR LOGIN [userSGEA] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [userSGEA]
GO
ALTER LOGIN [userSGEA] WITH DEFAULT_DATABASE = [SGEA]
GO
/****** Object:  Table [dbo].[ActividadAsistente]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActividadAsistente](
	[ActividadAsistente_Asistente_Id] [int] NOT NULL,
	[Asistente_Id] [int] NOT NULL,
 CONSTRAINT [PK_ActividadAsistente] PRIMARY KEY CLUSTERED 
(
	[ActividadAsistente_Asistente_Id] ASC,
	[Asistente_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ActividadParticipante]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActividadParticipante](
	[ActividadParticipante_Participante_Id] [int] NOT NULL,
	[Participante_Id] [int] NOT NULL,
 CONSTRAINT [PK_ActividadParticipante] PRIMARY KEY CLUSTERED 
(
	[ActividadParticipante_Participante_Id] ASC,
	[Participante_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ActividadSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActividadSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[costo] [float] NOT NULL,
	[aula] [nvarchar](max) NOT NULL,
	[tipo] [nvarchar](max) NOT NULL,
	[EventoId] [int] NOT NULL,
	[ComiteId] [int] NOT NULL,
 CONSTRAINT [PK_ActividadSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AdscripcionSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdscripcionSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ciudad] [nvarchar](max) NOT NULL,
	[direccion] [nvarchar](max) NOT NULL,
	[correoElectronico] [nvarchar](max) NOT NULL,
	[estado] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AdscripcionSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ArticuloSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticuloSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[abstract] [nvarchar](max) NOT NULL,
	[documento] [nvarchar](max) NOT NULL,
	[titulo] [nvarchar](max) NOT NULL,
	[keyword] [nvarchar](max) NOT NULL,
	[status] [bit] NOT NULL,
	[ActividadId] [int] NULL,
 CONSTRAINT [PK_ArticuloSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AsistenteSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsistenteSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[apellidoPaterno] [nvarchar](max) NOT NULL,
	[apellidoMaterno] [nvarchar](max) NULL,
	[correoElectronico] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AsistenteSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AutorArticuloSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutorArticuloSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AutorId] [int] NOT NULL,
	[ArticuloId] [int] NOT NULL,
 CONSTRAINT [PK_AutorArticuloSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AutorSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutorSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[apellidoPaterno] [nvarchar](max) NOT NULL,
	[apellidoMaterno] [nvarchar](max) NULL,
	[correoElectronico] [nvarchar](max) NOT NULL,
	[AdscripcionId] [int] NOT NULL,
 CONSTRAINT [PK_AutorSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CalendarioSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarioSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[horaInicio] [time](7) NOT NULL,
	[horaFin] [time](7) NOT NULL,
	[ActividadId] [int] NOT NULL,
 CONSTRAINT [PK_CalendarioSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComiteSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComiteSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[EventoId] [int] NOT NULL,
 CONSTRAINT [PK_ComiteSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EgresoSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EgresoSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[concepto] [nvarchar](max) NOT NULL,
	[monto] [float] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[Magistral_Id] [int] NULL,
 CONSTRAINT [PK_EgresoSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EvaluacionSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluacionSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[calificacion] [int] NOT NULL,
	[descripcion] [nvarchar](max) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[ArticuloId] [int] NOT NULL,
	[MiembroComite_Id] [int] NOT NULL,
 CONSTRAINT [PK_EvaluacionSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventoSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventoSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[fechaInicio] [datetime] NOT NULL,
	[fechaFin] [datetime] NOT NULL,
	[lugar] [nvarchar](max) NOT NULL,
	[institucionOrganizadora] [nvarchar](max) NOT NULL,
	[EventoPresupuesto_Evento_Id] [int] NULL,
	[OrganizadorId] [int] NOT NULL,
 CONSTRAINT [PK_EventoSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IngresoSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IngresoSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[concepto] [nvarchar](max) NOT NULL,
	[monto] [float] NOT NULL,
	[fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_IngresoSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MagistralSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MagistralSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[apellidoPaterno] [nvarchar](max) NOT NULL,
	[apellidoMaterno] [nvarchar](max) NULL,
	[AdscripcionId] [int] NOT NULL,
	[ActividadMagistral_Magistral_Id] [int] NOT NULL,
 CONSTRAINT [PK_MagistralSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaterialSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [nvarchar](max) NOT NULL,
	[cantidad] [int] NOT NULL,
	[costo] [float] NOT NULL,
	[ActividadId] [int] NULL,
	[EgresoMaterial_Material_Id] [int] NOT NULL,
 CONSTRAINT [PK_MaterialSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MiembroComiteSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MiembroComiteSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[apellidoPaterno] [nvarchar](max) NOT NULL,
	[apellidoMaterno] [nvarchar](max) NULL,
	[correoElectronico] [nvarchar](max) NOT NULL,
	[nivelExperiencia] [nvarchar](max) NOT NULL,
	[liderComite] [bit] NOT NULL,
	[ComiteId] [int] NOT NULL,
	[evaluador] [bit] NOT NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_MiembroComiteSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrganizadorSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizadorSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[apellidoPaterno] [nvarchar](max) NOT NULL,
	[apellidoMaterno] [nvarchar](max) NULL,
	[correoElectronico] [nvarchar](max) NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK_OrganizadorSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParticipanteSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParticipanteSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[apellidoPaterno] [nvarchar](max) NOT NULL,
	[apellidoMaterno] [nvarchar](max) NULL,
	[titulo] [nvarchar](max) NOT NULL,
	[AdscripcionId] [int] NOT NULL,
 CONSTRAINT [PK_ParticipanteSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PatrocinadorSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatrocinadorSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[apellidoPaterno] [nvarchar](max) NOT NULL,
	[apellidoMaterno] [nvarchar](max) NOT NULL,
	[correoElectronico] [nvarchar](max) NOT NULL,
	[empresa] [nvarchar](max) NOT NULL,
	[direccion] [nvarchar](max) NOT NULL,
	[numeroTelefono] [nvarchar](max) NOT NULL,
	[IngresoPatrocinador_Patrocinador_Id] [int] NULL,
 CONSTRAINT [PK_PatrocinadorSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PresupuestoSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PresupuestoSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[concepto] [nvarchar](max) NOT NULL,
	[supuestoPresupuesto] [float] NOT NULL,
 CONSTRAINT [PK_PresupuestoSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegistroArticuloSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistroArticuloSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[comprobantePago] [tinyint] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[hora] [time](7) NOT NULL,
	[cantidadPago] [float] NOT NULL,
	[RegistroArticuloIngreso_RegistroArticulo_Id] [int] NOT NULL,
	[AutorArticulo_Id] [int] NOT NULL,
 CONSTRAINT [PK_RegistroArticuloSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TareaSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TareaSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[ActividadId] [int] NOT NULL,
 CONSTRAINT [PK_TareaSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsuarioSet]    Script Date: 13/06/2020 21:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioSet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [nvarchar](max) NOT NULL,
	[contrasenia] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UsuarioSet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[ActividadAsistente] ([ActividadAsistente_Asistente_Id], [Asistente_Id]) VALUES (3, 5)
GO
SET IDENTITY_INSERT [dbo].[ActividadSet] ON 

GO
INSERT [dbo].[ActividadSet] ([Id], [nombre], [costo], [aula], [tipo], [EventoId], [ComiteId]) VALUES (1, N'Inauguración del evento', 0, N'Explanada', N'Acto protocolario', 1, 13)
GO
INSERT [dbo].[ActividadSet] ([Id], [nombre], [costo], [aula], [tipo], [EventoId], [ComiteId]) VALUES (2, N'Conferencia', 25, N'Sala de conferencias', N'Conferencia', 1, 13)
GO
INSERT [dbo].[ActividadSet] ([Id], [nombre], [costo], [aula], [tipo], [EventoId], [ComiteId]) VALUES (3, N'Problemas al hacer un artículo de física', 0, N'Auditorio', N'Exposicion', 2, 8)
GO
INSERT [dbo].[ActividadSet] ([Id], [nombre], [costo], [aula], [tipo], [EventoId], [ComiteId]) VALUES (4, N'Cierre del evento', 0, N'Sala de conferencias', N'Acto protocolario', 1, 13)
GO
INSERT [dbo].[ActividadSet] ([Id], [nombre], [costo], [aula], [tipo], [EventoId], [ComiteId]) VALUES (5, N'La revolucion de la teoria de los signos', 0, N'Auditorio', N'Exposicion', 2, 8)
GO
SET IDENTITY_INSERT [dbo].[ActividadSet] OFF
GO
SET IDENTITY_INSERT [dbo].[AdscripcionSet] ON 

GO
INSERT [dbo].[AdscripcionSet] ([Id], [ciudad], [direccion], [correoElectronico], [estado], [nombre]) VALUES (1, N'Xalapa', N'Merida #20 Col. Vasconcelos', N'hejogu@uv.mx', N'Veracruz', N'Canal 11 (Canal Once)')
GO
INSERT [dbo].[AdscripcionSet] ([Id], [ciudad], [direccion], [correoElectronico], [estado], [nombre]) VALUES (3, N'Coatepec', N'Menorca #15 Col. Centro', N'contactocecati152@gob.mx', N'Veracruz', N'CECATI COATEPEC')
GO
SET IDENTITY_INSERT [dbo].[AdscripcionSet] OFF
GO
SET IDENTITY_INSERT [dbo].[ArticuloSet] ON 

GO
INSERT [dbo].[ArticuloSet] ([Id], [abstract], [documento], [titulo], [keyword], [status], [ActividadId]) VALUES (1, N'En el presente artículo se exhibiran los resultados de un pedagogo con pocos conocimientos científicos al enfretarse al reto de escribir un artículo científico', N'C:\Users\PUXKA\Desktop\Articulo1.docx', N'Problemas al hacer un artículo de física', N'Fisica, Pedagogía, Método científico', 0, 3)
GO
SET IDENTITY_INSERT [dbo].[ArticuloSet] OFF
GO
SET IDENTITY_INSERT [dbo].[AsistenteSet] ON 

GO
INSERT [dbo].[AsistenteSet] ([Id], [nombre], [apellidoPaterno], [apellidoMaterno], [correoElectronico]) VALUES (5, N'Sandra Michelle', N'Dorado', N'Dante', N'jimo134@outlook.com')
GO
SET IDENTITY_INSERT [dbo].[AsistenteSet] OFF
GO
SET IDENTITY_INSERT [dbo].[AutorArticuloSet] ON 

GO
INSERT [dbo].[AutorArticuloSet] ([Id], [AutorId], [ArticuloId]) VALUES (3, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[AutorArticuloSet] OFF
GO
SET IDENTITY_INSERT [dbo].[AutorSet] ON 

GO
INSERT [dbo].[AutorSet] ([Id], [nombre], [apellidoPaterno], [apellidoMaterno], [correoElectronico], [AdscripcionId]) VALUES (1, N'María José', N'Lares', N'Fernandez', N'majo1991@outlook.com', 1)
GO
INSERT [dbo].[AutorSet] ([Id], [nombre], [apellidoPaterno], [apellidoMaterno], [correoElectronico], [AdscripcionId]) VALUES (2, N'Enrique', N'Gutierrez', N'Durán', N'prof19982@gmail.com', 1)
GO
SET IDENTITY_INSERT [dbo].[AutorSet] OFF
GO
SET IDENTITY_INSERT [dbo].[CalendarioSet] ON 

GO
INSERT [dbo].[CalendarioSet] ([Id], [fecha], [horaInicio], [horaFin], [ActividadId]) VALUES (1, CAST(N'2020-04-01 00:00:00.000' AS DateTime), CAST(N'13:00:00' AS Time), CAST(N'14:00:00' AS Time), 1)
GO
INSERT [dbo].[CalendarioSet] ([Id], [fecha], [horaInicio], [horaFin], [ActividadId]) VALUES (2, CAST(N'2020-04-01 00:00:00.000' AS DateTime), CAST(N'14:00:00' AS Time), CAST(N'16:00:00' AS Time), 2)
GO
INSERT [dbo].[CalendarioSet] ([Id], [fecha], [horaInicio], [horaFin], [ActividadId]) VALUES (3, CAST(N'2020-04-01 00:00:00.000' AS DateTime), CAST(N'16:00:00' AS Time), CAST(N'16:30:00' AS Time), 4)
GO
INSERT [dbo].[CalendarioSet] ([Id], [fecha], [horaInicio], [horaFin], [ActividadId]) VALUES (4, CAST(N'2020-05-01 00:00:00.000' AS DateTime), CAST(N'09:00:00' AS Time), CAST(N'11:00:00' AS Time), 3)
GO
SET IDENTITY_INSERT [dbo].[CalendarioSet] OFF
GO
SET IDENTITY_INSERT [dbo].[ComiteSet] ON 

GO
INSERT [dbo].[ComiteSet] ([Id], [descripcion], [nombre], [EventoId]) VALUES (8, N'Comite encargado del conseguir los premios del evento', N'Comite de premiacion', 2)
GO
INSERT [dbo].[ComiteSet] ([Id], [descripcion], [nombre], [EventoId]) VALUES (11, N'Este comité está encargado de evaluar los artículos que serán presentados en el evento', N'Comité de evaluación', 2)
GO
INSERT [dbo].[ComiteSet] ([Id], [descripcion], [nombre], [EventoId]) VALUES (13, N'Este comité está encargado de promocionar el evento', N'Comité de promoción', 1)
GO
INSERT [dbo].[ComiteSet] ([Id], [descripcion], [nombre], [EventoId]) VALUES (14, N'Este comité está encargado de evaluar los artículos que serán presentados en el evento', N'Comité de evaluación', 1)
GO
SET IDENTITY_INSERT [dbo].[ComiteSet] OFF
GO
SET IDENTITY_INSERT [dbo].[EgresoSet] ON 

GO
INSERT [dbo].[EgresoSet] ([Id], [concepto], [monto], [fecha], [Magistral_Id]) VALUES (10, N'Compra de lápices', 12.5, CAST(N'2020-06-15 00:00:00.000' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[EgresoSet] OFF
GO
SET IDENTITY_INSERT [dbo].[EvaluacionSet] ON 

GO
INSERT [dbo].[EvaluacionSet] ([Id], [calificacion], [descripcion], [fecha], [ArticuloId], [MiembroComite_Id]) VALUES (1, 0, N' ', CAST(N'2020-06-15 02:13:56.470' AS DateTime), 1, 6)
GO
SET IDENTITY_INSERT [dbo].[EvaluacionSet] OFF
GO
SET IDENTITY_INSERT [dbo].[EventoSet] ON 

GO
INSERT [dbo].[EventoSet] ([Id], [nombre], [fechaInicio], [fechaFin], [lugar], [institucionOrganizadora], [EventoPresupuesto_Evento_Id], [OrganizadorId]) VALUES (1, N'Conferencia por la salud', CAST(N'2020-02-01 00:00:00.000' AS DateTime), CAST(N'2020-02-01 00:00:00.000' AS DateTime), N'Facultad de Estadistica e Informatica', N'Licenciatura en Ingeniería de Software', 1, 1)
GO
INSERT [dbo].[EventoSet] ([Id], [nombre], [fechaInicio], [fechaFin], [lugar], [institucionOrganizadora], [EventoPresupuesto_Evento_Id], [OrganizadorId]) VALUES (2, N'Evento de divulgación científica XIV', CAST(N'2020-03-04 00:00:00.000' AS DateTime), CAST(N'2020-03-04 00:00:00.000' AS DateTime), N'FEI', N'Licenciatura en Ingeniería de Software', NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[EventoSet] OFF
GO
SET IDENTITY_INSERT [dbo].[IngresoSet] ON 

GO
INSERT [dbo].[IngresoSet] ([Id], [concepto], [monto], [fecha]) VALUES (1, N'registro de patrocinador', 0, CAST(N'2020-03-04 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[IngresoSet] ([Id], [concepto], [monto], [fecha]) VALUES (2, N'Registro de patrocinador Asadero Cien', 0, CAST(N'2020-03-04 00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[IngresoSet] OFF
GO
SET IDENTITY_INSERT [dbo].[MagistralSet] ON 

GO
INSERT [dbo].[MagistralSet] ([Id], [nombre], [apellidoPaterno], [apellidoMaterno], [AdscripcionId], [ActividadMagistral_Magistral_Id]) VALUES (2, N'Diana', N'González', N'Hernández', 3, 5)
GO
INSERT [dbo].[MagistralSet] ([Id], [nombre], [apellidoPaterno], [apellidoMaterno], [AdscripcionId], [ActividadMagistral_Magistral_Id]) VALUES (3, N'Armado', N'Castañeda', N'Figueroa', 3, 2)
GO
SET IDENTITY_INSERT [dbo].[MagistralSet] OFF
GO
SET IDENTITY_INSERT [dbo].[MaterialSet] ON 

GO
INSERT [dbo].[MaterialSet] ([Id], [tipo], [cantidad], [costo], [ActividadId], [EgresoMaterial_Material_Id]) VALUES (4, N'Escolar', 25, 0.5, NULL, 10)
GO
SET IDENTITY_INSERT [dbo].[MaterialSet] OFF
GO
SET IDENTITY_INSERT [dbo].[MiembroComiteSet] ON 

GO
INSERT [dbo].[MiembroComiteSet] ([Id], [nombre], [apellidoPaterno], [apellidoMaterno], [correoElectronico], [nivelExperiencia], [liderComite], [ComiteId], [evaluador], [idUsuario]) VALUES (1, N'Junipero', N'Veraz', N'Loraz', N'jovelo@uv.mx', N'Licenciatura', 1, 13, 0, 4)
GO
INSERT [dbo].[MiembroComiteSet] ([Id], [nombre], [apellidoPaterno], [apellidoMaterno], [correoElectronico], [nivelExperiencia], [liderComite], [ComiteId], [evaluador], [idUsuario]) VALUES (2, N'Andrea', N'Durian', N'Hernandez', N'aduhe@uv.mx', N'Especialidad', 0, 8, 0, 2)
GO
INSERT [dbo].[MiembroComiteSet] ([Id], [nombre], [apellidoPaterno], [apellidoMaterno], [correoElectronico], [nivelExperiencia], [liderComite], [ComiteId], [evaluador], [idUsuario]) VALUES (5, N'Diana', N'Fonseca', N'Caza', N'difonca@uv.mx', N'Licenciatura', 1, 11, 1, 7)
GO
INSERT [dbo].[MiembroComiteSet] ([Id], [nombre], [apellidoPaterno], [apellidoMaterno], [correoElectronico], [nivelExperiencia], [liderComite], [ComiteId], [evaluador], [idUsuario]) VALUES (6, N'Jose Miguel', N'Martinez', N'Granado', N'jomag@uv.mx', N'Licenciatura', 0, 11, 1, 9)
GO
INSERT [dbo].[MiembroComiteSet] ([Id], [nombre], [apellidoPaterno], [apellidoMaterno], [correoElectronico], [nivelExperiencia], [liderComite], [ComiteId], [evaluador], [idUsuario]) VALUES (7, N'Cande', N'Abarca', N'Martín', N'caabma@uv.mx', N'Licenciatura', 0, 8, 0, 10)
GO
SET IDENTITY_INSERT [dbo].[MiembroComiteSet] OFF
GO
SET IDENTITY_INSERT [dbo].[OrganizadorSet] ON 

GO
INSERT [dbo].[OrganizadorSet] ([Id], [nombre], [apellidoPaterno], [apellidoMaterno], [correoElectronico], [idUsuario]) VALUES (1, N'Grecia', N'Fernandez', N'Torres', N'grefeto@uv.mx', 1)
GO
SET IDENTITY_INSERT [dbo].[OrganizadorSet] OFF
GO
SET IDENTITY_INSERT [dbo].[PatrocinadorSet] ON 

GO
INSERT [dbo].[PatrocinadorSet] ([Id], [nombre], [apellidoPaterno], [apellidoMaterno], [correoElectronico], [empresa], [direccion], [numeroTelefono], [IngresoPatrocinador_Patrocinador_Id]) VALUES (3, N'Jimera', N'Suarez', N'Potrillo', N'patrociniosXalVer@aurrera.com', N'Aurrera', N'Chedrahui Caram #20 Col. Centro', N'8465963', NULL)
GO
SET IDENTITY_INSERT [dbo].[PatrocinadorSet] OFF
GO
SET IDENTITY_INSERT [dbo].[PresupuestoSet] ON 

GO
INSERT [dbo].[PresupuestoSet] ([Id], [concepto], [supuestoPresupuesto]) VALUES (1, N'Presupuesto inicial', 100)
GO
SET IDENTITY_INSERT [dbo].[PresupuestoSet] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuarioSet] ON 

GO
INSERT [dbo].[UsuarioSet] ([Id], [nombreUsuario], [contrasenia]) VALUES (1, N'organizador1', N'88loona')
GO
INSERT [dbo].[UsuarioSet] ([Id], [nombreUsuario], [contrasenia]) VALUES (2, N'andre1988', N'andrea_1988 ')
GO
INSERT [dbo].[UsuarioSet] ([Id], [nombreUsuario], [contrasenia]) VALUES (4, N'miembroL', N'aa')
GO
INSERT [dbo].[UsuarioSet] ([Id], [nombreUsuario], [contrasenia]) VALUES (7, N'miembroLEv2', N'aa')
GO
INSERT [dbo].[UsuarioSet] ([Id], [nombreUsuario], [contrasenia]) VALUES (9, N'jomiM1', N'parjo1')
GO
INSERT [dbo].[UsuarioSet] ([Id], [nombreUsuario], [contrasenia]) VALUES (10, N'petitFR', N'fr1213')
GO
SET IDENTITY_INSERT [dbo].[UsuarioSet] OFF
GO
/****** Object:  Index [IX_FK_ActividadAsistente_Asistente]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ActividadAsistente_Asistente] ON [dbo].[ActividadAsistente]
(
	[Asistente_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ActividadParticipante_Participante]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ActividadParticipante_Participante] ON [dbo].[ActividadParticipante]
(
	[Participante_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ComiteActividad]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ComiteActividad] ON [dbo].[ActividadSet]
(
	[ComiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EventoActividad]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EventoActividad] ON [dbo].[ActividadSet]
(
	[EventoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ActividadArticulo]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ActividadArticulo] ON [dbo].[ArticuloSet]
(
	[ActividadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ArticuloAutorArticulo]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ArticuloAutorArticulo] ON [dbo].[AutorArticuloSet]
(
	[ArticuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_AutorAutorArticulo]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_AutorAutorArticulo] ON [dbo].[AutorArticuloSet]
(
	[AutorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_AdscripcionAutor]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_AdscripcionAutor] ON [dbo].[AutorSet]
(
	[AdscripcionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ActividadCalendario]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ActividadCalendario] ON [dbo].[CalendarioSet]
(
	[ActividadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EventoComite]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EventoComite] ON [dbo].[ComiteSet]
(
	[EventoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EgresoMagistral]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EgresoMagistral] ON [dbo].[EgresoSet]
(
	[Magistral_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ArticuloEvaluacion]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ArticuloEvaluacion] ON [dbo].[EvaluacionSet]
(
	[ArticuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EvaluacionMiembroComite]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EvaluacionMiembroComite] ON [dbo].[EvaluacionSet]
(
	[MiembroComite_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EventoPresupuesto]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EventoPresupuesto] ON [dbo].[EventoSet]
(
	[EventoPresupuesto_Evento_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_OrganizadorEvento]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_OrganizadorEvento] ON [dbo].[EventoSet]
(
	[OrganizadorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ActividadMagistral]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ActividadMagistral] ON [dbo].[MagistralSet]
(
	[ActividadMagistral_Magistral_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_AdscripcionMagistral]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_AdscripcionMagistral] ON [dbo].[MagistralSet]
(
	[AdscripcionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ActividadMaterial]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ActividadMaterial] ON [dbo].[MaterialSet]
(
	[ActividadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EgresoMaterial]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_EgresoMaterial] ON [dbo].[MaterialSet]
(
	[EgresoMaterial_Material_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ComiteMiembroComite]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ComiteMiembroComite] ON [dbo].[MiembroComiteSet]
(
	[ComiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_MiembroComiteUsuario]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_MiembroComiteUsuario] ON [dbo].[MiembroComiteSet]
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_OrganizadorUsuario]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_OrganizadorUsuario] ON [dbo].[OrganizadorSet]
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_AdscripcionParticipante]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_AdscripcionParticipante] ON [dbo].[ParticipanteSet]
(
	[AdscripcionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_IngresoPatrocinador]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_IngresoPatrocinador] ON [dbo].[PatrocinadorSet]
(
	[IngresoPatrocinador_Patrocinador_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_RegistroArticuloAutorArticulo]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_RegistroArticuloAutorArticulo] ON [dbo].[RegistroArticuloSet]
(
	[AutorArticulo_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_RegistroArticuloIngreso]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_RegistroArticuloIngreso] ON [dbo].[RegistroArticuloSet]
(
	[RegistroArticuloIngreso_RegistroArticulo_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ActividadTarea]    Script Date: 13/06/2020 21:18:19 ******/
CREATE NONCLUSTERED INDEX [IX_FK_ActividadTarea] ON [dbo].[TareaSet]
(
	[ActividadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ActividadAsistente]  WITH CHECK ADD  CONSTRAINT [FK_ActividadAsistente_Actividad] FOREIGN KEY([ActividadAsistente_Asistente_Id])
REFERENCES [dbo].[ActividadSet] ([Id])
GO
ALTER TABLE [dbo].[ActividadAsistente] CHECK CONSTRAINT [FK_ActividadAsistente_Actividad]
GO
ALTER TABLE [dbo].[ActividadAsistente]  WITH CHECK ADD  CONSTRAINT [FK_ActividadAsistente_Asistente] FOREIGN KEY([Asistente_Id])
REFERENCES [dbo].[AsistenteSet] ([Id])
GO
ALTER TABLE [dbo].[ActividadAsistente] CHECK CONSTRAINT [FK_ActividadAsistente_Asistente]
GO
ALTER TABLE [dbo].[ActividadParticipante]  WITH CHECK ADD  CONSTRAINT [FK_ActividadParticipante_Actividad] FOREIGN KEY([ActividadParticipante_Participante_Id])
REFERENCES [dbo].[ActividadSet] ([Id])
GO
ALTER TABLE [dbo].[ActividadParticipante] CHECK CONSTRAINT [FK_ActividadParticipante_Actividad]
GO
ALTER TABLE [dbo].[ActividadParticipante]  WITH CHECK ADD  CONSTRAINT [FK_ActividadParticipante_Participante] FOREIGN KEY([Participante_Id])
REFERENCES [dbo].[ParticipanteSet] ([Id])
GO
ALTER TABLE [dbo].[ActividadParticipante] CHECK CONSTRAINT [FK_ActividadParticipante_Participante]
GO
ALTER TABLE [dbo].[ActividadSet]  WITH CHECK ADD  CONSTRAINT [FK_ComiteActividad] FOREIGN KEY([ComiteId])
REFERENCES [dbo].[ComiteSet] ([Id])
GO
ALTER TABLE [dbo].[ActividadSet] CHECK CONSTRAINT [FK_ComiteActividad]
GO
ALTER TABLE [dbo].[ActividadSet]  WITH CHECK ADD  CONSTRAINT [FK_EventoActividad] FOREIGN KEY([EventoId])
REFERENCES [dbo].[EventoSet] ([Id])
GO
ALTER TABLE [dbo].[ActividadSet] CHECK CONSTRAINT [FK_EventoActividad]
GO
ALTER TABLE [dbo].[ArticuloSet]  WITH CHECK ADD  CONSTRAINT [FK_ActividadArticulo] FOREIGN KEY([ActividadId])
REFERENCES [dbo].[ActividadSet] ([Id])
GO
ALTER TABLE [dbo].[ArticuloSet] CHECK CONSTRAINT [FK_ActividadArticulo]
GO
ALTER TABLE [dbo].[AutorArticuloSet]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloAutorArticulo] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[ArticuloSet] ([Id])
GO
ALTER TABLE [dbo].[AutorArticuloSet] CHECK CONSTRAINT [FK_ArticuloAutorArticulo]
GO
ALTER TABLE [dbo].[AutorArticuloSet]  WITH CHECK ADD  CONSTRAINT [FK_AutorAutorArticulo] FOREIGN KEY([AutorId])
REFERENCES [dbo].[AutorSet] ([Id])
GO
ALTER TABLE [dbo].[AutorArticuloSet] CHECK CONSTRAINT [FK_AutorAutorArticulo]
GO
ALTER TABLE [dbo].[AutorSet]  WITH CHECK ADD  CONSTRAINT [FK_AdscripcionAutor] FOREIGN KEY([AdscripcionId])
REFERENCES [dbo].[AdscripcionSet] ([Id])
GO
ALTER TABLE [dbo].[AutorSet] CHECK CONSTRAINT [FK_AdscripcionAutor]
GO
ALTER TABLE [dbo].[CalendarioSet]  WITH CHECK ADD  CONSTRAINT [FK_ActividadCalendario] FOREIGN KEY([ActividadId])
REFERENCES [dbo].[ActividadSet] ([Id])
GO
ALTER TABLE [dbo].[CalendarioSet] CHECK CONSTRAINT [FK_ActividadCalendario]
GO
ALTER TABLE [dbo].[ComiteSet]  WITH CHECK ADD  CONSTRAINT [FK_EventoComite] FOREIGN KEY([EventoId])
REFERENCES [dbo].[EventoSet] ([Id])
GO
ALTER TABLE [dbo].[ComiteSet] CHECK CONSTRAINT [FK_EventoComite]
GO
ALTER TABLE [dbo].[EgresoSet]  WITH CHECK ADD  CONSTRAINT [FK_EgresoMagistral] FOREIGN KEY([Magistral_Id])
REFERENCES [dbo].[MagistralSet] ([Id])
GO
ALTER TABLE [dbo].[EgresoSet] CHECK CONSTRAINT [FK_EgresoMagistral]
GO
ALTER TABLE [dbo].[EvaluacionSet]  WITH CHECK ADD  CONSTRAINT [FK_ArticuloEvaluacion] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[ArticuloSet] ([Id])
GO
ALTER TABLE [dbo].[EvaluacionSet] CHECK CONSTRAINT [FK_ArticuloEvaluacion]
GO
ALTER TABLE [dbo].[EvaluacionSet]  WITH CHECK ADD  CONSTRAINT [FK_EvaluacionMiembroComite] FOREIGN KEY([MiembroComite_Id])
REFERENCES [dbo].[MiembroComiteSet] ([Id])
GO
ALTER TABLE [dbo].[EvaluacionSet] CHECK CONSTRAINT [FK_EvaluacionMiembroComite]
GO
ALTER TABLE [dbo].[EventoSet]  WITH CHECK ADD  CONSTRAINT [FK_EventoPresupuesto] FOREIGN KEY([EventoPresupuesto_Evento_Id])
REFERENCES [dbo].[PresupuestoSet] ([Id])
GO
ALTER TABLE [dbo].[EventoSet] CHECK CONSTRAINT [FK_EventoPresupuesto]
GO
ALTER TABLE [dbo].[EventoSet]  WITH CHECK ADD  CONSTRAINT [FK_OrganizadorEvento] FOREIGN KEY([OrganizadorId])
REFERENCES [dbo].[OrganizadorSet] ([Id])
GO
ALTER TABLE [dbo].[EventoSet] CHECK CONSTRAINT [FK_OrganizadorEvento]
GO
ALTER TABLE [dbo].[MagistralSet]  WITH CHECK ADD  CONSTRAINT [FK_ActividadMagistral] FOREIGN KEY([ActividadMagistral_Magistral_Id])
REFERENCES [dbo].[ActividadSet] ([Id])
GO
ALTER TABLE [dbo].[MagistralSet] CHECK CONSTRAINT [FK_ActividadMagistral]
GO
ALTER TABLE [dbo].[MagistralSet]  WITH CHECK ADD  CONSTRAINT [FK_AdscripcionMagistral] FOREIGN KEY([AdscripcionId])
REFERENCES [dbo].[AdscripcionSet] ([Id])
GO
ALTER TABLE [dbo].[MagistralSet] CHECK CONSTRAINT [FK_AdscripcionMagistral]
GO
ALTER TABLE [dbo].[MaterialSet]  WITH CHECK ADD  CONSTRAINT [FK_ActividadMaterial] FOREIGN KEY([ActividadId])
REFERENCES [dbo].[ActividadSet] ([Id])
GO
ALTER TABLE [dbo].[MaterialSet] CHECK CONSTRAINT [FK_ActividadMaterial]
GO
ALTER TABLE [dbo].[MaterialSet]  WITH CHECK ADD  CONSTRAINT [FK_EgresoMaterial] FOREIGN KEY([EgresoMaterial_Material_Id])
REFERENCES [dbo].[EgresoSet] ([Id])
GO
ALTER TABLE [dbo].[MaterialSet] CHECK CONSTRAINT [FK_EgresoMaterial]
GO
ALTER TABLE [dbo].[MiembroComiteSet]  WITH CHECK ADD  CONSTRAINT [FK_ComiteMiembroComite] FOREIGN KEY([ComiteId])
REFERENCES [dbo].[ComiteSet] ([Id])
GO
ALTER TABLE [dbo].[MiembroComiteSet] CHECK CONSTRAINT [FK_ComiteMiembroComite]
GO
ALTER TABLE [dbo].[MiembroComiteSet]  WITH CHECK ADD  CONSTRAINT [FK_MiembroComiteUsuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[UsuarioSet] ([Id])
GO
ALTER TABLE [dbo].[MiembroComiteSet] CHECK CONSTRAINT [FK_MiembroComiteUsuario]
GO
ALTER TABLE [dbo].[OrganizadorSet]  WITH CHECK ADD  CONSTRAINT [FK_OrganizadorUsuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[UsuarioSet] ([Id])
GO
ALTER TABLE [dbo].[OrganizadorSet] CHECK CONSTRAINT [FK_OrganizadorUsuario]
GO
ALTER TABLE [dbo].[ParticipanteSet]  WITH CHECK ADD  CONSTRAINT [FK_AdscripcionParticipante] FOREIGN KEY([AdscripcionId])
REFERENCES [dbo].[AdscripcionSet] ([Id])
GO
ALTER TABLE [dbo].[ParticipanteSet] CHECK CONSTRAINT [FK_AdscripcionParticipante]
GO
ALTER TABLE [dbo].[PatrocinadorSet]  WITH CHECK ADD  CONSTRAINT [FK_IngresoPatrocinador] FOREIGN KEY([IngresoPatrocinador_Patrocinador_Id])
REFERENCES [dbo].[IngresoSet] ([Id])
GO
ALTER TABLE [dbo].[PatrocinadorSet] CHECK CONSTRAINT [FK_IngresoPatrocinador]
GO
ALTER TABLE [dbo].[RegistroArticuloSet]  WITH CHECK ADD  CONSTRAINT [FK_RegistroArticuloAutorArticulo] FOREIGN KEY([AutorArticulo_Id])
REFERENCES [dbo].[AutorArticuloSet] ([Id])
GO
ALTER TABLE [dbo].[RegistroArticuloSet] CHECK CONSTRAINT [FK_RegistroArticuloAutorArticulo]
GO
ALTER TABLE [dbo].[RegistroArticuloSet]  WITH CHECK ADD  CONSTRAINT [FK_RegistroArticuloIngreso] FOREIGN KEY([RegistroArticuloIngreso_RegistroArticulo_Id])
REFERENCES [dbo].[IngresoSet] ([Id])
GO
ALTER TABLE [dbo].[RegistroArticuloSet] CHECK CONSTRAINT [FK_RegistroArticuloIngreso]
GO
ALTER TABLE [dbo].[TareaSet]  WITH CHECK ADD  CONSTRAINT [FK_ActividadTarea] FOREIGN KEY([ActividadId])
REFERENCES [dbo].[ActividadSet] ([Id])
GO
ALTER TABLE [dbo].[TareaSet] CHECK CONSTRAINT [FK_ActividadTarea]
GO
USE [master]
GO
ALTER DATABASE [SGEA] SET  READ_WRITE 
GO

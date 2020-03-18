
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/18/2020 10:54:11
-- Generated from EDMX file: C:\Users\robe_\source\repos\DS\SGEA-DS\SGEA-DS\Datos\Data.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SGEA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RegistroArticuloAutor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroArticuloSet] DROP CONSTRAINT [FK_RegistroArticuloAutor];
GO
IF OBJECT_ID(N'[dbo].[FK_AdscripcionAutor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AutorSet] DROP CONSTRAINT [FK_AdscripcionAutor];
GO
IF OBJECT_ID(N'[dbo].[FK_AdscripcionMagistral]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MagistralSet] DROP CONSTRAINT [FK_AdscripcionMagistral];
GO
IF OBJECT_ID(N'[dbo].[FK_MagistralEgreso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EgresoSet] DROP CONSTRAINT [FK_MagistralEgreso];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloEvaluacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EvaluacionSet] DROP CONSTRAINT [FK_ArticuloEvaluacion];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticuloRegistroArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroArticuloSet] DROP CONSTRAINT [FK_ArticuloRegistroArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_ParticipanteAdscripcion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdscripcionSet] DROP CONSTRAINT [FK_ParticipanteAdscripcion];
GO
IF OBJECT_ID(N'[dbo].[FK_ParticipanteCalendario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CalendarioSet] DROP CONSTRAINT [FK_ParticipanteCalendario];
GO
IF OBJECT_ID(N'[dbo].[FK_MaterialEgreso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EgresoSet] DROP CONSTRAINT [FK_MaterialEgreso];
GO
IF OBJECT_ID(N'[dbo].[FK_MiembroComiteEvaluacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EvaluacionSet] DROP CONSTRAINT [FK_MiembroComiteEvaluacion];
GO
IF OBJECT_ID(N'[dbo].[FK_ComiteMiembroComite]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MiembroComiteSet] DROP CONSTRAINT [FK_ComiteMiembroComite];
GO
IF OBJECT_ID(N'[dbo].[FK_EventoComite]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComiteSet] DROP CONSTRAINT [FK_EventoComite];
GO
IF OBJECT_ID(N'[dbo].[FK_ActrividadParticipante_Actrividad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActrividadParticipante] DROP CONSTRAINT [FK_ActrividadParticipante_Actrividad];
GO
IF OBJECT_ID(N'[dbo].[FK_ActrividadParticipante_Participante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActrividadParticipante] DROP CONSTRAINT [FK_ActrividadParticipante_Participante];
GO
IF OBJECT_ID(N'[dbo].[FK_ActrividadArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArticuloSet] DROP CONSTRAINT [FK_ActrividadArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_ComiteActrividad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActrividadSet] DROP CONSTRAINT [FK_ComiteActrividad];
GO
IF OBJECT_ID(N'[dbo].[FK_EventoActrividad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActrividadSet] DROP CONSTRAINT [FK_EventoActrividad];
GO
IF OBJECT_ID(N'[dbo].[FK_ActrividadMaterial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MaterialSet] DROP CONSTRAINT [FK_ActrividadMaterial];
GO
IF OBJECT_ID(N'[dbo].[FK_ActrividadMagistral]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActrividadSet] DROP CONSTRAINT [FK_ActrividadMagistral];
GO
IF OBJECT_ID(N'[dbo].[FK_PresupuestoEvento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PresupuestoSet] DROP CONSTRAINT [FK_PresupuestoEvento];
GO
IF OBJECT_ID(N'[dbo].[FK_ActrividadTarea]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TareaSet] DROP CONSTRAINT [FK_ActrividadTarea];
GO
IF OBJECT_ID(N'[dbo].[FK_ActrividadIngreso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IngresoSet] DROP CONSTRAINT [FK_ActrividadIngreso];
GO
IF OBJECT_ID(N'[dbo].[FK_AsistenteIngreso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IngresoSet] DROP CONSTRAINT [FK_AsistenteIngreso];
GO
IF OBJECT_ID(N'[dbo].[FK_IngresoRegistroArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegistroArticuloSet] DROP CONSTRAINT [FK_IngresoRegistroArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_PatrocinadorIngreso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PatrocinadorSet] DROP CONSTRAINT [FK_PatrocinadorIngreso];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[RegistroArticuloSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegistroArticuloSet];
GO
IF OBJECT_ID(N'[dbo].[AutorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutorSet];
GO
IF OBJECT_ID(N'[dbo].[AdscripcionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdscripcionSet];
GO
IF OBJECT_ID(N'[dbo].[MagistralSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MagistralSet];
GO
IF OBJECT_ID(N'[dbo].[EgresoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EgresoSet];
GO
IF OBJECT_ID(N'[dbo].[EvaluacionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EvaluacionSet];
GO
IF OBJECT_ID(N'[dbo].[ArticuloSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArticuloSet];
GO
IF OBJECT_ID(N'[dbo].[ParticipanteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParticipanteSet];
GO
IF OBJECT_ID(N'[dbo].[CalendarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalendarioSet];
GO
IF OBJECT_ID(N'[dbo].[MaterialSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MaterialSet];
GO
IF OBJECT_ID(N'[dbo].[MiembroComiteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MiembroComiteSet];
GO
IF OBJECT_ID(N'[dbo].[ComiteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComiteSet];
GO
IF OBJECT_ID(N'[dbo].[EventoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventoSet];
GO
IF OBJECT_ID(N'[dbo].[ActrividadSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActrividadSet];
GO
IF OBJECT_ID(N'[dbo].[AsistenteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AsistenteSet];
GO
IF OBJECT_ID(N'[dbo].[PresupuestoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PresupuestoSet];
GO
IF OBJECT_ID(N'[dbo].[TareaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TareaSet];
GO
IF OBJECT_ID(N'[dbo].[IngresoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IngresoSet];
GO
IF OBJECT_ID(N'[dbo].[PatrocinadorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PatrocinadorSet];
GO
IF OBJECT_ID(N'[dbo].[ActrividadParticipante]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActrividadParticipante];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'RegistroArticuloSet'
CREATE TABLE [dbo].[RegistroArticuloSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [comprobantePago] nvarchar(max)  NOT NULL,
    [fecha] datetime  NOT NULL,
    [hora] time  NOT NULL,
    [Pago] float  NOT NULL,
    [ArticuloId] int  NOT NULL,
    [IngresoId] int  NOT NULL,
    [Autor_Id] int  NOT NULL
);
GO

-- Creating table 'AutorSet'
CREATE TABLE [dbo].[AutorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [apellidoMaterno] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [correoElectronico] nvarchar(max)  NOT NULL,
    [AdscripcionId] int  NOT NULL
);
GO

-- Creating table 'AdscripcionSet'
CREATE TABLE [dbo].[AdscripcionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ciudad] nvarchar(max)  NOT NULL,
    [direccion] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL,
    [estado] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [ParticipanteId] int  NOT NULL
);
GO

-- Creating table 'MagistralSet'
CREATE TABLE [dbo].[MagistralSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [apellidoMaterno] nvarchar(max)  NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [AdscripcionId] int  NOT NULL
);
GO

-- Creating table 'EgresoSet'
CREATE TABLE [dbo].[EgresoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [concepto] nvarchar(max)  NOT NULL,
    [fecha] datetime  NOT NULL,
    [monto] float  NOT NULL,
    [MagistralId] int  NOT NULL,
    [Material_Id] int  NOT NULL
);
GO

-- Creating table 'EvaluacionSet'
CREATE TABLE [dbo].[EvaluacionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [calificacion] float  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [fecha] datetime  NOT NULL,
    [ArticuloId] int  NOT NULL,
    [MiembroComiteId] int  NOT NULL
);
GO

-- Creating table 'ArticuloSet'
CREATE TABLE [dbo].[ArticuloSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [abstract] nvarchar(max)  NOT NULL,
    [documento] nvarchar(max)  NOT NULL,
    [keyword] nvarchar(max)  NOT NULL,
    [estatus] bit  NOT NULL,
    [titulo] nvarchar(max)  NOT NULL,
    [Actrividad_Id] int  NULL
);
GO

-- Creating table 'ParticipanteSet'
CREATE TABLE [dbo].[ParticipanteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [apellidoMaterno] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [titulo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CalendarioSet'
CREATE TABLE [dbo].[CalendarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fecha] datetime  NOT NULL,
    [horaInicio] time  NOT NULL,
    [horaFin] time  NOT NULL,
    [ParticipanteId] int  NOT NULL
);
GO

-- Creating table 'MaterialSet'
CREATE TABLE [dbo].[MaterialSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [cantidad] int  NOT NULL,
    [costo] float  NOT NULL,
    [tipo] nvarchar(max)  NOT NULL,
    [ActrividadId] int  NOT NULL
);
GO

-- Creating table 'MiembroComiteSet'
CREATE TABLE [dbo].[MiembroComiteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [apellidoMaterno] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [correoElectronico] nvarchar(max)  NOT NULL,
    [liderComite] bit  NOT NULL,
    [nivelExperiencia] int  NOT NULL,
    [ComiteId] int  NOT NULL
);
GO

-- Creating table 'ComiteSet'
CREATE TABLE [dbo].[ComiteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [EventoId] int  NOT NULL
);
GO

-- Creating table 'EventoSet'
CREATE TABLE [dbo].[EventoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fechaInicio] datetime  NOT NULL,
    [fechaFin] datetime  NOT NULL,
    [institucionOrganizadora] nvarchar(max)  NOT NULL,
    [lugar] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ActrividadSet'
CREATE TABLE [dbo].[ActrividadSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [aula] nvarchar(max)  NOT NULL,
    [costo] float  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [tipo] nvarchar(max)  NOT NULL,
    [ComiteId] int  NOT NULL,
    [EventoId] int  NOT NULL,
    [Magistral_Id] int  NOT NULL
);
GO

-- Creating table 'AsistenteSet'
CREATE TABLE [dbo].[AsistenteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [apellidoMaterno] nvarchar(max)  NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [correoElectronico] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PresupuestoSet'
CREATE TABLE [dbo].[PresupuestoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [concepto] nvarchar(max)  NOT NULL,
    [supuestoPresupuesto] float  NOT NULL,
    [Evento_Id] int  NOT NULL
);
GO

-- Creating table 'TareaSet'
CREATE TABLE [dbo].[TareaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [ActrividadId] int  NOT NULL
);
GO

-- Creating table 'IngresoSet'
CREATE TABLE [dbo].[IngresoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [concepto] nvarchar(max)  NOT NULL,
    [fecha] datetime  NOT NULL,
    [monto] float  NOT NULL,
    [ActrividadId] int  NOT NULL,
    [AsistenteId] int  NOT NULL
);
GO

-- Creating table 'PatrocinadorSet'
CREATE TABLE [dbo].[PatrocinadorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [apellidoMaterno] nvarchar(max)  NOT NULL,
    [correoElectronico] nvarchar(max)  NOT NULL,
    [direccion] nvarchar(max)  NOT NULL,
    [empresa] nvarchar(max)  NOT NULL,
    [numeroTelefono] int  NOT NULL,
    [Ingreso_Id] int  NOT NULL
);
GO

-- Creating table 'ActrividadParticipante'
CREATE TABLE [dbo].[ActrividadParticipante] (
    [Actrividad_Id] int  NOT NULL,
    [Participante_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'RegistroArticuloSet'
ALTER TABLE [dbo].[RegistroArticuloSet]
ADD CONSTRAINT [PK_RegistroArticuloSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AutorSet'
ALTER TABLE [dbo].[AutorSet]
ADD CONSTRAINT [PK_AutorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdscripcionSet'
ALTER TABLE [dbo].[AdscripcionSet]
ADD CONSTRAINT [PK_AdscripcionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MagistralSet'
ALTER TABLE [dbo].[MagistralSet]
ADD CONSTRAINT [PK_MagistralSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EgresoSet'
ALTER TABLE [dbo].[EgresoSet]
ADD CONSTRAINT [PK_EgresoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EvaluacionSet'
ALTER TABLE [dbo].[EvaluacionSet]
ADD CONSTRAINT [PK_EvaluacionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ArticuloSet'
ALTER TABLE [dbo].[ArticuloSet]
ADD CONSTRAINT [PK_ArticuloSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ParticipanteSet'
ALTER TABLE [dbo].[ParticipanteSet]
ADD CONSTRAINT [PK_ParticipanteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CalendarioSet'
ALTER TABLE [dbo].[CalendarioSet]
ADD CONSTRAINT [PK_CalendarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MaterialSet'
ALTER TABLE [dbo].[MaterialSet]
ADD CONSTRAINT [PK_MaterialSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MiembroComiteSet'
ALTER TABLE [dbo].[MiembroComiteSet]
ADD CONSTRAINT [PK_MiembroComiteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComiteSet'
ALTER TABLE [dbo].[ComiteSet]
ADD CONSTRAINT [PK_ComiteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EventoSet'
ALTER TABLE [dbo].[EventoSet]
ADD CONSTRAINT [PK_EventoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ActrividadSet'
ALTER TABLE [dbo].[ActrividadSet]
ADD CONSTRAINT [PK_ActrividadSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AsistenteSet'
ALTER TABLE [dbo].[AsistenteSet]
ADD CONSTRAINT [PK_AsistenteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PresupuestoSet'
ALTER TABLE [dbo].[PresupuestoSet]
ADD CONSTRAINT [PK_PresupuestoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TareaSet'
ALTER TABLE [dbo].[TareaSet]
ADD CONSTRAINT [PK_TareaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'IngresoSet'
ALTER TABLE [dbo].[IngresoSet]
ADD CONSTRAINT [PK_IngresoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PatrocinadorSet'
ALTER TABLE [dbo].[PatrocinadorSet]
ADD CONSTRAINT [PK_PatrocinadorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Actrividad_Id], [Participante_Id] in table 'ActrividadParticipante'
ALTER TABLE [dbo].[ActrividadParticipante]
ADD CONSTRAINT [PK_ActrividadParticipante]
    PRIMARY KEY CLUSTERED ([Actrividad_Id], [Participante_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Autor_Id] in table 'RegistroArticuloSet'
ALTER TABLE [dbo].[RegistroArticuloSet]
ADD CONSTRAINT [FK_RegistroArticuloAutor]
    FOREIGN KEY ([Autor_Id])
    REFERENCES [dbo].[AutorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegistroArticuloAutor'
CREATE INDEX [IX_FK_RegistroArticuloAutor]
ON [dbo].[RegistroArticuloSet]
    ([Autor_Id]);
GO

-- Creating foreign key on [AdscripcionId] in table 'AutorSet'
ALTER TABLE [dbo].[AutorSet]
ADD CONSTRAINT [FK_AdscripcionAutor]
    FOREIGN KEY ([AdscripcionId])
    REFERENCES [dbo].[AdscripcionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdscripcionAutor'
CREATE INDEX [IX_FK_AdscripcionAutor]
ON [dbo].[AutorSet]
    ([AdscripcionId]);
GO

-- Creating foreign key on [AdscripcionId] in table 'MagistralSet'
ALTER TABLE [dbo].[MagistralSet]
ADD CONSTRAINT [FK_AdscripcionMagistral]
    FOREIGN KEY ([AdscripcionId])
    REFERENCES [dbo].[AdscripcionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdscripcionMagistral'
CREATE INDEX [IX_FK_AdscripcionMagistral]
ON [dbo].[MagistralSet]
    ([AdscripcionId]);
GO

-- Creating foreign key on [MagistralId] in table 'EgresoSet'
ALTER TABLE [dbo].[EgresoSet]
ADD CONSTRAINT [FK_MagistralEgreso]
    FOREIGN KEY ([MagistralId])
    REFERENCES [dbo].[MagistralSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MagistralEgreso'
CREATE INDEX [IX_FK_MagistralEgreso]
ON [dbo].[EgresoSet]
    ([MagistralId]);
GO

-- Creating foreign key on [ArticuloId] in table 'EvaluacionSet'
ALTER TABLE [dbo].[EvaluacionSet]
ADD CONSTRAINT [FK_ArticuloEvaluacion]
    FOREIGN KEY ([ArticuloId])
    REFERENCES [dbo].[ArticuloSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloEvaluacion'
CREATE INDEX [IX_FK_ArticuloEvaluacion]
ON [dbo].[EvaluacionSet]
    ([ArticuloId]);
GO

-- Creating foreign key on [ArticuloId] in table 'RegistroArticuloSet'
ALTER TABLE [dbo].[RegistroArticuloSet]
ADD CONSTRAINT [FK_ArticuloRegistroArticulo]
    FOREIGN KEY ([ArticuloId])
    REFERENCES [dbo].[ArticuloSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloRegistroArticulo'
CREATE INDEX [IX_FK_ArticuloRegistroArticulo]
ON [dbo].[RegistroArticuloSet]
    ([ArticuloId]);
GO

-- Creating foreign key on [ParticipanteId] in table 'AdscripcionSet'
ALTER TABLE [dbo].[AdscripcionSet]
ADD CONSTRAINT [FK_ParticipanteAdscripcion]
    FOREIGN KEY ([ParticipanteId])
    REFERENCES [dbo].[ParticipanteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParticipanteAdscripcion'
CREATE INDEX [IX_FK_ParticipanteAdscripcion]
ON [dbo].[AdscripcionSet]
    ([ParticipanteId]);
GO

-- Creating foreign key on [ParticipanteId] in table 'CalendarioSet'
ALTER TABLE [dbo].[CalendarioSet]
ADD CONSTRAINT [FK_ParticipanteCalendario]
    FOREIGN KEY ([ParticipanteId])
    REFERENCES [dbo].[ParticipanteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParticipanteCalendario'
CREATE INDEX [IX_FK_ParticipanteCalendario]
ON [dbo].[CalendarioSet]
    ([ParticipanteId]);
GO

-- Creating foreign key on [Material_Id] in table 'EgresoSet'
ALTER TABLE [dbo].[EgresoSet]
ADD CONSTRAINT [FK_MaterialEgreso]
    FOREIGN KEY ([Material_Id])
    REFERENCES [dbo].[MaterialSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MaterialEgreso'
CREATE INDEX [IX_FK_MaterialEgreso]
ON [dbo].[EgresoSet]
    ([Material_Id]);
GO

-- Creating foreign key on [MiembroComiteId] in table 'EvaluacionSet'
ALTER TABLE [dbo].[EvaluacionSet]
ADD CONSTRAINT [FK_MiembroComiteEvaluacion]
    FOREIGN KEY ([MiembroComiteId])
    REFERENCES [dbo].[MiembroComiteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MiembroComiteEvaluacion'
CREATE INDEX [IX_FK_MiembroComiteEvaluacion]
ON [dbo].[EvaluacionSet]
    ([MiembroComiteId]);
GO

-- Creating foreign key on [ComiteId] in table 'MiembroComiteSet'
ALTER TABLE [dbo].[MiembroComiteSet]
ADD CONSTRAINT [FK_ComiteMiembroComite]
    FOREIGN KEY ([ComiteId])
    REFERENCES [dbo].[ComiteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComiteMiembroComite'
CREATE INDEX [IX_FK_ComiteMiembroComite]
ON [dbo].[MiembroComiteSet]
    ([ComiteId]);
GO

-- Creating foreign key on [EventoId] in table 'ComiteSet'
ALTER TABLE [dbo].[ComiteSet]
ADD CONSTRAINT [FK_EventoComite]
    FOREIGN KEY ([EventoId])
    REFERENCES [dbo].[EventoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventoComite'
CREATE INDEX [IX_FK_EventoComite]
ON [dbo].[ComiteSet]
    ([EventoId]);
GO

-- Creating foreign key on [Actrividad_Id] in table 'ActrividadParticipante'
ALTER TABLE [dbo].[ActrividadParticipante]
ADD CONSTRAINT [FK_ActrividadParticipante_Actrividad]
    FOREIGN KEY ([Actrividad_Id])
    REFERENCES [dbo].[ActrividadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Participante_Id] in table 'ActrividadParticipante'
ALTER TABLE [dbo].[ActrividadParticipante]
ADD CONSTRAINT [FK_ActrividadParticipante_Participante]
    FOREIGN KEY ([Participante_Id])
    REFERENCES [dbo].[ParticipanteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActrividadParticipante_Participante'
CREATE INDEX [IX_FK_ActrividadParticipante_Participante]
ON [dbo].[ActrividadParticipante]
    ([Participante_Id]);
GO

-- Creating foreign key on [Actrividad_Id] in table 'ArticuloSet'
ALTER TABLE [dbo].[ArticuloSet]
ADD CONSTRAINT [FK_ActrividadArticulo]
    FOREIGN KEY ([Actrividad_Id])
    REFERENCES [dbo].[ActrividadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActrividadArticulo'
CREATE INDEX [IX_FK_ActrividadArticulo]
ON [dbo].[ArticuloSet]
    ([Actrividad_Id]);
GO

-- Creating foreign key on [ComiteId] in table 'ActrividadSet'
ALTER TABLE [dbo].[ActrividadSet]
ADD CONSTRAINT [FK_ComiteActrividad]
    FOREIGN KEY ([ComiteId])
    REFERENCES [dbo].[ComiteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComiteActrividad'
CREATE INDEX [IX_FK_ComiteActrividad]
ON [dbo].[ActrividadSet]
    ([ComiteId]);
GO

-- Creating foreign key on [EventoId] in table 'ActrividadSet'
ALTER TABLE [dbo].[ActrividadSet]
ADD CONSTRAINT [FK_EventoActrividad]
    FOREIGN KEY ([EventoId])
    REFERENCES [dbo].[EventoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventoActrividad'
CREATE INDEX [IX_FK_EventoActrividad]
ON [dbo].[ActrividadSet]
    ([EventoId]);
GO

-- Creating foreign key on [ActrividadId] in table 'MaterialSet'
ALTER TABLE [dbo].[MaterialSet]
ADD CONSTRAINT [FK_ActrividadMaterial]
    FOREIGN KEY ([ActrividadId])
    REFERENCES [dbo].[ActrividadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActrividadMaterial'
CREATE INDEX [IX_FK_ActrividadMaterial]
ON [dbo].[MaterialSet]
    ([ActrividadId]);
GO

-- Creating foreign key on [Magistral_Id] in table 'ActrividadSet'
ALTER TABLE [dbo].[ActrividadSet]
ADD CONSTRAINT [FK_ActrividadMagistral]
    FOREIGN KEY ([Magistral_Id])
    REFERENCES [dbo].[MagistralSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActrividadMagistral'
CREATE INDEX [IX_FK_ActrividadMagistral]
ON [dbo].[ActrividadSet]
    ([Magistral_Id]);
GO

-- Creating foreign key on [Evento_Id] in table 'PresupuestoSet'
ALTER TABLE [dbo].[PresupuestoSet]
ADD CONSTRAINT [FK_PresupuestoEvento]
    FOREIGN KEY ([Evento_Id])
    REFERENCES [dbo].[EventoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PresupuestoEvento'
CREATE INDEX [IX_FK_PresupuestoEvento]
ON [dbo].[PresupuestoSet]
    ([Evento_Id]);
GO

-- Creating foreign key on [ActrividadId] in table 'TareaSet'
ALTER TABLE [dbo].[TareaSet]
ADD CONSTRAINT [FK_ActrividadTarea]
    FOREIGN KEY ([ActrividadId])
    REFERENCES [dbo].[ActrividadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActrividadTarea'
CREATE INDEX [IX_FK_ActrividadTarea]
ON [dbo].[TareaSet]
    ([ActrividadId]);
GO

-- Creating foreign key on [ActrividadId] in table 'IngresoSet'
ALTER TABLE [dbo].[IngresoSet]
ADD CONSTRAINT [FK_ActrividadIngreso]
    FOREIGN KEY ([ActrividadId])
    REFERENCES [dbo].[ActrividadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActrividadIngreso'
CREATE INDEX [IX_FK_ActrividadIngreso]
ON [dbo].[IngresoSet]
    ([ActrividadId]);
GO

-- Creating foreign key on [AsistenteId] in table 'IngresoSet'
ALTER TABLE [dbo].[IngresoSet]
ADD CONSTRAINT [FK_AsistenteIngreso]
    FOREIGN KEY ([AsistenteId])
    REFERENCES [dbo].[AsistenteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AsistenteIngreso'
CREATE INDEX [IX_FK_AsistenteIngreso]
ON [dbo].[IngresoSet]
    ([AsistenteId]);
GO

-- Creating foreign key on [IngresoId] in table 'RegistroArticuloSet'
ALTER TABLE [dbo].[RegistroArticuloSet]
ADD CONSTRAINT [FK_IngresoRegistroArticulo]
    FOREIGN KEY ([IngresoId])
    REFERENCES [dbo].[IngresoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IngresoRegistroArticulo'
CREATE INDEX [IX_FK_IngresoRegistroArticulo]
ON [dbo].[RegistroArticuloSet]
    ([IngresoId]);
GO

-- Creating foreign key on [Ingreso_Id] in table 'PatrocinadorSet'
ALTER TABLE [dbo].[PatrocinadorSet]
ADD CONSTRAINT [FK_PatrocinadorIngreso]
    FOREIGN KEY ([Ingreso_Id])
    REFERENCES [dbo].[IngresoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatrocinadorIngreso'
CREATE INDEX [IX_FK_PatrocinadorIngreso]
ON [dbo].[PatrocinadorSet]
    ([Ingreso_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
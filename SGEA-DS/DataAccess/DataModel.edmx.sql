
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/21/2020 20:26:12
-- Generated from EDMX file: C:\Users\Saarayim\Desktop\Sexto semestre\Desarrollo de software\SGEA\SGEA-DS\DataAccess\DataModel.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ActividadSet'
CREATE TABLE [dbo].[ActividadSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [costo] float  NOT NULL,
    [aula] nvarchar(max)  NOT NULL,
    [tipo] nvarchar(max)  NOT NULL,
    [EventoId] int  NOT NULL,
    [ComiteId] int  NOT NULL
);
GO

-- Creating table 'ArticuloSet'
CREATE TABLE [dbo].[ArticuloSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [abstract] nvarchar(max)  NOT NULL,
    [documento] tinyint  NOT NULL,
    [ActividadArticulo_Articulo_Id] int  NOT NULL
);
GO

-- Creating table 'RegistroArticuloSet'
CREATE TABLE [dbo].[RegistroArticuloSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [comprobantePago] tinyint  NOT NULL,
    [fecha] datetime  NOT NULL,
    [hora] time  NOT NULL,
    [cantidadPago] float  NOT NULL,
    [AutorId] int  NOT NULL,
    [Articulo_Id] int  NOT NULL,
    [RegistroArticuloIngreso_RegistroArticulo_Id] int  NOT NULL
);
GO

-- Creating table 'AdscripcionSet'
CREATE TABLE [dbo].[AdscripcionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ciudad] nvarchar(max)  NOT NULL,
    [direccion] nvarchar(max)  NOT NULL,
    [correoElectronico] nvarchar(max)  NOT NULL,
    [estado] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AutorSet'
CREATE TABLE [dbo].[AutorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [apellidoMaterno] nvarchar(max)  NULL,
    [correoElectronico] nvarchar(max)  NOT NULL,
    [AdscripcionId] int  NOT NULL
);
GO

-- Creating table 'EvaluacionSet'
CREATE TABLE [dbo].[EvaluacionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [calificacion] int  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [fecha] datetime  NOT NULL,
    [ArticuloId] int  NOT NULL,
    [MiembroComite_Id] int  NOT NULL
);
GO

-- Creating table 'MiembroComiteSet'
CREATE TABLE [dbo].[MiembroComiteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [apellidoMaterno] nvarchar(max)  NULL,
    [correoElectronico] nvarchar(max)  NOT NULL,
    [nivelExperiencia] nvarchar(max)  NOT NULL,
    [liderComite] bit  NOT NULL,
    [ComiteId] int  NOT NULL,
    [nombreUsuario] nvarchar(max)  NOT NULL,
    [contrasenia] nvarchar(max)  NOT NULL,
    [evaluador] bit  NOT NULL
);
GO

-- Creating table 'CalendarioSet'
CREATE TABLE [dbo].[CalendarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [fecha] datetime  NOT NULL,
    [horaInicio] time  NOT NULL,
    [horaFin] time  NOT NULL,
    [ActividadId] int  NOT NULL
);
GO

-- Creating table 'MagistralSet'
CREATE TABLE [dbo].[MagistralSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [apellidoMaterno] nvarchar(max)  NULL,
    [AdscripcionId] int  NOT NULL,
    [ActividadMagistral_Magistral_Id] int  NOT NULL
);
GO

-- Creating table 'ParticipanteSet'
CREATE TABLE [dbo].[ParticipanteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [apellidoMaterno] nvarchar(max)  NULL,
    [titulo] nvarchar(max)  NOT NULL,
    [AdscripcionId] int  NOT NULL
);
GO

-- Creating table 'EgresoSet'
CREATE TABLE [dbo].[EgresoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [concepto] nvarchar(max)  NOT NULL,
    [monto] float  NOT NULL,
    [fecha] datetime  NOT NULL,
    [Magistral_Id] int  NULL
);
GO

-- Creating table 'MaterialSet'
CREATE TABLE [dbo].[MaterialSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tipo] nvarchar(max)  NOT NULL,
    [cantidad] int  NOT NULL,
    [costo] float  NOT NULL,
    [ActividadId] int  NOT NULL,
    [EgresoMaterial_Material_Id] int  NOT NULL
);
GO

-- Creating table 'IngresoSet'
CREATE TABLE [dbo].[IngresoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [concepto] nvarchar(max)  NOT NULL,
    [monto] float  NOT NULL,
    [fecha] datetime  NOT NULL
);
GO

-- Creating table 'PatrocinadorSet'
CREATE TABLE [dbo].[PatrocinadorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [apellidoMaterno] nvarchar(max)  NOT NULL,
    [correoElectronico] nvarchar(max)  NOT NULL,
    [empresa] nvarchar(max)  NOT NULL,
    [direccion] nvarchar(max)  NOT NULL,
    [numeroTelefono] nvarchar(max)  NOT NULL,
    [IngresoPatrocinador_Patrocinador_Id] int  NOT NULL
);
GO

-- Creating table 'EventoSet'
CREATE TABLE [dbo].[EventoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [fechaInicio] datetime  NOT NULL,
    [fechaFin] datetime  NOT NULL,
    [lugar] nvarchar(max)  NOT NULL,
    [institucionOrganizadora] nvarchar(max)  NOT NULL,
    [EventoPresupuesto_Evento_Id] int  NOT NULL
);
GO

-- Creating table 'PresupuestoSet'
CREATE TABLE [dbo].[PresupuestoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [concepto] nvarchar(max)  NOT NULL,
    [supuestoPresupuesto] float  NOT NULL
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

-- Creating table 'AsistenteSet'
CREATE TABLE [dbo].[AsistenteSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [apellidoMaterno] nvarchar(max)  NULL,
    [correoElectronico] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TareaSet'
CREATE TABLE [dbo].[TareaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [ActividadId] int  NOT NULL
);
GO

-- Creating table 'OrganizadorSet'
CREATE TABLE [dbo].[OrganizadorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombreUsuario] nvarchar(max)  NOT NULL,
    [contrasenia] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ActividadParticipante'
CREATE TABLE [dbo].[ActividadParticipante] (
    [ActividadParticipante_Participante_Id] int  NOT NULL,
    [Participante_Id] int  NOT NULL
);
GO

-- Creating table 'ActividadAsistente'
CREATE TABLE [dbo].[ActividadAsistente] (
    [ActividadAsistente_Asistente_Id] int  NOT NULL,
    [ActividadAsistente_Actividad_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ActividadSet'
ALTER TABLE [dbo].[ActividadSet]
ADD CONSTRAINT [PK_ActividadSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ArticuloSet'
ALTER TABLE [dbo].[ArticuloSet]
ADD CONSTRAINT [PK_ArticuloSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RegistroArticuloSet'
ALTER TABLE [dbo].[RegistroArticuloSet]
ADD CONSTRAINT [PK_RegistroArticuloSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdscripcionSet'
ALTER TABLE [dbo].[AdscripcionSet]
ADD CONSTRAINT [PK_AdscripcionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AutorSet'
ALTER TABLE [dbo].[AutorSet]
ADD CONSTRAINT [PK_AutorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EvaluacionSet'
ALTER TABLE [dbo].[EvaluacionSet]
ADD CONSTRAINT [PK_EvaluacionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MiembroComiteSet'
ALTER TABLE [dbo].[MiembroComiteSet]
ADD CONSTRAINT [PK_MiembroComiteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CalendarioSet'
ALTER TABLE [dbo].[CalendarioSet]
ADD CONSTRAINT [PK_CalendarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MagistralSet'
ALTER TABLE [dbo].[MagistralSet]
ADD CONSTRAINT [PK_MagistralSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ParticipanteSet'
ALTER TABLE [dbo].[ParticipanteSet]
ADD CONSTRAINT [PK_ParticipanteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EgresoSet'
ALTER TABLE [dbo].[EgresoSet]
ADD CONSTRAINT [PK_EgresoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MaterialSet'
ALTER TABLE [dbo].[MaterialSet]
ADD CONSTRAINT [PK_MaterialSet]
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

-- Creating primary key on [Id] in table 'EventoSet'
ALTER TABLE [dbo].[EventoSet]
ADD CONSTRAINT [PK_EventoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PresupuestoSet'
ALTER TABLE [dbo].[PresupuestoSet]
ADD CONSTRAINT [PK_PresupuestoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComiteSet'
ALTER TABLE [dbo].[ComiteSet]
ADD CONSTRAINT [PK_ComiteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AsistenteSet'
ALTER TABLE [dbo].[AsistenteSet]
ADD CONSTRAINT [PK_AsistenteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TareaSet'
ALTER TABLE [dbo].[TareaSet]
ADD CONSTRAINT [PK_TareaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrganizadorSet'
ALTER TABLE [dbo].[OrganizadorSet]
ADD CONSTRAINT [PK_OrganizadorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ActividadParticipante_Participante_Id], [Participante_Id] in table 'ActividadParticipante'
ALTER TABLE [dbo].[ActividadParticipante]
ADD CONSTRAINT [PK_ActividadParticipante]
    PRIMARY KEY CLUSTERED ([ActividadParticipante_Participante_Id], [Participante_Id] ASC);
GO

-- Creating primary key on [ActividadAsistente_Asistente_Id], [ActividadAsistente_Actividad_Id] in table 'ActividadAsistente'
ALTER TABLE [dbo].[ActividadAsistente]
ADD CONSTRAINT [PK_ActividadAsistente]
    PRIMARY KEY CLUSTERED ([ActividadAsistente_Asistente_Id], [ActividadAsistente_Actividad_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ActividadArticulo_Articulo_Id] in table 'ArticuloSet'
ALTER TABLE [dbo].[ArticuloSet]
ADD CONSTRAINT [FK_ActividadArticulo]
    FOREIGN KEY ([ActividadArticulo_Articulo_Id])
    REFERENCES [dbo].[ActividadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadArticulo'
CREATE INDEX [IX_FK_ActividadArticulo]
ON [dbo].[ArticuloSet]
    ([ActividadArticulo_Articulo_Id]);
GO

-- Creating foreign key on [Articulo_Id] in table 'RegistroArticuloSet'
ALTER TABLE [dbo].[RegistroArticuloSet]
ADD CONSTRAINT [FK_ArticuloRegistroArticulo]
    FOREIGN KEY ([Articulo_Id])
    REFERENCES [dbo].[ArticuloSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticuloRegistroArticulo'
CREATE INDEX [IX_FK_ArticuloRegistroArticulo]
ON [dbo].[RegistroArticuloSet]
    ([Articulo_Id]);
GO

-- Creating foreign key on [AutorId] in table 'RegistroArticuloSet'
ALTER TABLE [dbo].[RegistroArticuloSet]
ADD CONSTRAINT [FK_AutorRegistroArticulo]
    FOREIGN KEY ([AutorId])
    REFERENCES [dbo].[AutorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AutorRegistroArticulo'
CREATE INDEX [IX_FK_AutorRegistroArticulo]
ON [dbo].[RegistroArticuloSet]
    ([AutorId]);
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

-- Creating foreign key on [MiembroComite_Id] in table 'EvaluacionSet'
ALTER TABLE [dbo].[EvaluacionSet]
ADD CONSTRAINT [FK_EvaluacionMiembroComite]
    FOREIGN KEY ([MiembroComite_Id])
    REFERENCES [dbo].[MiembroComiteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EvaluacionMiembroComite'
CREATE INDEX [IX_FK_EvaluacionMiembroComite]
ON [dbo].[EvaluacionSet]
    ([MiembroComite_Id]);
GO

-- Creating foreign key on [ActividadId] in table 'CalendarioSet'
ALTER TABLE [dbo].[CalendarioSet]
ADD CONSTRAINT [FK_ActividadCalendario]
    FOREIGN KEY ([ActividadId])
    REFERENCES [dbo].[ActividadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadCalendario'
CREATE INDEX [IX_FK_ActividadCalendario]
ON [dbo].[CalendarioSet]
    ([ActividadId]);
GO

-- Creating foreign key on [AdscripcionId] in table 'ParticipanteSet'
ALTER TABLE [dbo].[ParticipanteSet]
ADD CONSTRAINT [FK_AdscripcionParticipante]
    FOREIGN KEY ([AdscripcionId])
    REFERENCES [dbo].[AdscripcionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdscripcionParticipante'
CREATE INDEX [IX_FK_AdscripcionParticipante]
ON [dbo].[ParticipanteSet]
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

-- Creating foreign key on [ActividadMagistral_Magistral_Id] in table 'MagistralSet'
ALTER TABLE [dbo].[MagistralSet]
ADD CONSTRAINT [FK_ActividadMagistral]
    FOREIGN KEY ([ActividadMagistral_Magistral_Id])
    REFERENCES [dbo].[ActividadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadMagistral'
CREATE INDEX [IX_FK_ActividadMagistral]
ON [dbo].[MagistralSet]
    ([ActividadMagistral_Magistral_Id]);
GO

-- Creating foreign key on [ActividadParticipante_Participante_Id] in table 'ActividadParticipante'
ALTER TABLE [dbo].[ActividadParticipante]
ADD CONSTRAINT [FK_ActividadParticipante_Actividad]
    FOREIGN KEY ([ActividadParticipante_Participante_Id])
    REFERENCES [dbo].[ActividadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Participante_Id] in table 'ActividadParticipante'
ALTER TABLE [dbo].[ActividadParticipante]
ADD CONSTRAINT [FK_ActividadParticipante_Participante]
    FOREIGN KEY ([Participante_Id])
    REFERENCES [dbo].[ParticipanteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadParticipante_Participante'
CREATE INDEX [IX_FK_ActividadParticipante_Participante]
ON [dbo].[ActividadParticipante]
    ([Participante_Id]);
GO

-- Creating foreign key on [Magistral_Id] in table 'EgresoSet'
ALTER TABLE [dbo].[EgresoSet]
ADD CONSTRAINT [FK_EgresoMagistral]
    FOREIGN KEY ([Magistral_Id])
    REFERENCES [dbo].[MagistralSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EgresoMagistral'
CREATE INDEX [IX_FK_EgresoMagistral]
ON [dbo].[EgresoSet]
    ([Magistral_Id]);
GO

-- Creating foreign key on [EgresoMaterial_Material_Id] in table 'MaterialSet'
ALTER TABLE [dbo].[MaterialSet]
ADD CONSTRAINT [FK_EgresoMaterial]
    FOREIGN KEY ([EgresoMaterial_Material_Id])
    REFERENCES [dbo].[EgresoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EgresoMaterial'
CREATE INDEX [IX_FK_EgresoMaterial]
ON [dbo].[MaterialSet]
    ([EgresoMaterial_Material_Id]);
GO

-- Creating foreign key on [ActividadId] in table 'MaterialSet'
ALTER TABLE [dbo].[MaterialSet]
ADD CONSTRAINT [FK_ActividadMaterial]
    FOREIGN KEY ([ActividadId])
    REFERENCES [dbo].[ActividadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadMaterial'
CREATE INDEX [IX_FK_ActividadMaterial]
ON [dbo].[MaterialSet]
    ([ActividadId]);
GO

-- Creating foreign key on [RegistroArticuloIngreso_RegistroArticulo_Id] in table 'RegistroArticuloSet'
ALTER TABLE [dbo].[RegistroArticuloSet]
ADD CONSTRAINT [FK_RegistroArticuloIngreso]
    FOREIGN KEY ([RegistroArticuloIngreso_RegistroArticulo_Id])
    REFERENCES [dbo].[IngresoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegistroArticuloIngreso'
CREATE INDEX [IX_FK_RegistroArticuloIngreso]
ON [dbo].[RegistroArticuloSet]
    ([RegistroArticuloIngreso_RegistroArticulo_Id]);
GO

-- Creating foreign key on [IngresoPatrocinador_Patrocinador_Id] in table 'PatrocinadorSet'
ALTER TABLE [dbo].[PatrocinadorSet]
ADD CONSTRAINT [FK_IngresoPatrocinador]
    FOREIGN KEY ([IngresoPatrocinador_Patrocinador_Id])
    REFERENCES [dbo].[IngresoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IngresoPatrocinador'
CREATE INDEX [IX_FK_IngresoPatrocinador]
ON [dbo].[PatrocinadorSet]
    ([IngresoPatrocinador_Patrocinador_Id]);
GO

-- Creating foreign key on [EventoId] in table 'ActividadSet'
ALTER TABLE [dbo].[ActividadSet]
ADD CONSTRAINT [FK_EventoActividad]
    FOREIGN KEY ([EventoId])
    REFERENCES [dbo].[EventoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventoActividad'
CREATE INDEX [IX_FK_EventoActividad]
ON [dbo].[ActividadSet]
    ([EventoId]);
GO

-- Creating foreign key on [EventoPresupuesto_Evento_Id] in table 'EventoSet'
ALTER TABLE [dbo].[EventoSet]
ADD CONSTRAINT [FK_EventoPresupuesto]
    FOREIGN KEY ([EventoPresupuesto_Evento_Id])
    REFERENCES [dbo].[PresupuestoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventoPresupuesto'
CREATE INDEX [IX_FK_EventoPresupuesto]
ON [dbo].[EventoSet]
    ([EventoPresupuesto_Evento_Id]);
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

-- Creating foreign key on [ComiteId] in table 'ActividadSet'
ALTER TABLE [dbo].[ActividadSet]
ADD CONSTRAINT [FK_ComiteActividad]
    FOREIGN KEY ([ComiteId])
    REFERENCES [dbo].[ComiteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComiteActividad'
CREATE INDEX [IX_FK_ComiteActividad]
ON [dbo].[ActividadSet]
    ([ComiteId]);
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

-- Creating foreign key on [ActividadAsistente_Asistente_Id] in table 'ActividadAsistente'
ALTER TABLE [dbo].[ActividadAsistente]
ADD CONSTRAINT [FK_ActividadAsistente_Actividad]
    FOREIGN KEY ([ActividadAsistente_Asistente_Id])
    REFERENCES [dbo].[ActividadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActividadAsistente_Actividad_Id] in table 'ActividadAsistente'
ALTER TABLE [dbo].[ActividadAsistente]
ADD CONSTRAINT [FK_ActividadAsistente_Asistente]
    FOREIGN KEY ([ActividadAsistente_Actividad_Id])
    REFERENCES [dbo].[AsistenteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadAsistente_Asistente'
CREATE INDEX [IX_FK_ActividadAsistente_Asistente]
ON [dbo].[ActividadAsistente]
    ([ActividadAsistente_Actividad_Id]);
GO

-- Creating foreign key on [ActividadId] in table 'TareaSet'
ALTER TABLE [dbo].[TareaSet]
ADD CONSTRAINT [FK_ActividadTarea]
    FOREIGN KEY ([ActividadId])
    REFERENCES [dbo].[ActividadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActividadTarea'
CREATE INDEX [IX_FK_ActividadTarea]
ON [dbo].[TareaSet]
    ([ActividadId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
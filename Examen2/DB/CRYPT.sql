create database examen


USE examen
GO
/****** Object:  Table [dbo].[ASIGNACION]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASIGNACION](
	[AsignacionID] [int] IDENTITY(1,1) NOT NULL,
	[ReparacionID] [int] NULL,
	[TecnicoID] [int] NULL,
	[FechaAsignacion] [datetime] NULL,
 CONSTRAINT [pk_AsignacionID] PRIMARY KEY CLUSTERED 
(
	[AsignacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLESREPARACION]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLESREPARACION](
	[DetalleID] [int] IDENTITY(1,1) NOT NULL,
	[ReparacionID] [int] NULL,
	[Descripcion] [varchar](50) NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFin] [datetime] NULL,
 CONSTRAINT [pk_DetalleID] PRIMARY KEY CLUSTERED 
(
	[DetalleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EQUIPOS]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EQUIPOS](
	[EquipoID] [int] IDENTITY(1,1) NOT NULL,
	[TipoEquipo] [varchar](50) NOT NULL,
	[Modelo] [varchar](50) NULL,
	[UsuarioID] [int] NULL,
 CONSTRAINT [pk_EquipoID] PRIMARY KEY CLUSTERED 
(
	[EquipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[REPARACIONES]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[REPARACIONES](
	[ReparacionID] [int] IDENTITY(1,1) NOT NULL,
	[EquipoID] [int] NULL,
	[FechaSolicitud] [datetime] NULL,
	[Estado] [char](1) NULL,
 CONSTRAINT [pk_ReparacionID] PRIMARY KEY CLUSTERED 
(
	[ReparacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TECNICOS]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TECNICOS](
	[TecnicoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Especialidad] [varchar](50) NULL,
 CONSTRAINT [pk_TecnicoID] PRIMARY KEY CLUSTERED 
(
	[TecnicoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[CorreoElectronico] [varchar](50) NOT NULL,
	[Telefono] [varchar](15) NULL,
 CONSTRAINT [pk_UsuarioID] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ASIGNACION]  WITH CHECK ADD  CONSTRAINT [fk_ReparacionID_Asignacion] FOREIGN KEY([ReparacionID])
REFERENCES [dbo].[REPARACIONES] ([ReparacionID])
GO
ALTER TABLE [dbo].[ASIGNACION] CHECK CONSTRAINT [fk_ReparacionID_Asignacion]
GO
ALTER TABLE [dbo].[ASIGNACION]  WITH CHECK ADD  CONSTRAINT [fk_TecnicoID_Asignacion] FOREIGN KEY([TecnicoID])
REFERENCES [dbo].[TECNICOS] ([TecnicoID])
GO
ALTER TABLE [dbo].[ASIGNACION] CHECK CONSTRAINT [fk_TecnicoID_Asignacion]
GO
ALTER TABLE [dbo].[DETALLESREPARACION]  WITH CHECK ADD  CONSTRAINT [fk_ReparacionID_DetallesReparacion] FOREIGN KEY([ReparacionID])
REFERENCES [dbo].[REPARACIONES] ([ReparacionID])
GO
ALTER TABLE [dbo].[DETALLESREPARACION] CHECK CONSTRAINT [fk_ReparacionID_DetallesReparacion]
GO
ALTER TABLE [dbo].[EQUIPOS]  WITH CHECK ADD  CONSTRAINT [fk_UsuarioID_Equipos] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[USUARIO] ([UsuarioID])
GO
ALTER TABLE [dbo].[EQUIPOS] CHECK CONSTRAINT [fk_UsuarioID_Equipos]
GO
ALTER TABLE [dbo].[REPARACIONES]  WITH CHECK ADD  CONSTRAINT [fk_EquipoID_Reparaciones] FOREIGN KEY([EquipoID])
REFERENCES [dbo].[EQUIPOS] ([EquipoID])
GO
ALTER TABLE [dbo].[REPARACIONES] CHECK CONSTRAINT [fk_EquipoID_Reparaciones]
GO
/****** Object:  StoredProcedure [dbo].[AgregarEquipo]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarEquipo]
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(50),
    @UsuarioID INT
AS
BEGIN
    INSERT INTO EQUIPOS (TipoEquipo, Modelo, UsuarioID)
    VALUES (@TipoEquipo, @Modelo, @UsuarioID);
END;
GO
/****** Object:  StoredProcedure [dbo].[AgregarTecnico]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Agregar técnico
CREATE PROCEDURE [dbo].[AgregarTecnico]
    @Nombre VARCHAR(50),
    @Especialidad VARCHAR(50)
AS
BEGIN
    INSERT INTO TECNICOS (Nombre, Especialidad)
    VALUES (@Nombre, @Especialidad);
END;
GO
/****** Object:  StoredProcedure [dbo].[AgregarUsuario]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Agregar usuario
CREATE PROCEDURE [dbo].[AgregarUsuario]
    @Nombre VARCHAR(50),
    @CorreoElectronico VARCHAR(50),
    @Telefono VARCHAR(15)
AS
BEGIN
    INSERT INTO USUARIO (Nombre, CorreoElectronico, Telefono)
    VALUES (@Nombre, @CorreoElectronico, @Telefono);
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarEquipo]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Borrar equipo
CREATE PROCEDURE [dbo].[BorrarEquipo]
    @EquipoID INT
AS
BEGIN
    DELETE FROM EQUIPOS WHERE EquipoID = @EquipoID;
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarTecnico]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Borrar técnico
CREATE PROCEDURE [dbo].[BorrarTecnico]
    @TecnicoID INT
AS
BEGIN
    DELETE FROM TECNICOS WHERE TecnicoID = @TecnicoID;
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarUsuario]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarUsuario]
    @UsuarioID INT
AS
BEGIN
    DELETE FROM USUARIO WHERE UsuarioID = @UsuarioID;
END;
GO
/****** Object:  StoredProcedure [dbo].[ConsultarEquiposConFiltro]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Consultar equipos con filtro
CREATE PROCEDURE [dbo].[ConsultarEquiposConFiltro]
    @Filtro VARCHAR(50)
AS
BEGIN
    SELECT * FROM EQUIPOS
    WHERE TipoEquipo LIKE '%' + @Filtro + '%' OR Modelo LIKE '%' + @Filtro + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[ConsultarTecnicosConFiltro]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Consultar técnicos con filtro
CREATE PROCEDURE [dbo].[ConsultarTecnicosConFiltro]
    @Filtro VARCHAR(50)
AS
BEGIN
    SELECT * FROM TECNICOS
    WHERE Nombre LIKE '%' + @Filtro + '%' OR Especialidad LIKE '%' + @Filtro + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[ConsultarUsuariosConFiltro]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarUsuariosConFiltro]
    @Filtro VARCHAR(50)
AS
BEGIN
    SELECT * FROM USUARIO
    WHERE Nombre LIKE '%' + @Filtro + '%' OR CorreoElectronico LIKE '%' + @Filtro + '%' OR Telefono LIKE '%' + @Filtro + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[ModificarEquipo]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarEquipo]
    @EquipoID INT,
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(50),
    @UsuarioID INT
AS
BEGIN
    UPDATE EQUIPOS
    SET TipoEquipo = @TipoEquipo,
        Modelo = @Modelo,
        UsuarioID = @UsuarioID
    WHERE EquipoID = @EquipoID;
END;
GO
/****** Object:  StoredProcedure [dbo].[ModificarTecnico]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Modificar técnico
CREATE PROCEDURE [dbo].[ModificarTecnico]
    @TecnicoID INT,
    @Nombre VARCHAR(50),
    @Especialidad VARCHAR(50)
AS
BEGIN
    UPDATE TECNICOS
    SET Nombre = @Nombre,
        Especialidad = @Especialidad
    WHERE TecnicoID = @TecnicoID;
END;
GO
/****** Object:  StoredProcedure [dbo].[ModificarUsuario]    Script Date: 20/11/2023 07:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarUsuario]
    @UsuarioID INT,
    @Nombre VARCHAR(50),
    @CorreoElectronico VARCHAR(50),
    @Telefono VARCHAR(15)
AS
BEGIN
    UPDATE USUARIO
    SET Nombre = @Nombre,
        CorreoElectronico = @CorreoElectronico,
        Telefono = @Telefono
    WHERE UsuarioID = @UsuarioID;
END;
GO
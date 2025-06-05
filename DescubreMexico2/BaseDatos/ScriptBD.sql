CREATE TABLE [dbo].[Usuarios] (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Contrasena VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    FechaRegistro DATETIME DEFAULT GETDATE(),
    TipoUsuario VARCHAR(20) NOT NULL CHECK (TipoUsuario IN ('turista', 'admin')),
	Activo BIT DEFAULT 1
);
GO

CREATE PROC [dbo].[sp_usuario_insertar]
    @Nombre VARCHAR(100),
    @Email VARCHAR(100),
    @Contrasena VARCHAR(100),
    @Telefono VARCHAR(20),
    @TipoUsuario VARCHAR(20)
AS 
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

		INSERT INTO Usuarios(Nombre, Email, Contrasena, Telefono, TipoUsuario)
		VALUES (@Nombre, @Email, @Contrasena, @Telefono, @TipoUsuario);
		COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END 
GO

CREATE PROC [dbo].[sp_usuario_actualizar]
	@IdUsuario INT,
    @Nombre VARCHAR(100) = NULL,
    @Email VARCHAR(100) = NULL,
    @Contrasena VARCHAR(100) = NULL,
    @Telefono VARCHAR(20) = NULL,
    @TipoUsuario VARCHAR(20) = NULL,
	@Activo BIT = NULL
AS 
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY


	UPDATE Usuarios SET 
	Nombre = ISNULL(@Nombre, Nombre), 
	Email = ISNULL(@Email, Email), 
	Contrasena = ISNULL(@Contrasena, Contrasena),
	Telefono = ISNULL(@Telefono, Telefono),
	TipoUsuario = ISNULL(@TipoUsuario, TipoUsuario),
	Activo = ISNULL(@Activo, Activo)
	WHERE
	IdUsuario = @IdUsuario;

	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END 
GO

CREATE PROC [dbo].[sp_usuario_deshabilitiar]
     @IdUsuario int
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    UPDATE Usuarios 
	SET	Activo = 0 
	WHERE IdUsuario = @IdUsuario;

	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO


CREATE PROC [dbo].[sp_usuario_conseguir]
    @IdUsuario INT
AS
BEGIN
    SELECT *
    FROM Usuarios
    WHERE IdUsuario = @IdUsuario
END
GO

CREATE PROC [dbo].[sp_usuario_conseguir_Email]
    @Email VARCHAR(100)
AS
BEGIN
    SELECT *
    FROM Usuarios
    WHERE Email = @Email
END
GO


CREATE PROC [dbo].[sp_usuarios_listar]
	@Activo BIT = NULL,
	@TipoUsuario VARCHAR(20) = NULL
AS
BEGIN
    SELECT *
    FROM Usuarios 
	WHERE 
	Activo = ISNULL(@Activo, Activo) AND 
	TipoUsuario = ISNULL(@TipoUsuario, TipoUsuario);
END
GO

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Guias
CREATE TABLE [dbo].[Guias] (
    IdGuia INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Telefono VARCHAR(20),
    Experiencia TEXT,
    Activo BIT DEFAULT 1
);
GO

CREATE PROC [dbo].[sp_guia_insertar]
    @Nombre VARCHAR(100),
    @Email VARCHAR(100),
    @Telefono VARCHAR(20),
    @Experiencia TEXT
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

		INSERT INTO Guias (Nombre, Email, Telefono, Experiencia, Activo)
		VALUES (@Nombre, @Email, @Telefono, @Experiencia, 1);

		COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_guia_actualizar]
    @IdGuia INT,
    @Nombre VARCHAR(100) = NULL,
    @Email VARCHAR(100) = NULL,
    @Telefono VARCHAR(20) = NULL,
    @Experiencia TEXT = NULL,
    @Activo BIT = NULL
AS
BEGIN
	BEGIN TRANSACTION;
	BEGIN TRY

    UPDATE Guias SET 
        Nombre = ISNULL(@Nombre, Nombre),
        Email = ISNULL(@Email, Email),
        Telefono = ISNULL(@Telefono, Telefono),
        Experiencia = ISNULL(@Experiencia, Experiencia),
        Activo = ISNULL(@Activo, Activo)
    WHERE IdGuia = @IdGuia;
	
	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_guia_deshabilitar]
     @IdGuia INT
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    UPDATE Guias
    SET Activo = 0
    WHERE IdGuia = @IdGuia;

	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_guia_conseguir]
    @IdGuia INT
AS
BEGIN
    SELECT *
    FROM Guias
    WHERE IdGuia = @IdGuia;
END
GO

CREATE PROC [dbo].[sp_guias_listar]
    @Activo BIT = NULL
AS
BEGIN
    SELECT *
    FROM Guias
    WHERE Activo = ISNULL(@Activo, Activo);
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Lugares
CREATE TABLE [dbo].[Lugares] (
    IdLugar INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    Ciudad VARCHAR(100),
    Latitud DECIMAL(9,6),
    Longitud DECIMAL(9,6),
    ImagenUrl TEXT,
	Activo BIT
);
GO

CREATE PROC [dbo].[sp_lugar_insertar]
    @Nombre VARCHAR(100),
    @Descripcion TEXT,
    @Ciudad VARCHAR(100),
    @Latitud DECIMAL(9,6),
    @Longitud DECIMAL(9,6),
    @ImagenUrl TEXT
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    INSERT INTO Lugares (Nombre, Descripcion, Ciudad, Latitud, Longitud, ImagenUrl, Activo)
    VALUES (@Nombre, @Descripcion, @Ciudad, @Latitud, @Longitud, @ImagenUrl, 1);

	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_lugar_actualizar]
    @IdLugar INT,
    @Nombre VARCHAR(100) = NULL,
    @Descripcion TEXT = NULL,
    @Ciudad VARCHAR(100) = NULL,
    @Latitud DECIMAL(9,6) = NULL,
    @Longitud DECIMAL(9,6) = NULL,
    @ImagenUrl TEXT = NULL,
	@Activo BIT = NULL
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    UPDATE Lugares SET 
        Nombre = ISNULL(@Nombre, Nombre),
        Descripcion = ISNULL(@Descripcion, Descripcion),
        Ciudad = ISNULL(@Ciudad, Ciudad),
        Latitud = ISNULL(@Latitud, Latitud),
        Longitud = ISNULL(@Longitud, Longitud),
        ImagenUrl = ISNULL(@ImagenUrl, ImagenUrl),
		Activo = ISNULL(@Activo, Activo)
    WHERE IdLugar = @IdLugar;

	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_lugar_conseguir]
    @IdLugar INT
AS
BEGIN
    SELECT *
    FROM Lugares
    WHERE IdLugar = @IdLugar;
END
GO

CREATE PROC [dbo].[sp_lugar_deshabilitar]
     @IdGuia INT
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    UPDATE Guias
    SET Activo = 0
    WHERE IdGuia = @IdGuia;

	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_lugares_listar]
    @Ciudad VARCHAR(100) = NULL
AS
BEGIN
    SELECT *
    FROM Lugares
    WHERE Ciudad = ISNULL(@Ciudad, Ciudad);
END
GO

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Tipos de Recorrido
CREATE TABLE [dbo].[TiposRecorrido] (
    IdTipo INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion TEXT
);

INSERT INTO TiposRecorrido (Nombre, Descripcion)
VALUES 
('Caminata', 'Recorridos a pie por senderos naturales o urbanos.'),
('Tour Cultural', 'Recorridos enfocados en historia y cultura.');
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Recorridos
CREATE TABLE [dbo].[Recorridos] (
    IdRecorrido INT PRIMARY KEY IDENTITY(1,1),
    Titulo VARCHAR(100) NOT NULL,
    Descripcion TEXT,
    IdTipo INT NOT NULL,
    DuracionHoras INT,
    Precio DECIMAL(10,2),
    Dificultad VARCHAR(10) CHECK (Dificultad IN ('baja', 'media', 'alta')),
    MaxParticipantes INT,
    IdGuia INT NOT NULL,
	Activo BIT,
    FOREIGN KEY (IdTipo) REFERENCES TiposRecorrido(IdTipo),
    FOREIGN KEY (IdGuia) REFERENCES Guias(IdGuia)
);
GO


CREATE PROC [dbo].[sp_recorrido_deshabilitar]
    @IdRecorrido INT
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    UPDATE Recorridos 
	SET Activo = 0 
	WHERE Recorridos.IdRecorrido = @IdRecorrido

	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_recorrido_insertar]
    @Titulo VARCHAR(100),
    @Descripcion TEXT,
    @IdTipo INT,
    @DuracionHoras INT,
    @Precio DECIMAL(10,2),
    @Dificultad VARCHAR(10),
    @MaxParticipantes INT,
    @IdGuia INT
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    INSERT INTO Recorridos (Titulo, Descripcion, IdTipo, DuracionHoras, Precio, Dificultad, MaxParticipantes, IdGuia, Activo)
    VALUES (@Titulo, @Descripcion, @IdTipo, @DuracionHoras, @Precio, @Dificultad, @MaxParticipantes, @IdGuia, 1);
	
	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_recorrido_actualizar]
    @IdRecorrido INT,
    @Titulo VARCHAR(100) = NULL,
    @Descripcion TEXT = NULL,
    @IdTipo INT = NULL,
    @DuracionHoras INT = NULL,
    @Precio DECIMAL(10,2) = NULL,
    @Dificultad VARCHAR(10) = NULL,
    @MaxParticipantes INT = NULL,
    @IdGuia INT = NULL, 
	@Activo BIT = NULL
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    UPDATE Recorridos SET 
        Titulo = ISNULL(@Titulo, Titulo),
        Descripcion = ISNULL(@Descripcion, Descripcion),
        IdTipo = ISNULL(@IdTipo, IdTipo),
        DuracionHoras = ISNULL(@DuracionHoras, DuracionHoras),
        Precio = ISNULL(@Precio, Precio),
        Dificultad = ISNULL(@Dificultad, Dificultad),
        MaxParticipantes = ISNULL(@MaxParticipantes, MaxParticipantes),
        IdGuia = ISNULL(@IdGuia, IdGuia),
		Activo = ISNULL(@Activo, Activo)
    WHERE IdRecorrido = @IdRecorrido;

	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_recorrido_conseguir]
    @IdRecorrido INT
AS
BEGIN
    SELECT *
    FROM Recorridos
    WHERE IdRecorrido = @IdRecorrido;
END
GO


CREATE PROC [dbo].[sp_recorridos_listar]
    @IdGuia INT = NULL,
    @IdTipo INT = NULL,
    @Dificultad VARCHAR(10) = NULL
AS
BEGIN
    SELECT *
    FROM Recorridos
    WHERE 
        IdGuia = ISNULL(@IdGuia, IdGuia) AND
        IdTipo = ISNULL(@IdTipo, IdTipo) AND
        Dificultad = ISNULL(@Dificultad, Dificultad);
END
GO


CREATE PROC [dbo].[sp_recorrido_deshabilitar]
    @IdRecorrido INT
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    UPDATE Recorridos 
	SET Activo = 0 
	WHERE Recorridos.IdRecorrido = @IdRecorrido

	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- Recorrido_Lugares (relación muchos a muchos)
CREATE TABLE [dbo].[RecorridoLugares] (
	IdRecorridoLugar INT PRIMARY KEY IDENTITY,
    IdRecorrido INT,
    IdLugar INT,
    FOREIGN KEY (IdRecorrido) REFERENCES Recorridos(IdRecorrido),
    FOREIGN KEY (IdLugar) REFERENCES Lugares(IdLugar)
);
go

CREATE PROC [dbo].[sp_recorrido_lugar_insertar]
    @IdRecorrido INT,
    @IdLugar INT
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    INSERT INTO RecorridoLugares (IdRecorrido, IdLugar)
    VALUES (@IdRecorrido, @IdLugar);
	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_recorrido_lugar_eliminar]
    @IdRecorridoLugar INT
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    DELETE FROM RecorridoLugares
    WHERE IdRecorridoLugar = @IdRecorridoLugar;

	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_recorrido_lugares_por_recorrido]
    @IdRecorrido INT
AS
BEGIN
    SELECT rl.IdRecorridoLugar, rl.IdRecorrido, rl.IdLugar, l.Nombre AS NombreLugar
    FROM RecorridoLugares rl
    INNER JOIN Lugares l ON rl.IdLugar = l.IdLugar
    WHERE rl.IdRecorrido = @IdRecorrido;
END
GO

CREATE PROC [dbo].[sp_recorrido_lugares_listar]
AS
BEGIN
    SELECT rl.IdRecorridoLugar, r.Titulo AS Recorrido, l.Nombre AS Lugar
    FROM RecorridoLugares rl
    INNER JOIN Recorridos r ON rl.IdRecorrido = r.IdRecorrido
    INNER JOIN Lugares l ON rl.IdLugar = l.IdLugar;
END
GO
------------------------------------------------------------------------------------------------------------------------------------------
-- Agendas
CREATE TABLE [dbo].[Agendas] (
    IdAgenda INT PRIMARY KEY IDENTITY(1,1),
    IdRecorrido INT NOT NULL,
    Fecha DATE NOT NULL,
    HoraInicio TIME,
    Estado VARCHAR(20) CHECK (Estado IN ('programado', 'realizado', 'cancelado')),
    FOREIGN KEY (IdRecorrido) REFERENCES Recorridos(IdRecorrido)
);
GO

CREATE PROC [dbo].[sp_agenda_insertar]
	@IdRecorrido INT,
    @Fecha DATE,
    @HoraInicio TIME
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY
    
	INSERT INTO Agendas (IdRecorrido, Fecha, HoraInicio, Estado)
    VALUES (@IdRecorrido, @Fecha, @HoraInicio, 'programado');
	
	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_agenda_actualizar]
    @IdAgenda INT,
    @IdRecorrido INT = NULL,
    @Fecha DATE = NULL,
    @HoraInicio TIME = NULL,
    @Estado VARCHAR(20) = NULL
AS
BEGIN
    BEGIN TRANSACTION;

	BEGIN TRY

    UPDATE Agendas SET 
        IdRecorrido = ISNULL(@IdRecorrido, IdRecorrido),
        Fecha = ISNULL(@Fecha, Fecha),
        HoraInicio = ISNULL(@HoraInicio, HoraInicio),
        Estado = ISNULL(@Estado, Estado)
    WHERE IdAgenda = @IdAgenda;
	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0  
			ROLLBACK TRANSACTION; 
		THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_agenda_conseguir]
    @IdAgenda INT
AS
BEGIN
    SELECT  a.IdAgenda, a.IdRecorrido, r.Titulo, a.Fecha, a.HoraInicio, a.Estado
    FROM Agendas a
	INNER JOIN Recorridos r ON r.IdRecorrido = a.IdRecorrido
    WHERE a.IdAgenda = @IdAgenda;
END
GO

CREATE PROC [dbo].[sp_agendas_listar]
    @IdRecorrido INT = NULL,
    @Estado VARCHAR(20) = NULL,
    @FechaDesde DATE = NULL,
    @FechaHasta DATE = NULL
AS
BEGIN
    SELECT  a.IdAgenda, a.IdRecorrido, r.Titulo, a.Fecha, a.HoraInicio, a.Estado
    FROM Agendas a
	INNER JOIN Recorridos r ON r.IdRecorrido = a.IdRecorrido
    WHERE
        a.IdRecorrido = ISNULL(@IdRecorrido, a.IdRecorrido) AND
        a.Estado = ISNULL(@Estado, a.Estado) AND
        (@FechaDesde IS NULL OR a.Fecha >= @FechaDesde) AND
        (@FechaHasta IS NULL OR a.Fecha <= @FechaHasta);
END
GO

CREATE PROC [dbo].[sp_agenda_cancelar]
     @IdAgenda INT
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

		UPDATE Agendas
		SET Estado = 'cancelado'
		WHERE IdAgenda = @IdAgenda;
		COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Cancelaciones
CREATE TABLE [dbo].[Cancelaciones] (
    IdReserva INT PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT NOT NULL,
    IdAgenda INT NOT NULL,
    Fecha DATETIME,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdAgenda) REFERENCES Agendas(IdAgenda)
);

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Opiniones de los usuarios
CREATE TABLE [dbo].[Opiniones] (
    IdOpinion INT PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT NOT NULL,
    IdRecorrido INT NOT NULL,
    Calificacion INT CHECK (Calificacion BETWEEN 1 AND 5),
    Comentario TEXT,
    FechaOpinion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    FOREIGN KEY (IdRecorrido) REFERENCES Recorridos(IdRecorrido)
);
GO

CREATE PROC [dbo].[sp_opinion_insertar]
    @IdUsuario INT,
    @IdRecorrido INT,
    @Calificacion INT,
    @Comentario TEXT
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    INSERT INTO Opiniones (IdUsuario, IdRecorrido, Calificacion, Comentario)
    VALUES (@IdUsuario, @IdRecorrido, @Calificacion, @Comentario);

	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_opinion_actualizar]
    @IdOpinion INT,
    @Calificacion INT = NULL,
    @Comentario TEXT = NULL
AS
BEGIN
	BEGIN TRANSACTION;

	BEGIN TRY

    UPDATE Opiniones
    SET 
        Calificacion = ISNULL(@Calificacion, Calificacion),
        Comentario = ISNULL(@Comentario, Comentario)
    WHERE IdOpinion = @IdOpinion;

	COMMIT TRANSACTION; 
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION; 
	   THROW;
	END CATCH;
END
GO

CREATE PROC [dbo].[sp_opinion_conseguir]
    @IdOpinion INT
AS
BEGIN
    SELECT *
    FROM Opiniones
    WHERE IdOpinion = @IdOpinion;
END
GO


CREATE PROC [dbo].[sp_opiniones_listar]
    @IdUsuario INT = NULL,
    @IdRecorrido INT = NULL
AS
BEGIN
    SELECT *
    FROM Opiniones
    WHERE 
        IdUsuario = ISNULL(@IdUsuario, IdUsuario) AND
        IdRecorrido = ISNULL(@IdRecorrido, IdRecorrido);
END
GO

------------------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Usuarios (Nombre, Email, Contrasena, Telefono, TipoUsuario)
VALUES 
('Jack Cord', 'basquetguitar@gmail.com', 'pass123', '555-5678', 'admin'),
('Ana Torres', 'ana.torres@example.com', 'pass123', '555-1234', 'turista'),
('Carlos Díaz', 'carlos.diaz@example.com', 'pass123', '555-4321', 'turista');

INSERT INTO Guias (Nombre, Email, Telefono, Experiencia)
VALUES
('Marta Gómez', 'marta.gomez@guias.com', '555-1111', '5 años de experiencia en recorridos por zonas montañosas.'),
('Jorge Ramírez', 'jorge.ramirez@guias.com', '555-2222', 'Especializado en recorridos históricos urbanos.');

INSERT INTO Lugares (Nombre, Descripcion, Ciudad, Latitud, Longitud, ImagenUrl)
VALUES
('Zócalo', 'La plaza principal del Centro Histórico, rodeada de edificios coloniales.', 'Ciudad de México', 19.432608, -99.133209, '../assets/images/zocalo.jpg'),

('Castillo de Chapultepec', 'Castillo histórico ubicado en el Bosque de Chapultepec.', 'Ciudad de México', 19.420440, -99.181693, '../assets/images/chapultepec.jpg'),

('Museo Frida Kahlo', 'Casa Azul, hogar y museo de la pintora Frida Kahlo.', 'Ciudad de México', 19.355187, -99.162422, '../assets/images/frida.jpg'),

('Templo Mayor', 'Zona arqueológica del antiguo centro ceremonial mexica.', 'Ciudad de México', 19.435180, -99.132820, '../assets/images/templo_mayor.jpg'),

('Coyoacán', 'Barrio tradicional con calles empedradas, arte y cultura.', 'Ciudad de México', 19.352700, -99.163100, '../assets/images/coyoacan.jpg');


-- Recorrido por el Centro Histórico
INSERT INTO Recorridos (Titulo, Descripcion, IdTipo, DuracionHoras, Precio, Dificultad, MaxParticipantes, IdGuia)
VALUES (
  'Tour Centro Histórico de CDMX',
  'Un recorrido cultural por el corazón de la Ciudad de México, explorando su historia prehispánica y colonial.',
  2, -- Tour Cultural
  3,
  20.00,
  'baja',
  25,
  1
);


-- Recorrido Coyoacán y Frida Kahlo
INSERT INTO Recorridos (Titulo, Descripcion, IdTipo, DuracionHoras, Precio, Dificultad, MaxParticipantes, IdGuia)
VALUES (
  'Coyoacán y la Casa Azul',
  'Explora el pintoresco barrio de Coyoacán y visita la casa de Frida Kahlo.',
  2, -- Tour Cultural
  2,
  18.00,
  'baja',
  20,
  2
);



-- Tour Centro Histórico de CDMX
INSERT INTO RecorridoLugares (IdRecorrido, IdLugar)
VALUES 
(1, 1), -- Zócalo
(1, 2), -- Templo Mayor
(1, 3); -- Castillo de Chapultepec

-- Coyoacán y la Casa Azul
INSERT INTO RecorridoLugares (IdRecorrido, IdLugar)
VALUES
(2, 4), -- Museo Frida Kahlo
(2, 5); -- Coyoacán


----------------------------------------------------------Apartir de aqui ya no se hizo inserción.
INSERT INTO Agendas (IdRecorrido, Fecha, HoraInicio, Estado)
VALUES
(1, '2025-06-10', '08:00', 'programado'),
(2, '2025-06-12', '10:00', 'programado');


INSERT INTO Cancelaciones (IdUsuario, IdAgenda, Fecha)
VALUES
(1, 1, GETDATE());


INSERT INTO Opiniones (IdUsuario, IdRecorrido, Calificacion, Comentario)
VALUES
(3, 1, 5, 'Excelente caminata con vistas increíbles.'),
(2, 2, 4, 'Muy interesante y bien explicado.');
GO

--VISTAS

CREATE VIEW TiposDeRecorridos AS 
SELECT IdTipo, Nombre
  FROM TiposRecorrido
GO

CREATE VIEW vw_RecorridoLugares
AS
SELECT 
	rl.IdRecorridoLugar,
    rl.IdRecorrido,
	rl.IdLugar,
    l.Nombre AS NombreLugar,
    l.ImagenUrl
FROM 
    RecorridoLugares rl
INNER JOIN 
    Lugares l ON l.IdLugar = rl.IdLugar;
GO


CREATE PROC [dbo].[sp_recorrido_lugares_recorrido]
	@IdRecorrido INT 
AS
BEGIN
	select * from vw_RecorridoLugares WHERE IdRecorrido=@IdRecorrido;
END



--------------TRIGGERS

CREATE TRIGGER trg_NoDuplicarRecorridoLugar
ON RecorridoLugares
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM RecorridoLugares rl
        INNER JOIN inserted i ON rl.IdRecorrido = i.IdRecorrido AND rl.IdLugar = i.IdLugar
    )
    BEGIN
        RAISERROR('Ya existe una relación entre ese Recorrido y Lugar.', 16, 1);
        RETURN;
    END

    INSERT INTO RecorridoLugares (IdRecorrido, IdLugar)
    SELECT IdRecorrido, IdLugar
    FROM inserted;
END;
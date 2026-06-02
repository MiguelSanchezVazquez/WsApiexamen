USE [BdiExamen]
GO

/****** Object:  StoredProcedure [dbo].[spConsultar]    Script Date: 6/1/2026 6:43:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- ================================================
-- Consultar un registro en la tabla tblExamen
--
-- Con base en los parámetros recibidos consultar 
-- la tabla y retornar la información que cumpla 
-- los criterios
-- ================================================
CREATE PROCEDURE [dbo].[spConsultar]
    @Nombre NVARCHAR(250),
    @Descripcion NVARCHAR(255)
AS
BEGIN
    -- Stops the message indicating the number of rows affected from being returned
    SET NOCOUNT ON;

    SELECT idExamen, Nombre, Descripcion
    FROM tblExamen
    WHERE Nombre = @Nombre AND Descripcion = @Descripcion;
END;
GO



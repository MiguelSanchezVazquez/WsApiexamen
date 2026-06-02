USE [BdiExamen]
GO

/****** Object:  StoredProcedure [dbo].[spConsultarId]    Script Date: 6/1/2026 6:44:28 PM ******/
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
CREATE PROCEDURE [dbo].[spConsultarId]
    @Id INT
AS
BEGIN
    -- Stops the message indicating the number of rows affected from being returned
    SET NOCOUNT ON;

    SELECT idExamen, Nombre, Descripcion
    FROM tblExamen
    WHERE idExamen = @Id;
END;
GO



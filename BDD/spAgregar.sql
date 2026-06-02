USE [BdiExamen]
GO

/****** Object:  StoredProcedure [dbo].[spAgregar]    Script Date: 6/1/2026 5:45:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- ================================================
-- Insertar un registro en la tabla tblexamen
--
-- En caso de error devolver el código de retorno y
-- la descripción del error
--
-- En caso de éxito devolver el código de retorno 
-- con valor cero y la descripción:
-- “Registro insertado satisfactoriamente”
-- ================================================
CREATE PROCEDURE [dbo].[spAgregar]
    @Id INT,
    @Nombre NVARCHAR(250),
    @Descripcion NVARCHAR(255),

    @ErrorCode INT OUTPUT,
    @ErrorMessage NVARCHAR(4000) OUTPUT
AS
BEGIN
    -- Stops the message indicating the number of rows affected from being returned
    SET NOCOUNT ON;

    -- Initialize output parameters assuming success
    SET @ErrorCode = 0;
    SET @ErrorMessage = 'Registro insertado satisfactoriamente';

    BEGIN TRY
        -- Insert statement mapping the parameters to the columns
        INSERT INTO tblExamen (idExamen, Nombre, Descripcion)
        VALUES (@Id, @Nombre, @Descripcion);
    END TRY

    BEGIN CATCH
        -- Capture the exact system error codes generated inside the TRY block
        SET @ErrorCode = ERROR_NUMBER();
        SET @ErrorMessage = ERROR_MESSAGE();
    END CATCH
END;
GO



USE [BdiExamen]
GO

/****** Object:  StoredProcedure [dbo].[spActualizar]    Script Date: 6/1/2026 6:12:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- ================================================
-- Actualizar un registro en la tabla tblExamen
--
-- En caso de error devolver el código de retorno y
-- la descripción del error
--
-- En caso de éxito devolver el código de retorno 
-- con valor cero y la descripción:
-- “Registro actualizado satisfactoriamente”
-- ================================================
CREATE PROCEDURE [dbo].[spActualizar]
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
    SET @ErrorMessage = 'Registro actualizado satisfactoriamente';

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Perform the update operation
        UPDATE dbo.tblExamen
        SET Nombre = @Nombre, Descripcion = @Descripcion
        WHERE idExamen = @Id;

        -- Validate if rows were actually affected
        IF @@ROWCOUNT = 0
        BEGIN
            -- Throw a custom exception if the target record doesn't exist
            THROW 50001, 'Error al actualizar: No se encontró el registro.', 1;
        END

        -- Commit changes if the update is successful
        COMMIT TRANSACTION;
    END TRY

    BEGIN CATCH
        -- Check if an active transaction needs to be rolled back
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        -- Capture the exact system error codes generated inside the TRY block
        SET @ErrorCode = ERROR_NUMBER();
        SET @ErrorMessage = ERROR_MESSAGE();
    END CATCH
END;
GO



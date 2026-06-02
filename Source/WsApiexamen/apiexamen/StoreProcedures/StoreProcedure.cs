using ApiExamen.Model;
using BdiExamen.Dtos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiExamen.StoreProcedures
{
    public class StoreProcedure
    {
        private readonly string _connectionString = "Data Source=MSANCHEZ\\SQLEXPRESS;User ID=sa;Password=Acirema$1;Initial Catalog=BdiExamen;Connect Timeout=30;Encrypt=false";

        public ExamenResponse AgregarExamen(ExamenDto examen)
        {
            ExamenResponse exaResponse = new ExamenResponse();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.spAgregar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input,
                        Value = examen.idExamen
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Nombre",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 250,
                        Direction = ParameterDirection.Input,
                        Value = examen.Nombre
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Descripcion",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 255,
                        Direction = ParameterDirection.Input,
                        Value = examen.Descripcion
                    });
                    var errorCode = new SqlParameter
                    {
                        ParameterName = "@ErrorCode",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output,
                    };
                    command.Parameters.Add(errorCode);
                    var errorMessage = new SqlParameter
                    {
                        ParameterName = "@ErrorMessage",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 4000,
                        Direction = ParameterDirection.Output,
                    };
                    command.Parameters.Add(errorMessage);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        if (errorCode.Value != DBNull.Value && errorCode.Value is int)
                        {
                            if ( (int)errorCode.Value == 0 )
                            {
                                if (errorMessage.Value != DBNull.Value && errorMessage.Value is string)
                                    exaResponse.Message = errorMessage.Value.ToString();
                            }
                        }
                        else
                        {
                            exaResponse.Success = false;

                            if (errorMessage.Value != DBNull.Value && errorMessage.Value is string)
                                exaResponse.Message = errorMessage.Value.ToString();
                            else
                                exaResponse.Message = "Error al Agregar Examen";
                        }
                    }
                    catch (SqlException ex)
                    {
                        exaResponse.Success = false;
                        exaResponse.Message = ex.Message;
                    }
                }
            }

            return exaResponse;
        }

        public ExamenResponse ActualizarExamen(ExamenDto examen)
        {
            ExamenResponse exaResponse = new ExamenResponse();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.spActualizar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input,
                        Value = examen.idExamen
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Nombre",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 250,
                        Direction = ParameterDirection.Input,
                        Value = examen.Nombre
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Descripcion",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 255,
                        Direction = ParameterDirection.Input,
                        Value = examen.Descripcion
                    });
                    var errorCode = new SqlParameter
                    {
                        ParameterName = "@ErrorCode",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output,
                    };
                    command.Parameters.Add(errorCode);
                    var errorMessage = new SqlParameter
                    {
                        ParameterName = "@ErrorMessage",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 4000,
                        Direction = ParameterDirection.Output,
                    };
                    command.Parameters.Add(errorMessage);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        if (errorCode.Value != DBNull.Value && errorCode.Value is int)
                        {
                            if ((int)errorCode.Value == 0)
                            {
                                if (errorMessage.Value != DBNull.Value && errorMessage.Value is string)
                                    exaResponse.Message = errorMessage.Value.ToString();
                            }
                        }
                        else
                        {
                            exaResponse.Success = false;

                            if (errorMessage.Value != DBNull.Value && errorMessage.Value is string)
                                exaResponse.Message = errorMessage.Value.ToString();
                            else
                                exaResponse.Message = "Error al Actualizar Examen";
                        }
                    }
                    catch (SqlException ex)
                    {
                        exaResponse.Success = false;
                        exaResponse.Message = ex.Message;
                    }
                }
            }

            return exaResponse;
        }

        public ExamenResponse EliminarExamen(int idExamen)
        {
            ExamenResponse exaResponse = new ExamenResponse();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.spEliminar", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input,
                        Value = idExamen
                    });
                    var errorCode = new SqlParameter
                    {
                        ParameterName = "@ErrorCode",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output,
                    };
                    command.Parameters.Add(errorCode);
                    var errorMessage = new SqlParameter
                    {
                        ParameterName = "@ErrorMessage",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 4000,
                        Direction = ParameterDirection.Output,
                    };
                    command.Parameters.Add(errorMessage);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();

                        if (errorCode.Value != DBNull.Value && errorCode.Value is int)
                        {
                            if ((int)errorCode.Value == 0)
                            {
                                if (errorMessage.Value != DBNull.Value && errorMessage.Value is string)
                                    exaResponse.Message = errorMessage.Value.ToString();
                            }
                        }
                        else
                        {
                            exaResponse.Success = false;

                            if (errorMessage.Value != DBNull.Value && errorMessage.Value is string)
                                exaResponse.Message = errorMessage.Value.ToString();
                            else
                                exaResponse.Message = "Error al Eliminar Examen";
                        }
                        //using (SqlDataReader reader = command.ExecuteReader())
                        //{
                        //    while (reader.Read())
                        //    {
                        //        // Handle data extraction cleanly by referencing column names
                        //        exaResponse.Message = reader["Message"].ToString();
                        //    }
                        //}
                    }
                    catch (SqlException ex)
                    {
                        exaResponse.Success = false;
                        exaResponse.Message = ex.Message;
                    }
                }
            }

            return exaResponse;
        }

        public ExamenResponse ConsultarExamen(int idExamen)
        {
            ExamenResponse exaResponse = new ExamenResponse();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.spConsultarId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input,
                        Value = idExamen
                    });

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ExamenDto dto = new ExamenDto();
                                // Handle data extraction cleanly by referencing column names
                                dto.idExamen = (int)reader["idExamen"];
                                dto.Nombre = reader["Nombre"].ToString();
                                dto.Descripcion = reader["Descripcion"].ToString();

                                exaResponse.Examen = dto;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        exaResponse.Success = false;
                        exaResponse.Message = ex.Message;
                    }
                }
            }

            return exaResponse;
        }
    }
}

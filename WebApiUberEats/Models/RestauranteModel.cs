using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUberEats.Models
{
    public class RestauranteModel
    {
        public int IdRestaurante { get; set; }

        public string Nombre { get; set; }

        public string Foto { get; set; }

        public string Direccion { get; set; }

        public double Longitud { get; set; }

        public double Latitud { get; set; }


        public List<RestauranteModel> GetAll(string ConnectionString)
        {
            List<RestauranteModel> restaurantes = new List<RestauranteModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "SELECT * FROM Restaurante";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                restaurantes.Add(new RestauranteModel
                                {
                                    IdRestaurante = (int)reader["IdRestaurante"],
                                    Nombre = reader["Nombre"].ToString(),
                                    Foto = reader["Foto"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    Latitud = (double)reader["Latitud"],
                                    Longitud = (double)reader["Longitud"]
                                });
                            }
                        }
                    }
                }
                return  restaurantes;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public RestauranteModel GetId(string ConnectionString, int id)
        {
            RestauranteModel restaurante = new RestauranteModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "SELECT * FROM Restaurante WHERE IdRestaurante = @Id";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                restaurante = new RestauranteModel
                                {
                                    IdRestaurante = (int)reader["IdRestaurante"],
                                    Nombre = reader["Nombre"].ToString(),
                                    Foto = reader["Foto"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    Latitud = (double)reader["Latitud"],
                                    Longitud = (double)reader["Longitud"]
                                };
                            }
                        }
                    }
                }
                return restaurante;
            }
            catch (Exception)
            {
                return  null;
            }
        }


        public ResponseModel Insert(string ConnectionString)
        {
            object newId;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "INSERT INTO Restaurante (Nombre, Foto, Direccion, Latitud, Longitud) VALUES (@Nombre , @Foto, @Direccion, @Latitud, @Longitud) SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                        cmd.Parameters.AddWithValue("@Foto", this.Foto);
                        cmd.Parameters.AddWithValue("@Direccion", this.Direccion);
                        cmd.Parameters.AddWithValue("@Longitud", this.Longitud);
                        cmd.Parameters.AddWithValue("@Latitud", this.Latitud);
                        newId = cmd.ExecuteScalar();
                        if (newId != null && newId.ToString().Length > 0)
                        {
                            return new ResponseModel
                            {
                                IsSucces = true,
                                Message = "Restaurante Registrado con exito",
                                Response = newId
                            };
                        }
                        else
                        {
                            return new ResponseModel
                            {
                                IsSucces = false,
                                Message = "Se generó un error al registrar el restaurante",
                                Response = null
                            };
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = $"Error al registrar Restaurante ({ex})",
                    Response = null
                };
            }
        }

        public ResponseModel Update(string ConnectionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "UPDATE Restaurante SET Nombre=@Nombre, Foto=@Foto, Direccion=@Direccion, Latitud=@Latitud, Longitud=@Longitud WHERE IdRestaurante=@Id;";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                        cmd.Parameters.AddWithValue("@Foto", this.Foto);
                        cmd.Parameters.AddWithValue("@Direccion", this.Direccion);
                        cmd.Parameters.AddWithValue("@Longitud", this.Longitud);
                        cmd.Parameters.AddWithValue("@Latitud", this.Latitud);
                        cmd.Parameters.AddWithValue("@Id", this.IdRestaurante);
                        cmd.ExecuteNonQuery();
                        return new ResponseModel
                        {
                            IsSucces = true,
                            Message = "Restaurante actualizado con exito",
                            Response = this.IdRestaurante
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = $"Error al actualizar Restaurante ({ex})",
                    Response = null
                };
            }
        }

        public ResponseModel Delete(string ConnectionString, int Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "DELETE FROM Restaurante WHERE IdRestaurante = @Id;";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdRestaurante", Id);
                        cmd.ExecuteNonQuery();
                        return new ResponseModel
                        {
                            IsSucces = true,
                            Message = "Restaurante Eliminado con exito",
                            Response = Id
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = $"Error al registrar Restaurante ({ex})",
                    Response = null
                };
            }
        }
    }
}

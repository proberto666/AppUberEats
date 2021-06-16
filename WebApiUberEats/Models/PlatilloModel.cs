using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUberEats.Models
{
    public class PlatilloModel
    {
        public int IdPlatillo { get; set; }

        public string Nombre { get; set; }

        public double Precio { get; set; }

        public string Foto { get; set; }

        public int IdRestaurante { get; set; }

        public string NombreRestaurante { get; set; }

        public ResponseModel GetId(string ConnectionString, int id)
        {
            try
            {

                List<PlatilloModel> ListaPlatillos = new List<PlatilloModel>();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "Select p.IdPlatillo, p.NombrePlatillo, p.Foto, p.precio, r.IdRestaurante, r.Nombre from Platillo p INNER JOIN Restaurante r ON r.IdRestaurante = p.IdRestaurante WHERE p.IdRestaurante = @Id";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            { 
                                ListaPlatillos.Add(new PlatilloModel
                                {
                                    IdRestaurante = (int)reader["IdRestaurante"],
                                    NombreRestaurante = reader["Nombre"].ToString(),
                                    Nombre = reader["NombrePlatillo"].ToString(),
                                    Precio = (double)reader["Precio"],
                                    IdPlatillo = (int)reader["IdPlatillo"],
                                    Foto = reader["Foto"].ToString()
                                });
                            }
                        }
                    }
                }

                return new ResponseModel
                {
                    IsSucces = true,
                    Message = "Menu obtenido con exito",
                    Response = ListaPlatillos
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = $"Error al obtener Restaurantes ({ex})",
                    Response = null
                };
            }
        }


        public ResponseModel Insert(string ConnectionString)
        {
            try
            {
                object newId;
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "Insert into Platillo (NombrePlatillo, Foto, Precio, IdRestaurante) Values (@Nombre, @Foto, @Precio, @IdRestaurante)  SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                        cmd.Parameters.AddWithValue("@Foto", this.Foto);
                        cmd.Parameters.AddWithValue("@Precio", this.Precio);
                        cmd.Parameters.AddWithValue("@IdRestaurante", this.IdRestaurante);
                        newId = cmd.ExecuteScalar();
                        if (newId != null && newId.ToString().Length > 0)
                        {
                            return new ResponseModel
                            {
                                IsSucces = true,
                                Message = "Platillo registrado con exito",
                                Response = newId
                            };
                        }
                        else
                        {
                            return new ResponseModel
                            {
                                IsSucces = false,
                                Message = "Error al registrar el platillo",
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
                    Message = $"Error al registrar platillo ({ex})",
                    Response = null
                };
            }
        }

        public ResponseModel Update(string ConnectionString, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "UPDATE Platillo SET NombrePlatillo=@Nombre, Foto=@Foto, Precio=@Precio WHERE IdPlatillo = @Id ";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Nombre", this.Nombre);
                        cmd.Parameters.AddWithValue("@Foto", this.Foto);
                        cmd.Parameters.AddWithValue("@Precio", this.Precio);
                        cmd.Parameters.AddWithValue("@IdRestaurante", this.IdRestaurante);
                        cmd.ExecuteNonQuery();
                        return new ResponseModel
                        {
                            IsSucces = true,
                            Message = "Platillo actualizado con exito",
                            Response = id
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = $"Error al registrar platillo ({ex})",
                    Response = null
                };
            }
        }

        public ResponseModel Delete(string ConnectionString, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "DELETE FROM Platillo WHERE IdPlatillo = @Id";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                        return new ResponseModel
                        {
                            IsSucces = true,
                            Message = "Platillo eliminado con exito",
                            Response = id
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSucces = false,
                    Message = $"Error al eliminar platillo ({ex})",
                    Response = null
                };
            }
        }

    }
}

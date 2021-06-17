using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUberEats.Models
{
    public class NegocioModel
    {
        public int NumNegocio { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }

        public int IdRestaurante { get; set; }

        public NegocioModel GetUsario(string ConnectionString, string usuario)
        {
            try
            {
                NegocioModel negocio = new NegocioModel();
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string tsql = "SELECT * FROM Negocio WHERE Usuario = @Usuario";
                    using (SqlCommand cmd = new SqlCommand(tsql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                negocio = new NegocioModel
                                {
                                    NumNegocio = (int)reader["NumNegocio"],
                                    Usuario = reader["Usuario"].ToString(),
                                    Contrasena = reader["Contrasena"].ToString(),
                                    IdRestaurante = (int)reader["IdRestaurante"]
                                };
                            }
                        }
                    }
                }
                return  negocio;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

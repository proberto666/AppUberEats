using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUberEats.Models
{
    public class NegocioModel
    {
        string ConnectionString = "Server=tcp:river-db.database.windows.net,1433;Initial Catalog=UberEatsDB;Persist Security Info=False;User ID=rhy70705;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int NumNegocio { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }

        public RestauranteModel IdRestaurante { get; set; }


    }
}

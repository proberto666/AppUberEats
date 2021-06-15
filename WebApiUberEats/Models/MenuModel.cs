using System.Collections.Generic;

namespace WebApiUberEats.Models
{
    public class MenuModel
    {
        public int IdMenu { get; set; }

        public List<PlatilloModel> ListaPlatillos { get; set; }
    }
}

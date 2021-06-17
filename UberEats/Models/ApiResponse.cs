using System;
using System.Collections.Generic;
using System.Text;

namespace UberEats.Models
{
    class ApiResponse
    {
        public bool IsSucces { get; set; }

        public string Message { get; set; }

        public object Response { get; set; }
    }
}

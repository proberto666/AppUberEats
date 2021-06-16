using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUberEats.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiUberEats.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        public OrdenesController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: api/<OrdenesController>
        [HttpGet]
        public ResponseModel Get()
        {
            return new OrdenesModel().GetAll(Configuration.GetConnectionString("UberEatsDB"));
        }

        // POST api/<OrdenesController>
        [HttpPost]
        public ResponseModel Post([FromBody] OrdenesModel orden)
        {
            return orden.Insert(Configuration.GetConnectionString("UberEatsDB"));
        }

    }
}

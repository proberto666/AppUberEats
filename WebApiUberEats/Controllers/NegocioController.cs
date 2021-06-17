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
    public class NegocioController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        public NegocioController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // GET api/<NegocioController>/5
        [HttpGet("{usuario}")]
        public NegocioModel Get(string usuario)
        {
            return new NegocioModel().GetUsario(Configuration.GetConnectionString("UberEatsDB"), usuario);
        }
    }
}

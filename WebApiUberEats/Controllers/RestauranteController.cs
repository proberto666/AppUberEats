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
    public class RestauranteController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        public RestauranteController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: api/<RestauranteController>
        [HttpGet]
        public ResponseModel Get()
        {
            return new RestauranteModel().GetAll(Configuration.GetConnectionString("UberEatsDB"));
        }

        // GET api/<RestauranteController>/5
        [HttpGet("{id}")]
        public ResponseModel Get(int id)
        {
            return new RestauranteModel().GetId(Configuration.GetConnectionString("UberEatsDB"), id);
        }

        // POST api/<RestauranteController>
        [HttpPost]
        public ResponseModel Post([FromBody] RestauranteModel restaurante)
        {
            return restaurante.Insert(Configuration.GetConnectionString("UberEatsDB"));
        }

        // PUT api/<RestauranteController>/5
        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] RestauranteModel restaurante)
        {
            return restaurante.Update(Configuration.GetConnectionString("UberEatsDB"), id);
        }

        // DELETE api/<RestauranteController>/5
        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            return new RestauranteModel().Delete(Configuration.GetConnectionString("UberEatsDB"),id);
        }
    }
}

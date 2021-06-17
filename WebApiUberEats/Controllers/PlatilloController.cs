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
    public class PlatilloController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        public PlatilloController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // GET api/<PlatilloController>/5
        [HttpGet("{id}")]
        public List<PlatilloModel> Get(int id)
        {
            return new PlatilloModel().GetId(Configuration.GetConnectionString("UberEatsDB"), id) ;
        }

        // POST api/<PlatilloController>
        [HttpPost]
        public ResponseModel Post([FromBody] PlatilloModel platillo)
        {
            return platillo.Insert(Configuration.GetConnectionString("UberEatsDB"));
        }

        // PUT api/<PlatilloController>/5
        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] PlatilloModel platillo)
        {
            return platillo.Update(Configuration.GetConnectionString("UberEatsDB"), id);
        }

        // DELETE api/<PlatilloController>/5
        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            return new PlatilloModel().Delete(Configuration.GetConnectionString("UberEatsDB"), id);
        }
    }
}

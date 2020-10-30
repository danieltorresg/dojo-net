using dojo_net.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dojo_net.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DecimalController : ControllerBase
    {
        // GET: api/<DecimalController>
        [HttpGet]
        public IActionResult Get()
        {
            DecToRom rpDtR = new DecToRom();
            return Ok(rpDtR.listaNumeros());
        }

        // GET api/<DecimalController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DecToRom rpDtR = new DecToRom();

            var number = rpDtR.ObtenerNumero(id);

            if (number == null)
            {
                var nf = NotFound("El número " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(number);
        }

        // POST api/<DecimalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DecimalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DecimalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

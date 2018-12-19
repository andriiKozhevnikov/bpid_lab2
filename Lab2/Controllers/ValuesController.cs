using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab2.Services;
using System.Text;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RsaController : ControllerBase
    {
        private RSAService RSAService { get; set; }

        public RsaController(RSAService RSAService) : base()
        {
            this.RSAService = RSAService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost]
        public void Decrypt(string dataBase64)
        {
            byte[] dataBytes = Convert.FromBase64String(dataBase64);

            byte[] decryptedData = RSAService.Decrypt(dataBytes);

            string message = Encoding.UTF8.GetString(decryptedData);
        }
    }
}

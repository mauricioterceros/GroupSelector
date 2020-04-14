using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/Student
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "Pedro", "Ana" };
        }

        // POST: api/Student
        [HttpPost]
        public void Post([FromBody] string value) // "Juan"
        {
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) // CI:6405555
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id) // CI:65008816
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITEST.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITEST.Controllers
{
    [Route("api")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/Student
        [HttpGet]
        [Route("student")]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "Pedro", "Ana" };
        }
                
        // DOCUMENTATION ABOUT HTTP REQUEST:
        // HTTP Request => Server //// LOADING //// Server => HTTP Response
        // QueryParams (URL) => http://localhost:9000/students?course=certi&orderBy=name 
        // Headers => METHOD (PUT/POST/GET/DELTE....) //// Authorization (user/pass) ///// SessionInfo (encrypt / JWT) / Other
        // Body => Entities a.k.a data
        


        // POST: api/Student
        [HttpPost]
        [Route("student")]
        // public void Post([FromQuery]string course, [FromQuery]string orderBy)
        public void Post([FromBody]Student newStudentDTO)
        {
            // Presentation LAYER
            // ==================
            Console.WriteLine("from post => " + newStudentDTO.Name + " - " + newStudentDTO.Email);
            // _studentBusinessLogic.AddNewStudent(newStudentDTO); ===> Calc CODIGO Student



            // Business Logic LAYER (Generates NEW CODE)
            // ========================================
            //
            // Student newStudent = new Student(newStudentDTO.name, newStudentDTO.Email, newCode()); ===> Student DB Model
            // dbLayer.AddStudent(newStudent)


            // Database LAYER =====> Service SINGLETON
            // =======================================
            //
            // Global LIST Student = studentsListDB =====> a.k.a DATABASE
            //
            // 
            // public void AddStudent(Student newStudent) 
            // { 
            //    studentsListDB.Add(newStudent); 
            // }
        }

        // PUT: api/Student/12345
        [HttpPut]
        [Route("student/{id}")]
        public void Put([FromBody]Student studentToUpdate, int id) // id=Code:12345
        {
            Console.WriteLine("from post => " + studentToUpdate.Name + " - " + studentToUpdate.Email + " - " + id);
            // _studentBusinessLogic.UpdateStudentById(id, studentToUpdate); ===> UPDATES ACTIONS
            // _productsBL.UpdateProductById(id, productToUpdate); ===> UPDATES ACTIONS            
        }

        [HttpPut]
        [Route("student/name/{name}")]
        public void Put([FromBody]Student studentToUpdate, string name) // id=Code:12345
        {
            Console.WriteLine("from post => " + studentToUpdate.Name + " - " + studentToUpdate.Email + " - " + name);
            // _studentBusinessLogic.UpdateStudentByName(id, studentToUpdate); ===> UPDATES ACTIONS
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("student/{id}")]
        public void Delete(int id) // CI:65008816
        {
            Console.WriteLine("from post =>  - " + id);
            // _studentBusinessLogic.DeleteStudentById(id); ===> UPDATES ACTIONS
        }
    }
}

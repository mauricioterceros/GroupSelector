using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// Add this to use IConfiguration
using Microsoft.Extensions.Configuration;

using APITEST.BusinessLogic;
using APITEST.DTOModels;
using Microsoft.Extensions.Logging;

namespace APITEST.Controllers
{
    [Route("api")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic, IConfiguration config)
        {
            _studentLogic = studentLogic;
        }


        // GET: api/Student
        [HttpGet]
        [Route("student")]
        public List<StudentDTO> GetAll()
        {
            // TRASIENT => _studentLogic = new StudentLogic();
            // more linessss
            // _studentLogic.ValidateData();
            // _studentLogic.Add();
            // _studentLogic.Delete();
            // _studentLogic.Add();
            // _studentLogic.Add();
            // more linessss

            return _studentLogic.GetAll(); // will return 2 students
            // TRASIENT => ~StudentLogic(); // Destroy / if not destroy will have MemoryLeaks
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
        public StudentDTO Post([FromBody]StudentDTO newStudentDTO)
        {
            // Presentation LAYER
            // ==================
            Console.WriteLine("from post => " + newStudentDTO.Name + " - " + newStudentDTO.Email);
            StudentDTO newStudent = _studentLogic.AddNewStudent(newStudentDTO);

            return newStudent;



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
        public void Put([FromBody]StudentDTO studentToUpdate, int id) // id=Code:12345
        {
            Console.WriteLine("from post => " + studentToUpdate.Name + " - " + studentToUpdate.Email + " - " + id);
            // _studentBusinessLogic.UpdateStudentById(id, studentToUpdate); ===> UPDATES ACTIONS
            // _productsBL.UpdateProductById(id, productToUpdate); ===> UPDATES ACTIONS            
        }

        [HttpPut]
        [Route("student/name/{name}")]
        public void Put([FromBody]StudentDTO studentToUpdate, string name) // id=Code:12345
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

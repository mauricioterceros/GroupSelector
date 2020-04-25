using System;
using System.Collections.Generic;
using System.Text;

using APITEST.Database.Models;
using APITEST.Database;
using APITEST.DTOModels;

namespace APITEST.BusinessLogic
{
    public class StudentLogic : IStudentLogic
    {
        private readonly IStudentDatabase _studentDB;

        public StudentLogic(IStudentDatabase studentDB) 
        {
            _studentDB = studentDB;
        }
        public StudentDTO AddNewStudent(StudentDTO newStudent)
        {
            // Mappers => function: Student.FromDTOtoEntity
            Student student = new Student();
            student.Email = newStudent.Email;
            student.Name = newStudent.Name;
            
            // Logic calculation            
            student.Code = new Random().Next(0, 99999);

            // Add to DB
            Student studentInDB = _studentDB.AddNew(student);

            // Mappers => function: Student.FromEntityToDTO
            return new StudentDTO()
            {
                Name = studentInDB.Name,
                Email = studentInDB.Email
            };
        }
        public void UpdateStudent(StudentDTO studentToUpdate)
        {
        }
        public void DeleteSutdent(int code)
        {
        }
        public List<StudentDTO> GetAll()
        {
            List<Student> allStudents = _studentDB.GetAll();
            List<StudentDTO> students = new List<StudentDTO>();

            // Mappers
            foreach (Student student in allStudents)
            {
                students.Add(
                    new StudentDTO()
                    {
                        Name = student.Name,
                        Email = student.Email
                    }
                );
            }

            return students;
        }
    }
}

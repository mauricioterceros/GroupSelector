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
        public void AddNewStudent(StudentDTO newStudent)
        {
            // Mappers
            Student student = new Student();
            student.Email = newStudent.Email;
            student.Name = newStudent.Name;
            
            // Logic calculation            
            student.Code = new Random().Next(0, 99999);

            // Add to DB
            _studentDB.AddNew(student);
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

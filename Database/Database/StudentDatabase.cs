using APITEST.Database;
using System;
using System.Collections.Generic;
using System.Text;

using APITEST.Database.Models;

namespace APITEST.Database
{
    public class StudentDatase : IStudentDatabase
    {
        private List<Student> Students 
        {
            get;
            set;
        }

        public StudentDatase() 
        {
            Students = new List<Student>();
        }

        public void AddNew(Student newStudent)
        {
            Students.Add(newStudent);
        }
        public void Update(Student studentToUpdate)
        {
        }
        public void Delete(int code)
        {
        }
        public List<Student> GetAll()
        {
            return Students;
        }
    }
}

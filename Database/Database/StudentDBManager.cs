using APITEST.Database;
using System;
using System.Collections.Generic;
using System.Text;

using APITEST.Database.Models;

namespace APITEST.Database
{
    public class StudentDBManager : IStudentDBManager
    {
        private List<Student> Students 
        {
            get;
            set;
        }

        public StudentDBManager() 
        {
            Students = new List<Student>();
        }

        public Student AddNew(Student newStudent)
        {
            Students.Add(newStudent);
            return newStudent;
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

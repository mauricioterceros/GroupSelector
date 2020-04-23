using System;
using System.Collections.Generic;
using System.Text;

using APITEST.Database.Models;

namespace APITEST.Database
{
    public interface IStudentDatabase
    {
        void AddNew(Student newStudent);
        void Update(Student studentToUpdate);
        void Delete(int code);
        List<Student> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

using APITEST.Database.Models;

namespace APITEST.Database
{
    public interface IStudentDBManager : IDBManager
    {
        Student AddNew(Student newStudent);
        Student Update(Student studentToUpdate);
        bool Delete(int code);
        List<Student> GetAll();
    }
}

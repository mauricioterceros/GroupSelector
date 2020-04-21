using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITEST.Database.Models;

namespace APITEST.Database
{
    public interface IStudentTableDB
    {
        // Get all registries from STUDENT TABLE in my local DB
        public List<Student> GetAll();
    }
}

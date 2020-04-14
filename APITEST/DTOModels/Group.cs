using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITEST.DTOModels
{
    public class Group
    {
        // Properties
        // Group 1 / 2 / 3 / 4 / 5
        public string GroupName { get; set; }
        // "John Smith", "Paul", ......
        public List<Student> Students { get; set; }
        //getStudents / setStudents
    }
}

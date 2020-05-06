using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITEST.DTOModels
{
    public class GroupStudentDTO
    {
        // Properties
        // Group 1 / 2 / 3 / 4 / 5
        public int GroupId { get; set; }
        // "John Smith", "Paul", ......
        public List<StudentDTO> Students { get; set; }
        //getStudents / setStudents
    }
}

using System.Collections.Generic;

namespace APITEST.Database.Models
{
    public class GroupStudent
    {
        public int GroupId { get; set; }
        public List<Student> Students { get; set; }        
    }
}
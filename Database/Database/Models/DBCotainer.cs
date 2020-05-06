using System.Collections.Generic;

namespace APITEST.Database.Models
{
    public class DBCotainer
    {
        public List<Student> Student { get; set; }
        public List<GroupStudent> GroupStudent { get; set; }
        public List<Group> Group { get; set; }
    }
}

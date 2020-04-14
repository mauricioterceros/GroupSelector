using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITEST.DTOModels;

using APITEST.Database;

namespace APITEST.BusinessLogic
{
    public class GroupLogic : IGroupLogic
    {
        private readonly IStudentTableDB _studentTableDB;

        public GroupLogic(IStudentTableDB studentTableDB) 
        {
            _studentTableDB = studentTableDB;
        }
        /// <summary>
        /// 5 grupos => 
        /// 3 grupos de 4 integrantes 
        /// & 
        /// 2 grupos de 5 integrantes
        /// </summary>
        /// <returns></returns>
        public List<Group> GetGroupsCERTClass() 
        {
            // Retrieve all students from database
            List<Database.Models.Student> allStudents = _studentTableDB.GetAll();
            // Process all stundents
            return new List<Group>();
        }
    }
}

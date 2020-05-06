using System;
using System.Collections.Generic;
using System.Text;
using APITEST.Database.Models;

namespace APITEST.Database
{
    public interface IGroupStudentDBManager
    {
        GroupStudent AddNew(GroupStudent newGroupStudent);
        GroupStudent Update(GroupStudent groupStudentToUpdate);
        bool Delete(int groupId);
        List<GroupStudent> GetAll();
    }
}

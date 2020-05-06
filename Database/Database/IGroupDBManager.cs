using System.Collections.Generic;
using APITEST.Database.Models;

namespace APITEST.Database
{
    public interface IGroupDBManager : IDBManager
    {
        Group AddNew(Group newGroup);
        Group Update(Group groupToUpdate);
        bool Delete(int groupId);
        List<Group> GetAll();
    }
}

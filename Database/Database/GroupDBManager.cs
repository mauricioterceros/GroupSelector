using APITEST.Database.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace APITEST.Database
{
    public class GroupDBManager : IGroupDBManager, IDBManager
    {
        private readonly IConfiguration _configuration;
        private string _dbPath;
        private List<Group> _groupList;
        private DBCotainer _dbContainer;

        public GroupDBManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbPath = _configuration.GetSection("Database").GetSection("connectionString").Value;
            _dbContainer = JsonConvert.DeserializeObject<DBCotainer>(File.ReadAllText(_dbPath));
            _groupList = _dbContainer.Group;
        }
        public Group AddNew(Group newGroup)
        {
            _groupList.Add(newGroup);
            SaveChanges();
            return newGroup;
        }

        public bool Delete(int groupId)
        {
            Group groupStudentToDelete = _groupList.Find
            (
                group => group.GroupId == groupId
            );
            bool wasRemoved = _groupList.Remove(groupStudentToDelete);
            SaveChanges();
            return wasRemoved;
        }

        public List<Group> GetAll()
        {
            return _groupList;
        }

        public Group Update(Group groupToUpdate)
        {
            Group groupFound = _groupList.Find
            (
                groupStundent => groupStundent.GroupId == groupToUpdate.GroupId
            );
            groupFound.GroupId = groupToUpdate.GroupId;
            groupFound.GroupName = groupToUpdate.GroupName;
            groupFound.MaxNumberOfStudents = groupToUpdate.MaxNumberOfStudents;
            SaveChanges();
            return groupFound;
        }
        public void SaveChanges() 
        {
            File.WriteAllText(_dbPath, JsonConvert.SerializeObject(_dbContainer));
        }
    }
}

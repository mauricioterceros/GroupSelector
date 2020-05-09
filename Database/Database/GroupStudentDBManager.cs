using System;
using System.Collections.Generic;
// IConfiguration
using Microsoft.Extensions.Configuration;
// File Read
using System.IO;
// Json file reader
using Newtonsoft.Json;

using APITEST.Database.Models;
using Microsoft.Extensions.Logging;
using Serilog;

namespace APITEST.Database
{
    public class GroupStudentDBManager : IGroupStudentDBManager
    {
        private readonly IConfiguration _configuration;
        private string _dbPath;
        private List<GroupStudent> _groupStudentList;
        private DBContext _dbContainer;
        public readonly ILogger<GroupStudentDBManager> _logger;
        public GroupStudentDBManager(IConfiguration config)
        {
            _configuration = config;
            InitDBContext();
        }

        public void InitDBContext() 
        {
            _dbPath = _configuration.GetSection("Database").GetSection("connectionString").Value;
            Log.Logger.Information("test");
            _dbContainer = JsonConvert.DeserializeObject<DBContext>(File.ReadAllText(_dbPath));
            _groupStudentList = _dbContainer.GroupStudent;
        }

        public void SaveChanges()
        {
            File.WriteAllText(_dbPath, JsonConvert.SerializeObject(_dbContainer));
        }
        public GroupStudent AddNew(GroupStudent newGroupStudent)
        {
            _groupStudentList.Add(newGroupStudent);
            SaveChanges();
            return newGroupStudent;
        }

        public bool Delete(int groupId)
        {
            GroupStudent groupStudentToDelete = _groupStudentList.Find
            (
                groupStundent => groupStundent.GroupId == groupId
            );
            bool wasRemoved = _groupStudentList.Remove(groupStudentToDelete);
            SaveChanges();
            return wasRemoved;
        }

        public  List<GroupStudent> GetAll()
        {
            return _groupStudentList;
        }

        public GroupStudent Update(GroupStudent groupStudentToUpdate)
        {
            GroupStudent groupFound = _groupStudentList.Find
            (
                groupStundent => groupStundent.GroupId == groupStudentToUpdate.GroupId
            );
            groupFound.GroupId = groupStudentToUpdate.GroupId;
            groupFound.Students = groupStudentToUpdate.Students;
            SaveChanges();            
            return groupFound; 
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;
using APITEST.Database.Models;

namespace APITEST.Database
{
    public class StudentDBManager : IStudentDBManager
    {
        private readonly IConfiguration _configuration;

        private string _dbPath;
        private DBContext _dbContext;
        private List<Student> _studentList;

        public StudentDBManager(IConfiguration configuration) 
        {
            _configuration = configuration;
            InitDBContext();
        }

        public void InitDBContext()
        {
            _dbPath = _configuration.GetSection("Database").GetSection("connectionString").Value;
            _dbContext = JsonConvert.DeserializeObject<DBContext>(File.ReadAllText(_dbPath));
            _studentList = _dbContext.Student;
        }

        public void SaveChanges()
        {
            File.WriteAllText(_dbPath, JsonConvert.SerializeObject(_dbContext));
        }

        public List<Student> GetAll()
        {
            return _studentList;
        }

        public Student AddNew(Student newStudent)
        {
            // SaveChanges()
            throw new NotImplementedException();
        }
        public Student Update(Student studentToUpdate)
        {
            // SaveChanges()
            throw new NotImplementedException();
        }
        public bool Delete(int code)
        {
            // SaveChanges()
            throw new NotImplementedException();
        }
    }
}

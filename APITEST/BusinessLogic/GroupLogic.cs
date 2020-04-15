using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITEST.DTOModels;

using APITEST.Database;
using APITEST.Database.Models;

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
        public List<GroupDTO> GetGroupsCERTClass() 
        {
            // Retrieve all students from database
            List<Student> allStudents = _studentTableDB.GetAll();
            
            List<GroupDTO> groupToAssign = GetEmptyGroups();

            List<Student> unOrderStudentList = allStudents.OrderBy(student => new Random().Next()).ToList();
            // Process all stundents
            foreach (Student student in unOrderStudentList)
            {
                // Student choose a group
                int groupNumber = GetAGroupNumber();
                assignToGroup(groupNumber, groupToAssign, student);
            }
            
            return groupToAssign;
        }

        private List<GroupDTO> GetEmptyGroups() 
        {
            List<GroupDTO> emptyGroups = new List<GroupDTO>()
            {
                new GroupDTO() {GroupName="Grupo 1", Students=new List<StudentDTO>(), MaxNumberOfStudents=4 },
                new GroupDTO() {GroupName="Grupo 2", Students=new List<StudentDTO>(), MaxNumberOfStudents=4 },
                new GroupDTO() {GroupName="Grupo 3", Students=new List<StudentDTO>(), MaxNumberOfStudents=4 },
                new GroupDTO() {GroupName="Grupo 4", Students=new List<StudentDTO>(), MaxNumberOfStudents=5 },
                new GroupDTO() {GroupName="Grupo 5", Students=new List<StudentDTO>(), MaxNumberOfStudents=5 },
            };
            return emptyGroups;
        }

        private int GetAGroupNumber() 
        {
            return new Random().Next(1, 6);
        }

        private void assignToGroup(int groupNumber, List<GroupDTO> groupsToAssign, Student student) 
        {
            GroupDTO groupToAssign = groupsToAssign.Find(group => group.GroupName.Contains(groupNumber.ToString()));

            if (groupToAssign != null && groupToAssign.Students.Count < groupToAssign.MaxNumberOfStudents)
            {
                groupToAssign.Students.Add(new StudentDTO() { Name = student.Name });
                return;
            }
            else 
            {
                int newGroupNumber = GetAGroupNumber();
                assignToGroup(newGroupNumber, groupsToAssign, student);
            }
        }
    }
}

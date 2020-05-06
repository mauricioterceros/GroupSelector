using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITEST.DTOModels;

using APITEST.Database;
using APITEST.Database.Models;
using System.Runtime.InteropServices.WindowsRuntime;

namespace APITEST.BusinessLogic
{
    public class GroupStudentLogic : IGroupStudentLogic
    {
        private readonly IStudentDBManager _studentDBManager;
        private readonly IGroupStudentDBManager _groupStudentDBManages;
        private readonly IGroupDBManager _groupDBManager;

        public GroupStudentLogic(IStudentDBManager studentDBManager, IGroupStudentDBManager groupStudentDBManager, IGroupDBManager groupDBManager) 
        {
            _studentDBManager = studentDBManager;
            _groupStudentDBManages = groupStudentDBManager;
            _groupDBManager = groupDBManager;
        }

        public List<GroupStudentDTO> GetCurrentGroupStudentList() 
        {
            List<GroupStudent> groupStudentList = _groupStudentDBManages.GetAll();
            return DTOUtil.MapGroupStudentDTOList(groupStudentList);
        }

        /// <summary>
        /// 5 grupos => 
        /// 3 grupos de 4 integrantes 
        /// & 
        /// 2 grupos de 5 integrantes
        /// </summary>
        /// <returns></returns>
        public List<GroupStudentDTO> GetNewGroupStudentList() 
        {
            // Retrieve all students from database
            List<Student> allStudents = _studentDBManager.GetAll();

            List<Student> unOrderStudentList = allStudents.OrderBy(student => new Random().Next()).ToList();

            List<GroupStudent> newGroupStudentList = new List<GroupStudent>();
            // Process all stundents
            foreach (Student student in unOrderStudentList)
            {
                // Student choose a group
                int groupNumber = GetAGroupNumber();
                AssignGroup(groupNumber, newGroupStudentList, student);
            }
            
            return DTOUtil.MapGroupStudentDTOList(newGroupStudentList);
        }

        public List<GroupStudentDTO> GetGroupDemoOrder()
        {
            List<GroupStudent> currentGroupStudentList = _groupStudentDBManages.GetAll();
            List<GroupStudent> groupStudentDemoOrder = currentGroupStudentList.OrderBy(group => new Random().Next()).ToList();
            return DTOUtil.MapGroupStudentDTOList(groupStudentDemoOrder);
        }

        private int GetAGroupNumber() 
        {
            return new Random().Next(1, 6);
        }

        private void AssignGroup(int groupNumber, List<GroupStudent> newGroupStudentList, Student studentToAssign) 
        {
            List<Group> allGroups = _groupDBManager.GetAll();
            List<GroupStudent> currentGroupStudentList = _groupStudentDBManages.GetAll();

            Group newGroupToAssign = allGroups.Find(group => group.GroupId == groupNumber);
            
            GroupStudent targetGroupStudent = newGroupStudentList.Find(groupStudent => groupStudent.GroupId == groupNumber);
            GroupStudent currentGroupStudent = currentGroupStudentList.Find
            (
                groupStudent => groupStudent.Students.FindIndex(student => student.Name == studentToAssign.Name) > 0 
            );


            if (
                newGroupToAssign != null && 
                targetGroupStudent.Students.Count < newGroupToAssign.MaxNumberOfStudents &&
                currentGroupStudent.GroupId != targetGroupStudent.GroupId
            )
            {
                targetGroupStudent.Students.Add(new Student() { Name = studentToAssign.Name });
                return;
            }
            else 
            {
                int newGroupNumber = GetAGroupNumber();
                AssignGroup(newGroupNumber, newGroupStudentList, studentToAssign);
            }
        }
    }
}

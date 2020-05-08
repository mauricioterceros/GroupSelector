using System;
using System.Collections.Generic;
using System.Linq;
using APITEST.DTOModels;

using APITEST.Database;
using APITEST.Database.Models;

namespace APITEST.BusinessLogic
{
    public class GroupStudentLogic : IGroupStudentLogic
    {
        private readonly IStudentDBManager _studentDBManager;
        private readonly IGroupStudentDBManager _groupStudentDBManager;
        private readonly IGroupDBManager _groupDBManager;

        public GroupStudentLogic
        (
            IStudentDBManager studentDBManager, 
            IGroupStudentDBManager groupStudentDBManager, 
            IGroupDBManager groupDBManager
        ) 
        {
            _studentDBManager = studentDBManager;
            _groupStudentDBManager = groupStudentDBManager;
            _groupDBManager = groupDBManager;
        }

        public List<GroupStudentDTO> GetCurrentGroupStudentList() 
        {
            List<GroupStudent> groupStudentList = _groupStudentDBManager.GetAll();
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

            List<Student> unOrderStudentList = 
                allStudents.OrderBy(student => new Random().Next()).ToList();

            List<Student> studentsInBigGroupsFirst = 
                unOrderStudentList.OrderBy(student => WasInBigGroup(student) ? 0 : 1).ToList();

            List<GroupStudent> newGroupStudentList = new List<GroupStudent>();
            // Process all stundents
            foreach (Student student in studentsInBigGroupsFirst)
            {
                int groupNumnber;
                if (WasInBigGroup(student))
                {
                    groupNumnber = GetAGroupNumber(1, 3);
                }
                else
                {
                    groupNumnber = GetAGroupNumber(1, 5);
                }
                AssignGroup(groupNumnber, newGroupStudentList, student);
            }
            
            return DTOUtil.MapGroupStudentDTOList(newGroupStudentList);
        }

        public List<GroupStudentDTO> GetGroupDemoOrder()
        {
            List<GroupStudent> currentGroupStudentList = _groupStudentDBManager.GetAll();
            List<GroupStudent> groupStudentDemoOrder = currentGroupStudentList.OrderBy(group => new Random().Next()).ToList();
            return DTOUtil.MapGroupStudentDTOList(groupStudentDemoOrder);
        }

        private int GetAGroupNumber(int start, int count, int excludeNumber = -1) 
        {
            var exclude = new HashSet<int>() { excludeNumber };
            var range = Enumerable.Range(start, count).Where(i => !exclude.Contains(i)).ToList();

            var rand = new Random();
            int index = rand.Next(0, range.Count);
            return range.ElementAt(index);
        }

        private void AssignGroup(int groupNumber, List<GroupStudent> newGroupStudentList, Student studentToAssign) 
        {
            List<GroupStudent> currentGroupStudentList = _groupStudentDBManager.GetAll();
            List<Group> allGroups = _groupDBManager.GetAll();
                        
            Group targetGroup = allGroups.Find(group => group.GroupId == groupNumber);
            GroupStudent targetGroupStudent = newGroupStudentList.Find(groupStudent => groupStudent.GroupId == targetGroup.GroupId);
            if (targetGroupStudent == null) 
            {
                targetGroupStudent = new GroupStudent()
                {
                    GroupId = targetGroup.GroupId,
                    Students = new List<Student>()
                };
                newGroupStudentList.Add(targetGroupStudent);
            }

            if 
            (
                targetGroup != null && 
                targetGroupStudent.Students.Count < targetGroup.MaxNumberOfStudents
            )
            {
                targetGroupStudent.Students.Add(studentToAssign);
                return;
            }
            else 
            {
                int groupNumnber;
                if (WasInBigGroup(studentToAssign))
                {
                    groupNumnber = GetAGroupNumber(1, 3, targetGroup.GroupId);
                }
                else
                {
                    groupNumnber = GetAGroupNumber(1, 5, targetGroup.GroupId);
                }
                AssignGroup(groupNumnber, newGroupStudentList, studentToAssign);
            }
        }

        private bool WasInBigGroup(Student studentToReview) 
        {
            List<GroupStudent> currentGroupStudentList = _groupStudentDBManager.GetAll();
            List<Group> allGroups = _groupDBManager.GetAll();
            GroupStudent currentGroupStudent = null;
            foreach (GroupStudent groupStudent in currentGroupStudentList)
            {
                if (groupStudent.Students.Find(student => student.Name == studentToReview.Name) != null)
                {
                    currentGroupStudent = groupStudent;
                    break;
                }
            }

            Group currentGroup = allGroups.Find(group => group.GroupId == currentGroupStudent.GroupId);
            return currentGroup.MaxNumberOfStudents == 5;
        }
    }
}

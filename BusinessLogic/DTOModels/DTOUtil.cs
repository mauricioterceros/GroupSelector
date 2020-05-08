using System;
using System.Collections.Generic;
using System.Text;
using APITEST.DTOModels;
using APITEST.Database.Models;

namespace APITEST.BusinessLogic
{
    public class DTOUtil
    {
        public static List<StudentDTO> MapStudentDTOList(List<Student> studentList) 
        {
            List<StudentDTO> studentDTOList = new List<StudentDTO>();

            foreach (Student student in studentList)
            {
                studentDTOList.Add
                (
                    new StudentDTO()
                    {
                        Name = student.Name
                    }
                );
            }

            return studentDTOList;
        }

        public static List<GroupDTO> MapGroupDTOList(List<Group> groupList)
        {
            List<GroupDTO> groupDTOList = new List<GroupDTO>();
            foreach (Group group in groupList)
            {
                groupDTOList.Add
                (
                    new GroupDTO()
                    {
                        GroupId = group.GroupId,
                        GroupName = group.GroupName,
                        MaxNumberOfStudents = group.MaxNumberOfStudents
                    }
                );
            }
            return groupDTOList;
        }

        public static List<GroupStudentDTO> MapGroupStudentDTOList(List<GroupStudent> groupStudentList)
        {
            List<GroupStudentDTO> groupStudentDTOList = new List<GroupStudentDTO>();

            foreach (GroupStudent groupStudent in groupStudentList)
            {   
                groupStudentDTOList.Add
                (
                    new GroupStudentDTO()
                    {
                        GroupId = groupStudent.GroupId,
                        Students = MapStudentDTOList(groupStudent.Students)
                    }
                );
            }
            return groupStudentDTOList;
        }
    }
}

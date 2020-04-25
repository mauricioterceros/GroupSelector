using APITEST.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITEST.BusinessLogic
{
    public interface IStudentLogic
    {
        StudentDTO AddNewStudent(StudentDTO newStudent);
        void UpdateStudent(StudentDTO studentToUpdate);
        void DeleteSutdent(int code);
        List<StudentDTO> GetAll();
    }
}

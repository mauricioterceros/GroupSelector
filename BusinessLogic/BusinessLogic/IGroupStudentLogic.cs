using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITEST.DTOModels;

namespace APITEST.BusinessLogic
{
    // public => public to ALL
    // internal =>  assembly ("Project = webapi,classLib,other")
    // private, protected
    public interface IGroupStudentLogic
    {
        public List<GroupStudentDTO> GetCurrentGroupStudentList();
        public List<GroupStudentDTO> GetNewGroupStudentList();
        public List<GroupStudentDTO> GetGroupDemoOrder();

        
    }
}

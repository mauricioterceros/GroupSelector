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
    public interface IGroupLogic
    {
        public List<GroupDTO> GetGroupsCERTClass();

        public List<GroupDTO> GetGroupDemoOrder();
    }
}

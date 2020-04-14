using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITEST.DTOModels;

namespace APITEST.BusinessLogic
{
    // public, private, protected, *NEW => internal => assembly
    public interface IGroupLogic
    {
        public List<Group> GetGroupsCERTClass();
    }
}

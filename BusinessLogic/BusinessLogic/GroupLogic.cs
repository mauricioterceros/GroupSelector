using APITEST.Database;
using APITEST.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITEST.BusinessLogic
{
    public class GroupLogic : IGroupLogic
    {
        private readonly IGroupDBManager _groupDBManager;

        public GroupLogic(IGroupDBManager groupDBManager) 
        {
            _groupDBManager = groupDBManager;
        }
        public List<GroupDTO> GetAll()
        {
            return DTOUtil.MapGroupDTOList(_groupDBManager.GetAll());
        }
    }
}

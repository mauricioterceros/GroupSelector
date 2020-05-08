using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using APITEST.BusinessLogic;
using APITEST.DTOModels;

namespace APITEST.Controllers
{
    [Route("api/groups-students")]
    [ApiController]
    public class GroupStudentController : ControllerBase
    {
        private readonly IGroupStudentLogic _groupLogic;
        
        public GroupStudentController(IGroupStudentLogic grouplogic)
        {
            _groupLogic = grouplogic;
        }
        [HttpGet]
        [Route("draw")]
        public IEnumerable<GroupStudentDTO> GetNewGroupStudentList()
        {        
            return _groupLogic.GetNewGroupStudentList();
        }

        [HttpGet]
        [Route("demo/order")]
        public IEnumerable<GroupStudentDTO> GetOrder() 
        {
            return _groupLogic.GetGroupDemoOrder();
        }

        [HttpGet]
        [Route("current")]
        public IEnumerable<GroupStudentDTO> GetCurrentGroupStudentList()
        {
            return _groupLogic.GetCurrentGroupStudentList();
        }
    }
}

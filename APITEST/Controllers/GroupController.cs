using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITEST.BusinessLogic;
using APITEST.DTOModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITEST.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupLogic _groupLogic;
        public GroupController(IGroupLogic groupLogic)
        {
            _groupLogic = groupLogic;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<GroupDTO> GetAll()
        {
            return _groupLogic.GetAll();
        }
    }
}
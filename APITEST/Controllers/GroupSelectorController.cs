using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APITEST.BusinessLogic;
using APITEST.DTOModels;

namespace APITEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupSelectorController : ControllerBase
    {
        private readonly IGroupLogic _groupLogic;

        // public GroupSelectorController(GroupLogic grouplogic)
        // Instead inject Interfaces
        public GroupSelectorController(IGroupLogic grouplogic)
        {
            _groupLogic = grouplogic;
        }
        // GET: api/GroupSelector   CRUD
        // C => Create
        // R => Read
        // U => Update
        // D => Delete
        [HttpGet]
        public IEnumerable<GroupDTO> GetAll() // READ
        {
            // Instead use dependency injection            
            return _groupLogic.GetGroupsCERTClass();
        }        
    }
}

using APITEST.Database;
using APITEST.DTOModels;
using System.Collections.Generic;
using System;

namespace APITEST.BusinessLogic
{
    public class GroupLogic : IGroupLogic
    {
        private readonly IGroupDBManager _groupDBManager;
        // private readonly IProductBackingService _productsBackingService;

        public GroupLogic(IGroupDBManager groupDBManager) //, IProductBackingService productBackingService) 
        {
            _groupDBManager = groupDBManager;
            //_productsBackingService = productBackingService;
        }
        public List<GroupDTO> GetAll()
        {
            return DTOUtil.MapGroupDTOList(_groupDBManager.GetAll());
        }

        public List<ProductDTO> GetAllProducts()
        {
            // return _productsBackingService.GetAll();
            throw new NotImplementedException();
        }
    }
}

using System.Collections.Generic;
using APITEST.DTOModels;

namespace APITEST.BusinessLogic
{
    public interface IGroupLogic
    {
        public List<GroupDTO> GetAll();

        public List<ProductDTO> GetAllProducts();
    }
}

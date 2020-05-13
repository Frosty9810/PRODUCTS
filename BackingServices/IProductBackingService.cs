using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductBackingService
    {
        public Task<List<ProductBsDTO>> GetAllProduct();
    }
}

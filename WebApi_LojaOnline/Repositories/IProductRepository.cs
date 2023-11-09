using WebApi_LojaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_LojaOnline.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductClass>> Get();
        Task<ProductClass> Get(int id);
        Task<ProductClass> Create(ProductClass book);
        Task Update(ProductClass book);
        Task Delete(int id);

    }
}

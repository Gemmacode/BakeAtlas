using BakeAtlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Application.Interface.Repositories
{
    public interface IBakeryProductRepository : IGenericRepository<BakeryProduct>
    {

        List<BakeryProduct> GetBakeryProductAsync();
        void AddBakeryProductAsync(BakeryProduct bakeryProduct);
        void DeleteBakeryProductAsync(BakeryProduct bakeryProduct);
        BakeryProduct GetBakeryProductById(string id);
        void UpdateBakeryProductAsync(BakeryProduct bakeryProduct);
    }
}

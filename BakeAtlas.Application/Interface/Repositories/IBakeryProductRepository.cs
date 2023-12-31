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
        List<BakeryProduct> GetAllBakeryProduct(Expression<Func<BakeryProduct, bool>> customerid);
        void AddBakeryProductAsync(BakeryProduct bakeryProduct);
        void DeleteBakeryProductAsync(BakeryProduct bakeryProduct);
        //void DeleteAllBakeryProductsAsync(List<BakeryProduct> bakeryProducts);
        public List<BakeryProduct> FindBakeryProductAsync(Expression<Func<BakeryProduct, bool>> condition);
        BakeryProduct GetBakeryProductById(string id);
        void UpdateBakeryProductAsync(BakeryProduct bakeryProduct);
    }
}

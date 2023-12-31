using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Domain.Entities;
using BakeAtlas.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Persistence.Repositories
{
    public class BakeryProductRepository : GenericRepository<BakeryProduct>, IBakeryProductRepository
    {
        public BakeryProductRepository (BakeAtlasDbContext context) : base (context) 
        {
        }
        public void AddBakeryProductAsync(BakeryProduct bakeryProduct)
        {
            AddAsync (bakeryProduct);
        }

        public void DeleteAllBakeryProductsAsync(List<BakeryProduct> bakeryProducts)
        {
            DeleteAllAsync(bakeryProducts);
        }

        public void DeleteBakeryProductAsync(BakeryProduct bakeryProduct)
        {
           DeleteAsync (bakeryProduct);
        }

        public List<BakeryProduct> FindBakeryProductAsync(Expression<Func<BakeryProduct, bool>> condition)
        {
            return FindBakeryProductAsync(condition);
        }

        public List<BakeryProduct> GetAllBakeryProduct(Expression<Func<BakeryProduct, bool>> customerid)
        {
            return FindBakeryProductAsync(customerid);
        }

        public List<BakeryProduct> GetBakeryProductAsync()
        {
           return GetAllAsync();
        }

        public BakeryProduct GetBakeryProductById(string id)
        {
            return GetBakeryProductById(id);
        }
        public void UpdateBakeryProductAsync(BakeryProduct bakeryProduct)
        {
            UpdateAsync(bakeryProduct);
        }
    }
}

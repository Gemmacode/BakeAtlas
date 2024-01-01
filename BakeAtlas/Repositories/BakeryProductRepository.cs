using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Domain.Entities;
using BakeAtlas.Persistence.Context;

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

        public List<BakeryProduct> GetBakeryProductAsync()
        {
           return GetAllAsync();
        }

        public BakeryProduct GetBakeryProductById(string id)
        {
            return GetByIdAsync (id);
        }
        public void UpdateBakeryProductAsync(BakeryProduct bakeryProduct)
        {
            UpdateAsync(bakeryProduct);
        }
    }
}

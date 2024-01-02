using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;

namespace BakeAtlas.Application.ServicesImplementation
{
    public class BakeryProductService : IBakeryProductService
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBakeryProductRepository _repository;

        public BakeryProductService(IUnitOfWork unitOfWork, IBakeryProductRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public List<BakeryProduct> GetAllProducts()
        {
            return  _repository.GetBakeryProductAsync();
        }

        public BakeryProduct GetProductById(string productId)
        {
            return _repository.GetByIdAsync(productId);
        }

        public void AddProduct(BakeryProduct product)
        {
            _repository.AddBakeryProductAsync(product);
        }

        public void UpdateProduct(BakeryProduct product)
        {
            _repository.UpdateBakeryProductAsync(product);
        }

        public void DeleteProduct(string productId)
        {
            _repository.DeleteBakeryProductAsync(GetProductById(productId));
        }
    }
}

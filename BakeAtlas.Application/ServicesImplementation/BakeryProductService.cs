using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;

namespace BakeAtlas.Application.ServicesImplementation
{
    public class BakeryProductService : IBakeryProductService
    {
       
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IBakeryProductRepository _repository;

        public BakeryProductService(IUnitOfWork unitOfWork /* IBakeryProductRepository repository*/)
        {
            _unitOfWork = unitOfWork;
            //_repository = repository;
        }

        public List<BakeryProduct> GetAllProducts()
        {

            return _unitOfWork.BakeryProductRepository.GetAllAsync();
            
        }

        public BakeryProduct GetProductById(string productId)
        {

            return _unitOfWork.BakeryProductRepository.GetBakeryProductById(productId);
        }

        public void AddProduct(BakeryProductDTO product)
        {
            var prod = new BakeryProduct
            {
                Id = Guid.NewGuid().ToString(),
                ProductName=product.ProductName,
                ProductDescription=product.ProductDescription,
                ProductPrice=product.ProductPrice,
                ProductQuantity=product.ProductQuantity,
                ProductDiscount=product.ProductDiscount,
                ingredients=product.ingredients,
                UpdatedAt=DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            };
            _unitOfWork.BakeryProductRepository.AddBakeryProductAsync(prod);
            _unitOfWork.SaveChanges();
        }

        public void UpdateProduct(BakeryProductDTO product)
        {
            
                
        }

        public void DeleteProduct(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId)) 
            {
                throw new ArgumentNullException ("Product Id is required");
            };
            var product = _unitOfWork.BakeryProductRepository.GetBakeryProductById(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            _unitOfWork.BakeryProductRepository.DeleteBakeryProductAsync (product);
            _unitOfWork.SaveChanges();
        }
    }
}

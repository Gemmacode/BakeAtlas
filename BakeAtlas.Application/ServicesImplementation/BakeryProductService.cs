using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;

namespace BakeAtlas.Application.ServicesImplementation
{
    public class BakeryProductService : IBakeryProductService
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public BakeryProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public List<BakeryProduct> GetAllProducts()
        {
            return _unitOfWork.BakeryProductRepository.GetAllAsync();
        }

        public BakeryProduct GetProductById(string productId)
        {
            return _unitOfWork.BakeryProductRepository.GetBakeryProductById(productId);
        }

        public void UpdateProduct(string productId, BakeryProductDTO product)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentNullException("Product Id is required");
            }

            var existingProduct = _unitOfWork.BakeryProductRepository.GetBakeryProductById(productId);

            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            // Update the properties of the existing product
            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductDescription = product.ProductDescription;
            existingProduct.ProductPrice = product.ProductPrice;
            existingProduct.ProductQuantity = product.ProductQuantity;
            existingProduct.ProductDiscount = product.ProductDiscount;
            existingProduct.ingredients = product.ingredients;
            existingProduct.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.BakeryProductRepository.UpdateBakeryProductAsync(existingProduct);
            _unitOfWork.SaveChanges();
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

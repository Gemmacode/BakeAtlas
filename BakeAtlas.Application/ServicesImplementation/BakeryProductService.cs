using AutoMapper;
using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;

namespace BakeAtlas.Application.ServicesImplementation
{
    public class BakeryProductService : IBakeryProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BakeryProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AddProduct(BakeryProductDTO productDto)
        {
            var product = _mapper.Map<BakeryProduct>(productDto);
            product.Id = Guid.NewGuid().ToString();
            product.UpdatedAt = DateTime.UtcNow;
            product.CreatedAt = DateTime.UtcNow;

            _unitOfWork.BakeryProductRepository.AddBakeryProductAsync(product);
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

        public void UpdateProduct(string productId, BakeryProductDTO productDto)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentNullException(nameof(productId), "Product Id is required");
            }

            var existingProduct = _unitOfWork.BakeryProductRepository.GetBakeryProductById(productId);

            if (existingProduct == null)
            {
                throw new Exception($"Product with Id {productId} not found");
            }

            _mapper.Map(productDto, existingProduct);
            existingProduct.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.BakeryProductRepository.UpdateBakeryProductAsync(existingProduct);
            _unitOfWork.SaveChanges();
        }

        public void DeleteProduct(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentNullException(nameof(productId), "Product Id is required");
            }

            var product = _unitOfWork.BakeryProductRepository.GetBakeryProductById(productId);

            if (product == null)
            {
                throw new Exception($"Product with Id {productId} not found");
            }

            _unitOfWork.BakeryProductRepository.DeleteBakeryProductAsync(product);
            _unitOfWork.SaveChanges();
        }
    }
}

using AutoMapper;
using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BakeAtlas.Application.ServicesImplementation
{
    public class BakeryProductService : IBakeryProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BakeryProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddProduct(BakeryProductDTO product)
        {
            var prod = _mapper.Map<BakeryProductDTO, BakeryProduct>(product);
            prod.Id = Guid.NewGuid().ToString();
            prod.UpdatedAt = DateTime.UtcNow;
            prod.CreatedAt = DateTime.UtcNow;

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

            _mapper.Map(product, existingProduct);
            existingProduct.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.BakeryProductRepository.UpdateBakeryProductAsync(existingProduct);
            _unitOfWork.SaveChanges();
        }

        public void DeleteProduct(string productId)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentNullException("Product Id is required");
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

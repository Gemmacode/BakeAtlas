using BakeAtlas.Application.Interface.Repositories;
using BakeAtlas.Application.Interface.Services;
using BakeAtlas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Application.ServicesImplementation
{
    public class BakeryProductService : IBakeryProductService
    {
        //private readonly IGenericRepository<BakeryProduct> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BakeryProductService(IGenericRepository<BakeryProduct> repository, IUnitOfWork unitOfWork)
        {
            //_repository = repository;
            _unitOfWork = unitOfWork;
        }

        public List<BakeryProduct> GetAllProducts()
        {
            return GetAllProducts();
        }

        public BakeryProduct GetProductById(string productId)
        {
            return _repository.GetByIdAsync(productId);
        }

        public void AddProduct(BakeryProduct product)
        {
            _repository.Insert(product);
        }

        public void UpdateProduct(BakeryProduct product)
        {
            _repository.Update(product);
        }

        public void DeleteProduct(int productId)
        {
            _repository.Delete(productId);
        }
    }
}

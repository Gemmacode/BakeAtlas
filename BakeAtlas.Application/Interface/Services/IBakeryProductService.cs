﻿using BakeAtlas.Domain.Entities;

namespace BakeAtlas.Application.Interface.Services
{
    public interface IBakeryProductService
    {
        void AddProduct(BakeryProduct product);
        void DeleteProduct(int productId);
        List<BakeryProduct> GetAllProducts();
        BakeryProduct GetProductById(string productId);
        void UpdateProduct(BakeryProduct product);
    }
}
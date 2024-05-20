using BakeAtlas.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BakeAtlas.Application.ServicesImplementation
{
    public class ProductService
    {
        private static IList<BakeryProductDTO>productList = new List<BakeryProductDTO>();  
        private readonly RapidApiService _rapidApiService;

        public ProductService(RapidApiService rapidApiService)
        {
            _rapidApiService = rapidApiService;
        }
            
        public async Task<BakeryProductDTO> GetCakeDataAsync(int id)
        {
            var result = await _rapidApiService.GetCakeDataAsync(id);
            var cakeData = JsonConvert.DeserializeObject<BakeryProductDTO>(result);  
            return cakeData;    
        }

        public  void AddProduct (BakeryProductDTO productDto) 
        { 
            productList.Add(productDto);
        }

        public IEnumerable <BakeryProductDTO> GetAllProducts()
        {
            return productList;
        }

        public BakeryProductDTO GetProductById(string id)
        {
            return productList.FirstOrDefault(product=>product.Equals(id));
        }
    }
}

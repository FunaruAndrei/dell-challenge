using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto Get(string id);
        ProductDto Add(NewProductDto newProduct);
        ProductDto Delete(string id);
        ProductDto Put(string id, ProductDto updatedProduct);
    }
}

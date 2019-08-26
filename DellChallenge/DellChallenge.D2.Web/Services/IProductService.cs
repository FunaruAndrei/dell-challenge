using DellChallenge.D2.Web.Models;
using System.Collections.Generic;

namespace DellChallenge.D2.Web.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel Get(string id);
        ProductModel Add(NewProductModel newProduct);
        ProductModel Delete(string id);
        ProductModel Put(string id, ProductModel model);
    }
}
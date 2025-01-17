﻿using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public ProductDto Get(string id)
        {
            var product = GetProductById(id);
            return MapToDto(product);
           
        }

        public ProductDto Delete(string id)
        {
            var product = GetProductById(id);
            _context.Remove(product);
            _context.SaveChanges();
            return MapToDto(product);
        }

        public ProductDto Put(string id, ProductDto updatedProduct)
        {
            var product = GetProductById(id);
            product.Name = updatedProduct.Name;
            product.Category = updatedProduct.Category;
            _context.Products.Update(product);
            _context.SaveChanges();
            return MapToDto(product);

        }

        private Product GetProductById(string id)
        {
            var product = _context.Products.Where(e => e.Id == id).FirstOrDefault();

            if (product == null)
                throw new System.Exception("No product where found with this id");

            return product;
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
    }
}

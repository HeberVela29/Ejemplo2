using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplo2_ProductRepository_2025.Data;
using Ejemplo2_ProductRepository_2025.Domain;

namespace Ejemplo2_ProductRepository_2025.Services
{
    public class ProductService
    {
        private IProductRepository _repository;

        public ProductService()
        {
            _repository=new ProductRepository();
        }
        public Product? GetProductById(int id) 
        {
            return _repository.GetById(id);
        }
        public bool SaveProduct(Product product)
        {
            return _repository.Save(product);
        }
    }
}

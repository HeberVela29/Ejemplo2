using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplo2_ProductRepository_2025.Domain;

namespace Ejemplo2_ProductRepository_2025.Data
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        //El signo ? es para que acepte valores nulos
        Product? GetById(int id);
        bool Save(Product product);
        bool Delete(int id);
            
    }
}

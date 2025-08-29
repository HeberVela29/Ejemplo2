using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejemplo2_ProductRepository_2025.Domain;

namespace Ejemplo2_ProductRepository_2025.Data
{
    public class ProductRepository : IProductRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            //creamos lista
            List<Product> list = new List<Product>();
            //traer registros de la BD
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_Recuperar_Productos");
            //mapear cada DataRow a un product
            foreach (DataRow row in dt.Rows)
            {
                Product p = new Product();
                p.Codigo = (int)row["codigo"];
                p.Nombre = (string)row["n_producto"];
                //p.Precio = (double)row["precio"];
                p.Stock = (int)row["stock"];
                p.Activo = (bool)row["esta_activo"];
                list.Add(p);
            }
            return list;
        }

        public Product? GetById(int id)
        {
            //preparar parametros
            List<ParametroSP> param = new List<ParametroSP>()
            {
                new ParametroSP()
                {
                    Name = "@codigo",
                    Valor = id
                }
            };

            //otra forma
            //List<ParametroSP> param2 = new List<ParametroSP>();
            //p.Valor = id;
            //p.Name = "@codigo";
            //param2.Add(p);

            //traemos el registro correspondiente a través del SP
            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_PRODUCTO_POR_CODIGO");

            //SI VINO UN REGISTRO, LO MAPEAMOS A LISTA Y RETORNAMOS
            if (dt != null && dt.Rows.Count > 0)
            {
                Product p = new Product()
                {
                    Codigo = (int)dt.Rows[0]["codigo"],
                    Nombre = (string)dt.Rows[0]["n_producto"],
                    //Precio = (double)dt.Rows[0]["precio"],
                    Stock = (int)dt.Rows[0]["stock"],
                    Activo = (bool)dt.Rows[0]["esta_activo"],
                };
            }
            return dt;
        }

        public bool Save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

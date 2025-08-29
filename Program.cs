using Ejemplo2_ProductRepository_2025.Domain;
using Ejemplo2_ProductRepository_2025.Services;

ProductService oService = new ProductService();

List<Product> list = oService.GetProducts();

if(list.Count > 0)
{
    foreach (Product p in list)
        Console.WriteLine(p);
}
else
{
    Console.WriteLine("No products");
}

//Obtener un producto por ID -getbyid
Console.WriteLine("Obtener un producto por id");

//llamamos al service
Product?producto5=oService.GetProductById(5);

if(producto5 != null)
{
    Console.WriteLine(producto5);
}
else
{
    Console.WriteLine("No hay producto con ese ID");
}
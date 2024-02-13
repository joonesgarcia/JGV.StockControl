using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.DAL.Models;

namespace JGV.StockControl.Library.DAL.Repository;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    Product? GetProductById(int id);
    void DeleteProduct(Product product);
    void AddProduct(ProductInputModel input);

    int GetProductAvailableQuantity(Product product);

}

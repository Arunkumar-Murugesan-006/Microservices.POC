using Product.Service.Models;

namespace Product.Service.Data.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetProducts();
        ProductModel GetProductById(int id);
        void AddProduct(ProductModel product);
        void UpdateProduct(ProductModel updateProduct);
        void DeleteProduct(int id);
    }
}

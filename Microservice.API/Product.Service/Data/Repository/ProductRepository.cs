using Product.Service.Data.DB_Context;
using Product.Service.Models;

namespace Product.Service.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;
        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public IEnumerable<ProductModel> GetProducts()
        {
            try
            {
                return _productDbContext.Products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProductModel GetProductById(int id)
        {
            try
            {
                return _productDbContext.Products.FirstOrDefault(x => x.ProductId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddProduct(ProductModel product)
        {
            try
            {
                _productDbContext.Products.Add(product);
                _productDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateProduct(ProductModel updateProduct)
        {
            try
            {
                var product = _productDbContext.Products.FirstOrDefault(x => x.ProductId == updateProduct.ProductId);
                if (product != null)
                {
                    product.Origin = (string.IsNullOrEmpty(updateProduct.Origin) || updateProduct.Origin == "string") ? product.Origin : updateProduct.Origin;
                    product.Destination = (string.IsNullOrEmpty(updateProduct.Destination) || updateProduct.Destination == "string") ? product.Destination : updateProduct.Destination;
                    product.ContainerType = (string.IsNullOrEmpty(updateProduct.ContainerType) || updateProduct.ContainerType == "string") ? product.ContainerType : updateProduct.ContainerType;
                    product.Price = updateProduct.Price > 0 ? updateProduct.Price : product.Price;
                    product.Volume = updateProduct.Volume > 0 ? updateProduct.Volume : product.Volume;

                    _productDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteProduct(int id)
        {
            try
            {
                var product = _productDbContext.Products.FirstOrDefault(x => x.ProductId == id);
                if (product != null)
                {
                    _productDbContext.Products.Remove(product);
                    _productDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

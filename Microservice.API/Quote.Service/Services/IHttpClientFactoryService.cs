namespace Quote.Service.Services
{
    public interface IHttpClientFactoryService
    {
        Task<List<Product>> GetProducts();
    }
}

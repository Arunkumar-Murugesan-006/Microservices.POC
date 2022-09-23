using System.Text.Json;

namespace Quote.Service.Services
{
    public class HttpClientFactoryService : IHttpClientFactoryService
    {
        private readonly string Product_API = "https://localhost:7291/api/Product";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        public HttpClientFactoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<Product>> GetProducts()
        {
            List<Product> productlist;
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                using (var response = await httpClient.GetAsync(Product_API, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    var stream = await response.Content.ReadAsStreamAsync();
                    productlist = await JsonSerializer.DeserializeAsync<List<Product>>(stream, _options);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productlist;
        }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string ContainerType { get; set; }
        public float Price { get; set; }
        public int Volume { get; set; }
    }
}

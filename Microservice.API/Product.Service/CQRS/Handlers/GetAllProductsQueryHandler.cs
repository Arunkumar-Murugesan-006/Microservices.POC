using MediatR;
using Product.Service.CQRS.Queries;
using Product.Service.Data.Repository;
using Product.Service.Models;

namespace Product.Service.CQRS.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<ProductModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetProducts();
            return await Task.FromResult(products);
        }
    }
}

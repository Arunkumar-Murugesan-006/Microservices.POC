using MediatR;
using Product.Service.CQRS.Queries;
using Product.Service.Data.Repository;
using Product.Service.Models;

namespace Product.Service.CQRS.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductModel>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetProductById(request.Id);
            return await Task.FromResult(products);
        }
    }
}

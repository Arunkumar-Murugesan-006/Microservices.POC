using MediatR;
using Product.Service.CQRS.Commands;
using Product.Service.Data.Repository;
using Product.Service.Models;

namespace Product.Service.CQRS.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, ProductModel>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            _productRepository.AddProduct(request.Product);
            return await Task.FromResult(request.Product);
        }
    }
}

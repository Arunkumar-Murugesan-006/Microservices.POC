using MediatR;
using Product.Service.CQRS.Commands;
using Product.Service.Data.Repository;
using Product.Service.Models;

namespace Product.Service.CQRS.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductModel>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            _productRepository.UpdateProduct(request.Product);
            return await Task.FromResult(request.Product);
        }
    }
}

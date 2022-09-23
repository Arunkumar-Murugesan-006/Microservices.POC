using MediatR;
using Product.Service.CQRS.Commands;
using Product.Service.Data.Repository;

namespace Product.Service.CQRS.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _productRepository.DeleteProduct(request.Id);
            return await Task.FromResult(request.Id);
        }
    }
}

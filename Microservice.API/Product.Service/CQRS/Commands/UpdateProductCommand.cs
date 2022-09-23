using MediatR;
using Product.Service.Models;

namespace Product.Service.CQRS.Commands
{
    public record UpdateProductCommand(ProductModel Product) : IRequest<ProductModel>;
}

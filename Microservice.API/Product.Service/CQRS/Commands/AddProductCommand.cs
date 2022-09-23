using MediatR;
using Product.Service.Models;

namespace Product.Service.CQRS.Commands
{
    public record AddProductCommand(ProductModel Product) : IRequest<ProductModel>;
}

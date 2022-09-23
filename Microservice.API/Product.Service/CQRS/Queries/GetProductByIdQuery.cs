using MediatR;
using Product.Service.Models;

namespace Product.Service.CQRS.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductModel>;
}

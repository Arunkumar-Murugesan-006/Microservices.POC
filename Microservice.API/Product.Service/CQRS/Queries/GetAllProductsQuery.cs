using MediatR;
using Product.Service.Models;

namespace Product.Service.CQRS.Queries
{
    public record GetAllProductsQuery() : IRequest<IEnumerable<ProductModel>>;
}

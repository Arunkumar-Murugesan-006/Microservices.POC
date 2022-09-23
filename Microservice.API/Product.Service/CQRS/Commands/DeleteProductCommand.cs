using MediatR;

namespace Product.Service.CQRS.Commands
{
    public record DeleteProductCommand(int Id) : IRequest<int>;
}

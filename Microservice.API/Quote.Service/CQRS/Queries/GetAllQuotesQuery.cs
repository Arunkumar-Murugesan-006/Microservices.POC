using MediatR;
using Quote.Service.Models;

namespace Quote.Service.CQRS.Queries
{
    public record GetAllQuotesQuery() : IRequest<IEnumerable<QuoteModel>>;
}

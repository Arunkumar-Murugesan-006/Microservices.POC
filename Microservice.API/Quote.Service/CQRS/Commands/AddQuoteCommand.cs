using MediatR;
using Quote.Service.Models;

namespace Quote.Service.CQRS.Commands
{
    public record AddQuoteCommand(QuoteModel Quotes) : IRequest<QuoteModel>;
}

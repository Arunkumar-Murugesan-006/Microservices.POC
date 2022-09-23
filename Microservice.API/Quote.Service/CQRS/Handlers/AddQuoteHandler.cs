using MediatR;
using Quote.Service.CQRS.Commands;
using Quote.Service.Data.Repository;
using Quote.Service.Models;

namespace Quote.Service.CQRS.Handlers
{
    public class AddQuoteHandler : IRequestHandler<AddQuoteCommand, QuoteModel>
    {
        private readonly IQuoteRepository _quotesRepository;

        public AddQuoteHandler(IQuoteRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        public async Task<QuoteModel> Handle(AddQuoteCommand request, CancellationToken cancellationToken)
        {
            _quotesRepository.AddQuote(request.Quotes);
            return await Task.FromResult(request.Quotes);
        }
    }
}

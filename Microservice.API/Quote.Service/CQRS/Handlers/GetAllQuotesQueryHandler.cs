using MediatR;
using Quote.Service.CQRS.Queries;
using Quote.Service.Data.Repository;
using Quote.Service.Models;

namespace Quote.Service.CQRS.Handlers
{
    public class GetAllQuotesQueryHandler : IRequestHandler<GetAllQuotesQuery, IEnumerable<QuoteModel>>
    {
        private readonly IQuoteRepository _quotesRepository;

        public GetAllQuotesQueryHandler(IQuoteRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }
        public async Task<IEnumerable<QuoteModel>> Handle(GetAllQuotesQuery request, CancellationToken cancellationToken)
        {
            var quotes = _quotesRepository.GetQuotes();
            return await Task.FromResult(quotes);
        }
    }
}

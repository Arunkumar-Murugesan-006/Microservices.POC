using Quote.Service.Models;

namespace Quote.Service.Data.Repository
{
    public interface IQuoteRepository
    {
        IEnumerable<QuoteModel> GetQuotes();
        void AddQuote(QuoteModel quotes);
    }
}

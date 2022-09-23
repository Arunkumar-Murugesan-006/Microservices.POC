using Quote.Service.Data.DB_Context;
using Quote.Service.Models;

namespace Quote.Service.Data.Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly QuoteDbContext _quoteDbContext;

        public QuoteRepository(QuoteDbContext quoteDbContext)
        {
            _quoteDbContext = quoteDbContext;
        }
        public IEnumerable<QuoteModel> GetQuotes()
        {
            try
            {
                return _quoteDbContext.Quotes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddQuote(QuoteModel quotes)
        {
            try
            {
                _quoteDbContext.Quotes.Add(quotes);
                _quoteDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

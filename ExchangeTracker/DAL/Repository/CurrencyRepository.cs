using ExchangeTracker.DAL.DBO;
using ExchangeTracker.DAL.Repository.Interfaces;

namespace ExchangeTracker.DAL.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly DataContext context;

        public CurrencyRepository(DataContext _context)
        {
            context = _context;
        }
        public List<Currency> GetCurrencies() 
        {
            return context.Currency.OrderBy( p => p.Id ).ToList();        
        }

        public Currency GetCurrencyByAbbreviation(String abbreviation)
        {
            return context.Currency.FirstOrDefault(p => p.Abbreviation == abbreviation);
        }
    }
}

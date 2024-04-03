using ExchangeTracker.DAL.DBO;
using ExchangeTracker.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ExchangeTracker.DAL.Repository
{
    public class CurrencyEntryRepository : ICurrencyEntryRepository
    {
        private readonly DataContext context;

        public CurrencyEntryRepository(DataContext context)
        {
            this.context = context;    
        }

        public List<CurrencyEntry> GetCurrencyEntries()
        {
            return context.CurrencyEntry.OrderBy(p => p.Value).ToList();
        }
        public Currency GetAssociatedCurrency(int currencyId)
        {
            return context.Currency.FirstOrDefault(p => p.Id == currencyId);
        }
        public bool CreateCurrencyEntry(CurrencyEntry currencyEntry)
        {
            context.CurrencyEntry.Add(currencyEntry);
            return Save();
        }
        public bool Save()
        {
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}

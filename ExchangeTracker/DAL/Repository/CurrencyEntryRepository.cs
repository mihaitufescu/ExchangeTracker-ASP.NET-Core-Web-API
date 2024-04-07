using ExchangeTracker.DAL.DBO;
using ExchangeTracker.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ExchangeTracker.DAL.Repository
{
    public class CurrencyEntryRepository : ICurrencyEntryRepository
    {
        private readonly DataContext _context;

        public CurrencyEntryRepository(DataContext context)
        {
            _context = context;    
        }

        public List<CurrencyEntry> GetCurrencyEntries()
        {
            return _context.CurrencyEntry.OrderBy(p => p.Value).ToList();
        }
        public bool CreateCurrencyEntry(CurrencyEntry currencyEntry)
        {
            _context.CurrencyEntry.Add(currencyEntry);
            return Save();
        }
        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}

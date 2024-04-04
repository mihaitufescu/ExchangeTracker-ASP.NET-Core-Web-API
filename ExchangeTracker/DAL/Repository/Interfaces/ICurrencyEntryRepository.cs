using ExchangeTracker.DAL.DBO;

namespace ExchangeTracker.DAL.Repository.Interfaces
{
    public interface ICurrencyEntryRepository
    {
        List<CurrencyEntry> GetCurrencyEntries();
        bool CreateCurrencyEntry(CurrencyEntry currencyEntry);
        bool Save();
    }
}

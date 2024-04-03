using ExchangeTracker.DAL.DBO;

namespace ExchangeTracker.DAL.Repository.Interfaces
{
    public interface ICurrencyRepository
    {
        List<Currency> GetCurrencies();
        Currency GetCurrencyByAbbreviation(String abbreviation);
    }
}

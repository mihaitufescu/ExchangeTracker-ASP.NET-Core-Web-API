using ExchangeTracker.DAL.DBO;
using ExchangeTracker.Models;

namespace ExchangeTracker.Services.Interfaces
{
    public interface ICurrencyService
    {
        List <CurrencyModel> GetAllCurrencies();
        CurrencyModel GetCurrencyByAbbreviation(String abbreviation);
        CurrencyModel GetCurrencyByName(String name);
    }
}

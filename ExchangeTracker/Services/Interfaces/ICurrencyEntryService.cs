using ExchangeTracker.Models;

namespace ExchangeTracker.Services.Interfaces
{
    public interface ICurrencyEntryService
    {
        List <CurrencyEntryModel> GetAllCurrencyEntries();
        Decimal GetCurrencyValueById(int id);
    }
}

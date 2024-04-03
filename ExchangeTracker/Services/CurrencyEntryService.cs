using AutoMapper;
using ExchangeTracker.DAL.Repository;
using ExchangeTracker.DAL.Repository.Interfaces;
using ExchangeTracker.Models;
using ExchangeTracker.Services.Interfaces;

namespace ExchangeTracker.Services
{
    public class CurrencyEntryService : ICurrencyEntryService
    {
        private readonly IMapper mapper;
        private readonly ICurrencyEntryRepository currencyEntryRepository;

        public CurrencyEntryService(IMapper mapper, ICurrencyEntryRepository currencyEntryRepository)
        {
            this.mapper = mapper;
            this.currencyEntryRepository = currencyEntryRepository; 
        }

        public List<CurrencyEntryModel> GetAllCurrencyEntries()
        {
            var currencyEntries = mapper.Map<List<CurrencyEntryModel>>(currencyEntryRepository.GetCurrencyEntries());

            return currencyEntries;
        }
        public Decimal GetCurrencyValueById(int id)
        {
            decimal currencyValue = GetAllCurrencyEntries().Find(x => x.Id_Currency == id).Value;
            return currencyValue;
        }
    }
}

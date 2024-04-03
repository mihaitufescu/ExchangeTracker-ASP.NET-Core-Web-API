using ExchangeTracker.DAL;
using ExchangeTracker.Services.Interfaces;
using AutoMapper;
using ExchangeTracker.DAL.Repository.Interfaces;
using ExchangeTracker.DAL.Repository;
using ExchangeTracker.DAL.DBO;
using ExchangeTracker.Models;

namespace ExchangeTracker.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository currencyRepository;
        private readonly IMapper mapper;

        public CurrencyService(IMapper mapper,ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
            this.mapper = mapper;
        }
        public List<CurrencyModel> GetAllCurrencies()
        {
            var currencies = mapper.Map<List<CurrencyModel>>(currencyRepository.GetCurrencies());

            return currencies;
        }
        public CurrencyModel GetCurrencyByAbbreviation(String abbreviation)
        {
            var currency = mapper.Map<CurrencyModel>(currencyRepository.GetCurrencyByAbbreviation(abbreviation));

            return currency;
        }
    }
}

using AutoMapper;
using ExchangeTracker.DAL.Repository;
using ExchangeTracker.DAL.Repository.Interfaces;
using ExchangeTracker.Models;
using ExchangeTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeTracker.Services
{
    public class CurrencyEntryService : ICurrencyEntryService
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyEntryRepository _currencyEntryRepository;

        public CurrencyEntryService(IMapper mapper, ICurrencyEntryRepository currencyEntryRepository)
        {
            _mapper = mapper;
            _currencyEntryRepository = currencyEntryRepository; 
        }

        public List<CurrencyEntryModel> GetAllCurrencyEntries()
        {
            var currencyEntries = _mapper.Map<List<CurrencyEntryModel>>(_currencyEntryRepository.GetCurrencyEntries());

            return currencyEntries;
        }
        public Decimal GetCurrencyValueById(int id)
        {
            decimal currencyValue = GetAllCurrencyEntries().Find(x => x.Id_Currency == id).Value;
            return currencyValue;
        }
        
    }
}

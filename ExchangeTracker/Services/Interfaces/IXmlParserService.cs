﻿using System;
using System.Xml.Linq;
using System.Threading.Tasks;
using ExchangeTracker.DAL.DBO;

namespace ExchangeTracker.Services.Interfaces
{
    public interface IXmlParserService
    {
        Task<bool> UpdateCurrencyRatesAsync();
        Task<bool> CreateCurrencyEntryAsync(CurrencyEntry entry);
        
    }
}

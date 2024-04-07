using ExchangeTracker.DAL.DBO;
using ExchangeTracker.DAL.Repository;
using ExchangeTracker.DAL.Repository.Interfaces;
using ExchangeTracker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;

namespace ExchangeTracker.Services
{
    public class XmlParserService : IXmlParserService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICurrencyEntryRepository _currencyEntryRepository;
        private readonly ILogger<XmlParserService> _logger;
        private readonly HttpClient _client;
        private readonly string _apiUrl;

        public XmlParserService(ICurrencyRepository currencyRepository,ICurrencyEntryRepository currencyEntryRepository, ILogger<XmlParserService> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _currencyRepository = currencyRepository;
            _currencyEntryRepository = currencyEntryRepository;
            _logger = logger;
            _apiUrl = configuration["CurrencyApiUrl"];
            _client = httpClientFactory.CreateClient();
        }

        public async Task<bool> UpdateCurrencyRatesAsync()
        {
            var response = await _client.GetAsync(_apiUrl);
            response.EnsureSuccessStatusCode();

            _logger.LogInformation("Currency update was triggered with status code: ",response.StatusCode);

            var xmlContent = await response.Content.ReadAsStringAsync();
            XDocument xmlDoc = XDocument.Parse(xmlContent);
            XNamespace ns = "http://www.bnr.ro/xsd";
            string rateDateStr = xmlDoc.Root.Element(ns + "Header").Element(ns + "PublishingDate").Value;
            DateTime rateDate;
            if (!DateTime.TryParseExact(rateDateStr, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out rateDate))
            {
                return false;
            }
            List<Task<bool>> tasks = new List<Task<bool>>();

            foreach (var rateElement in xmlDoc.Root.Element(ns + "Body").Element(ns + "Cube").Elements(ns + "Rate"))
            {
                //multiplier value is 100 in all cases
                XAttribute multiplierAttribute = rateElement.Attribute("multiplier");
                bool isMultiplied = multiplierAttribute != null ? true : false;
         
                string currencyCode = rateElement.Attribute("currency").Value;
                decimal exchangeRate = decimal.Parse(rateElement.Value);
                var currency = _currencyRepository.GetCurrencyByAbbreviation(currencyCode);
                var entry = new CurrencyEntry
                {
                    Currency = currency,
                    Id_Currency = currency.Id,
                    Date = rateDate,
                    Value = exchangeRate,
                    IsMultiplied = isMultiplied
                };

                tasks.Add(CreateCurrencyEntryAsync(entry));
            }
            await Task.WhenAll(tasks);
            return tasks.All(t => t.Result);      
        }

        public async Task<bool> CreateCurrencyEntryAsync(CurrencyEntry entry)
        {
            try
            {
                return _currencyEntryRepository.CreateCurrencyEntry(entry);
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an error while adding the entry: ", entry.Id);
                return false;
            }
        }
    }
}

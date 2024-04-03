using ExchangeTracker.DAL.DBO;
using ExchangeTracker.DAL.Repository;
using ExchangeTracker.DAL.Repository.Interfaces;
using ExchangeTracker.Services.Interfaces;
using System.Globalization;
using System.Xml.Linq;

namespace ExchangeTracker.Services
{
    public class XmlParserService : IXmlParserService
    {
        private readonly ICurrencyRepository currencyRepository;
        private readonly ICurrencyEntryRepository currencyEntryRepository;

        public XmlParserService(ICurrencyRepository currencyRepository,ICurrencyEntryRepository currencyEntryRepository)
        {
            this.currencyRepository = currencyRepository;
            this.currencyEntryRepository = currencyEntryRepository;
        }


        public async Task<bool> UpdateCurrencyRatesAsync(string xmlContent)
        {
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

                bool isMultiplied = false; 
                XAttribute multiplierAttribute = rateElement.Attribute("multiplier");
                if (multiplierAttribute != null)
                {
                    isMultiplied = true; 
                }
                string currencyCode = rateElement.Attribute("currency").Value;
                decimal exchangeRate = decimal.Parse(rateElement.Value);
                var currency = currencyRepository.GetCurrencyByAbbreviation(currencyCode);    
                CurrencyEntry entry = new CurrencyEntry();
                entry.Currency = currency;
                entry.Id_Currency = currency.Id;
                entry.Date = rateDate;
                entry.Value = exchangeRate;
                entry.IsMultiplied = isMultiplied;
                tasks.Add(CreateCurrencyEntryAsync(entry));
            }

            await Task.WhenAll(tasks);

            return tasks.All(t => t.Result);
        }

        public async Task<bool> CreateCurrencyEntryAsync(CurrencyEntry entry)
        {
            try
            {
                return currencyEntryRepository.CreateCurrencyEntry(entry);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

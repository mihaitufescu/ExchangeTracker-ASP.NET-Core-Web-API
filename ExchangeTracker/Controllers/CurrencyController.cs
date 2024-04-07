using ExchangeTracker.Models;
using ExchangeTracker.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ExchangeTracker.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type= typeof(IEnumerable<CurrencyModel>))]
        public IActionResult GetCurrencies() {
            var currencies =  _currencyService.GetAllCurrencies();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(currencies);
        }
        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CurrencyModel>))]
        public IActionResult GetCurrencyByAbbreviation(String abbreviation)
        {
            var currency = _currencyService.GetCurrencyByAbbreviation(abbreviation);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(currency);
        }
        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CurrencyModel>))]
        public IActionResult GetCurrencyByName(String name)
        {
            var currency = _currencyService.GetCurrencyByName(name);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(currency);
        }
    }
}

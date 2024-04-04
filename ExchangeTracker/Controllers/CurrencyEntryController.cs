using AutoMapper;
using ExchangeTracker.DAL.DBO;
using ExchangeTracker.DAL.Repository;
using ExchangeTracker.DAL.Repository.Interfaces;
using ExchangeTracker.Models;
using ExchangeTracker.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ExchangeTracker.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CurrencyEntryController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICurrencyEntryService currencyEntryService;
        private readonly ICurrencyEntryRepository currencyEntryRepository;

        public CurrencyEntryController(IMapper mapper, ICurrencyEntryService currencyEntryService,ICurrencyEntryRepository currencyEntryRepository)
        {
            this.mapper = mapper;
            this.currencyEntryService = currencyEntryService;
            this.currencyEntryRepository = currencyEntryRepository;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CurrencyEntryModel>))]
        public IActionResult GetAllCurrencyEntries()
        {
            var currencyEntries = currencyEntryService.GetAllCurrencyEntries();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(currencyEntries);
        }
        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(Decimal))]
        public IActionResult GetCurrencyValueById(int id)
        {
            var value = currencyEntryService.GetCurrencyValueById(id);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(value);
        }
    }
}

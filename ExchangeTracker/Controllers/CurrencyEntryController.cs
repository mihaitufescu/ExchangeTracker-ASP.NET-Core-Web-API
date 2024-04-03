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
        /*
        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCurrencyEntry([FromBody] CurrencyEntry currencyEntry)
        {
            if(currencyEntry == null)
            {
                return BadRequest(ModelState);
            }
            var _currencyEntry = currencyEntryRepository.GetCurrencyEntries()
                .Where(p => p.Date == currencyEntry.Date);
            if(_currencyEntry == null)
            {
                ModelState.AddModelError("", "Currency entry already exists");
                return StatusCode(422, ModelState);
            }
            currencyEntry.Date = DateTime.Now.Date;
            var existingEntry = currencyEntryRepository.GetCurrencyEntries()
                .FirstOrDefault(p => p.Date == currencyEntry.Date);

            if (existingEntry != null)
            {
                ModelState.AddModelError("", "Currency entry already exists for this date");
                return StatusCode(422, ModelState);
            }
            var currency = currencyEntryRepository.GetAssociatedCurrency(currencyEntry.Id_Currency);
            currencyEntry.Currency = currency;
            var currencyEntryMap = mapper.Map<CurrencyEntry>(currencyEntry);
            if (!currencyEntryRepository.CreateCurrencyEntry(currencyEntryMap))
            {
                ModelState.AddModelError("", "Something went wrong while adding the currency entry");
                return StatusCode(500, ModelState);
            }
            return Ok("Succesful!");
        } */
    }
}

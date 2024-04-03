namespace ExchangeTracker.Models

{
    public class CurrencyEntryModel
    {
        public int Id { get; set; }
        public int Id_Currency { get; set; }
        public decimal Value { get; set; }
        public bool IsMultiplied { get; set; }

    }
}

namespace ExchangeTracker.Models
{
    public class CurrencyTrackModel
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public int Id_Currency { get; set; }
        public DateTime LowerBound_Date { get; set; }
        public DateTime UpperBound_Date { get; set; }
        public CurrencyModel Currency { get; set; }
        public UserModel User { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
namespace ExchangeTracker.DAL.DBO
{
    public class CurrencyTrack
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public int Id_User { get; set; }
        [ForeignKey(nameof(Currency))]
        [Required]
        public int Id_Currency { get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateTime LowerBound_Date { get; set; }
        [Column(TypeName = "date")]
        public DateTime UpperBound_Date { get; set; }
        public Currency Currency { get; set; }
        public User User { get; set; }
    }
}

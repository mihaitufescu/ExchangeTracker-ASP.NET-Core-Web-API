using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Reflection.Metadata;
namespace ExchangeTracker.DAL.DBO
{
    public class CurrencyEntry
    {
        
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Currency))]
        [Required]
        public int Id_Currency { get; set; }
        [Column(TypeName = "float")]
        [Required]
        public decimal Value { get; set; }
        [Column(TypeName = "date")]
        [Required]
        public DateTime Date { get; set; }
        public bool IsMultiplied { get; set; }
        public Currency Currency { get; set; }
    }
}

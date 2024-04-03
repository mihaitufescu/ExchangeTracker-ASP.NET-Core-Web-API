using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ExchangeTracker.DAL.DBO
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(4)")]
        public string Abbreviation { get; set; }
        public ICollection<CurrencyEntry> Entries { get; set; }
        public ICollection<CurrencyTrack> Tracks { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeTracker.DAL.DBO
{
    public class User
    {
        public User()
        {
            Tracks = new List<CurrencyTrack>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName="nvarchar(64)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime Created_At { get; set; }
        [Column(TypeName = "int")]
        public bool Verified { get; set; }
        public ICollection<CurrencyTrack> Tracks { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Licenses")]
    public class License
    {
        [Key]
        public long Id { get; set; }
        public string Key { get; set; }
        public string PCHash { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}

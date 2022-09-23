using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quote.Service.Models
{
    [Table("Quotes")]
    public class QuoteModel
    {
        [Key]
        public int QuoteId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string ContainerType { get; set; }
        public float QuotePrice { get; set; }
    }
}

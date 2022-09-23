using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Service.Models
{
    [Table("Products")]
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string ContainerType { get; set; }
        public float Price { get; set; }
        public int Volume { get; set; }
    }
}

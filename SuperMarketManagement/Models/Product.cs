using System.ComponentModel.DataAnnotations;

namespace SuperMarketManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Product Category")]
        public string ProductCategory { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public string Quantity { get; set; }
        [Required]
        [Display(Name = "Price")]
        public float Price { get; set; }
    }
}

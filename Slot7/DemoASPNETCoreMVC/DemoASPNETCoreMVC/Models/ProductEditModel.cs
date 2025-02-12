using System.ComponentModel.DataAnnotations;

namespace DemoASPNETCoreMVC.Models
{
    public class ProductEditModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name")]
        [StringLength(maximumLength: 25, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 25")]
        public string Name { get; set; }
        public int ID { get; set; }
        
        public decimal Rate { get; set; }
        public int Rating { get; set; }
    }
}

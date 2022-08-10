using System.ComponentModel.DataAnnotations;

namespace SuperMarketManagement.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Full Name is Required")]
        [Display(Name = "Full Name*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mobile No. is Required")]
        [RegularExpression("[6-9]{1}[0-9]{9}",ErrorMessage="Invalid Mobile No.")]
        [Display(Name = "Mobile No*")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        [Display(Name = "Gender*")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Full Name is Required")]
        [Display(Name = "Date of Birth*")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "(0:MM/dd/yyy)")]
        public DateTime DoB { get; set; }
    }
}

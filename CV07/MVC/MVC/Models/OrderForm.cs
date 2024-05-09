using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class OrderForm
    {
        [Display(Name = "Jméno:")]
        public string? Name { get; set; }
        [Required (ErrorMessage = "Pole je povinné")]
        [EmailAddress (ErrorMessage = "Email má špatný formát")]
        public string? Email { get; set; }
        [Display(Name = "Počet:")]
        [Required]
        [Range (1, 10, ErrorMessage = "Počet musí být v rozmezí 1 - 10")]
        public int? Quantity { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "You need to keep the name to max of 20 characters")]
        [MinLength(3, ErrorMessage ="You need to enter at least 3 characters for order name")]
        [DisplayName("Name for the Order")]
        public string OrderName { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "You need to select a meal from the list")]
        [DisplayName("Meal")]
        public int FoodId { get; set; }

        [Required]
        [Range(1,10,ErrorMessage = "You can order maximum of 10 meals at once")]
        public int Quantity { get; set; }

        public decimal Total { get; set; }

    }
}

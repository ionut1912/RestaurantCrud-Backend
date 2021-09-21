using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApi.Models
{
    public class OrderDetail
    {
        [Key]
        public long OrderDetailId { get; set; }
        public long OrderMasterId { get; set; }
       
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get;set; }

        public int FoodItemPrice { get; set; }
        public int Quantity { get; set; }

    }
}

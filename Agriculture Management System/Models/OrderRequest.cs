using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture_Management_System.Models
{
    public class OrderRequest
    {
        [Key]
        public int OrderId { get; set; }

        public string FarmerID { get; set; }
        [ForeignKey(nameof(FarmerID))]
        public Users Farmer { get; set; }

        
        
        public string BuyerID  { get; set; }
        [ForeignKey(nameof(BuyerID))]
        public Users Buyer { get; set; }

        public String OrderStatus { get; set; }

        public string DeliveryAddress { get; set; }
    }
}

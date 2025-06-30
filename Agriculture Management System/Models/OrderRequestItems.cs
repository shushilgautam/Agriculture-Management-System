namespace Agriculture_Management_System.Models
{
    public class OrderRequestItems
    {
        public int Id { get; set; }
        public int CropID { get; set; }
        public Crops Crop { get; set; }

        public int Quantity { get; set; }

        public int OrderReqID { get; set; }
        public OrderRequest OrderReq { get; set; }
    }
}

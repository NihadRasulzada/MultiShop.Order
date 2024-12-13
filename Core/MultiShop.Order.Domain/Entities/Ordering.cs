namespace MultiShop.Order.Domain.Entities
{
    public class Ordering
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public Address Address { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}

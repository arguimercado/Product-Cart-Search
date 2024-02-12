namespace Core.Models
{
    public class ProductCart
    {
        public Guid Id { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }
        public float TotalAmount => Quantity * Product.Cost;
    }
}

using Core.Models;

namespace ProductSearch.Models
{
    public class TransactionModel
    {
        public IEnumerable<ProductCart> Carts { get; set; }

        public float Payment { get; set; }

        public float Change
        {
            get
            {
                var payment = Payment - Carts.Sum(p => p.TotalAmount);
                return payment <= 0 ? 0 : payment;
            }
        }
    }
}

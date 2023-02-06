namespace OutFitShop.Models
{
    public class Order
    {
        public Order() { }

        public Order(DateTime ordertime) { 

            OrderTime = ordertime;
        }



        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var line in OrderLines)
                {
                    var amountPrice = line.Amount * line.Product.Price;
                    total += amountPrice;
                }
                return total;
            }
        }

        public ApplicationUser? User { get; set; }
        public string UserId { get; set; }
        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();


    }
}

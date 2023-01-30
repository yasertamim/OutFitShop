namespace OutFitShop.Models
{
    public class OrderLine
    {

        public OrderLine() { }

        public OrderLine( int amount)
        {
           
            Amount = amount;
        }

        public int Id { get; set; }

        public int Amount { get; set; }

        public Order? Order { get; set; }
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }


    }
}

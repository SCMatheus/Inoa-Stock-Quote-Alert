
namespace Teste.Inoa.StockQuoteAlert.Stock
{
    public class CurrentStock
    {
        
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value.ToUpper();
        }
        public double Price { get; set; }
        public CurrentStock(string name, double price)
        {
            Name = name.ToUpper();
            Price = price;
        }
    }
}


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
        public float Price { get; set; }
        public CurrentStock(string name, float price)
        {
            Name = name.ToUpper();
            Price = price;
        }
    }
}

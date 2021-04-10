namespace Teste.Inoa.StockQuoteAlert.Stock
{
    public class AlertStock
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value.ToUpper();
        }
        public double SellPrice { get; set; }
        public double BuyPrice { get; set; }
        public AlertStock(string name, double sellPrice, double buyPrice)
        {

            Name = name.ToUpper();
            SellPrice = sellPrice;
            BuyPrice = buyPrice;
        }
    }
}

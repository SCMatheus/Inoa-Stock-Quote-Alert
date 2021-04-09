namespace Teste.Inoa.StockQuoteAlert.Stocks
{
    public class Stock
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value.ToUpper();
        }
        public float SellPrice { get; set; }
        public float BuyPrice { get; set; }
        public Stock(string name, float sellPrice, float buyPrice)
        {

            Name = name.ToUpper();
            SellPrice = sellPrice;
            BuyPrice = buyPrice;
        }
    }
}

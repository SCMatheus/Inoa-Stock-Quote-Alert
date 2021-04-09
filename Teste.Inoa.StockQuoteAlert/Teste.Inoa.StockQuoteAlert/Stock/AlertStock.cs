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
        public float SellPrice { get; set; }
        public float BuyPrice { get; set; }
        public AlertStock(string name, float sellPrice, float buyPrice)
        {

            Name = name.ToUpper();
            SellPrice = sellPrice;
            BuyPrice = buyPrice;
        }
    }
}

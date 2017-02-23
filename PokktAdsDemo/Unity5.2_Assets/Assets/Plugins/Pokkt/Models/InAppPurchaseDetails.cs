namespace Pokkt.Models
{
    public sealed class InAppPurchaseDetails
    {
        public string ProductId { get; set; }
        public int Price { get; set; }
        public string CurrencyCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PurchaseData { get; set; }
        public string PurchaseSignature { get; set; }
        public string PurchaseStore { get; set; } // TODO: define type
	}
}

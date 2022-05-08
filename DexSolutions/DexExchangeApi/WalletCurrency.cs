using Microsoft.EntityFrameworkCore;

namespace DexExchangeApi
{
    public class WalletCurrency
    {
        public int WalletCurrencyId { get; set; }
        public int WalletId { get; set; }

        public string Currency { get; set; }
    }
}

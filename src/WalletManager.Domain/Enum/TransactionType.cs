using System.Text.Json.Serialization;

namespace WalletManager.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionType
    {
        Income,
        Expensive
    }
}
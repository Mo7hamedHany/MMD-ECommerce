using System.Text.Json.Serialization;

namespace MMD_ECommerce.Data.Models.Orders
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentStatus
    {
        Pending, Failed, Received
    }
}
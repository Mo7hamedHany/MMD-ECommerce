using System.Text.Json.Serialization;

namespace MMD_ECommerce.Data.Models.Order
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentStatus
    {
        Pending, Failed, Received
    }
}
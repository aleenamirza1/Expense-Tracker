using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
{
    public class CommonEntity
    {
        [JsonIgnore]
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public DateTime? UpdatedOn { get; set; } = DateTime.UtcNow;
    }
}

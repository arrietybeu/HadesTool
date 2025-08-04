using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KnightAgeTool.src.model
{

    internal class ItemData
    {
        [JsonPropertyName("temp_id")]
        public int TempId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("options")]
        public List<ItemOption> Options { get; set; } = new List<ItemOption>();
    }

    public class ItemOption
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("param")]
        public int Param { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CitizensRegistryApp.Core.Paging
{
    public class PagingModel<T> where T : class
    {
        [JsonPropertyName("items")]
        public IEnumerable<T> Items { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}

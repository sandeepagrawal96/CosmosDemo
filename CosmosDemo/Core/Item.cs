﻿using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CosmosDemo.Core
{
    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }
        [JsonProperty(PropertyName = "designation")]
        public string Desgnation { get; set; }
        [JsonProperty(PropertyName = "sapid")]
        public string Sapid { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "workItem_userId")]
        public string WorkItem_userId { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }
    }
}

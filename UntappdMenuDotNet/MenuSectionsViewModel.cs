using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UntappdMenuDotNet
{
    public class UntappdMenuSections
    {
        [JsonProperty("sections")]
        public UntappdMenuSection[] Sections { get; set; }
    }

    public class UntappdMenuSection
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("menu_id")]
        public long? MenuId { get; set; }

        [JsonProperty("position")]
        public long? Position { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        public List<UntappdMenuItem> UntappdMenuItems { get; set; }
    }
}
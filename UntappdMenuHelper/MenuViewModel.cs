using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UntappdMenuHelper
{
    public partial class UntappdMenus
    {
        [JsonProperty("menus")]
        public UntappdMenu[] Menus { get; set; }
    }

    public partial class UntappdMenu
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("location_id")]
        public long? LocationId { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("unpublished")]
        public bool Unpublished { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("footer")]
        public string Footer { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("published_at_embed")]
        public object PublishedAtEmbed { get; set; }

        [JsonProperty("published_at_untappd")]
        public object PublishedAtUntappd { get; set; }

        [JsonProperty("published_at_facebook")]
        public object PublishedAtFacebook { get; set; }

        [JsonProperty("position")]
        public long? Position { get; set; }

        public List<UntappdMenuSection> UntappdMenuSections { get; set; }
    }
}
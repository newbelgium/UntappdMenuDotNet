using Newtonsoft.Json;
using System;

namespace UntappdMenuHelper
{
    public partial class UntappdMenuAnnouncements
    {
        [JsonProperty("current")]
        public UntappdAnnoucement[] Current { get; set; }

        [JsonProperty("upcoming")]
        public UntappdAnnoucement[] Upcoming { get; set; }

        [JsonProperty("weekly")]
        public UntappdAnnoucement[] Weekly { get; set; }
    }

    public partial class UntappdAnnoucement
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("location_id")]
        public long? LocationId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("canceled")]
        public bool Canceled { get; set; }

        [JsonProperty("next_publish_at")]
        public DateTimeOffset? NextPublishAt { get; set; }

        [JsonProperty("last_published_at")]
        public DateTimeOffset? LastPublishedAt { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("post_to_facebook")]
        public bool PostToFacebook { get; set; }

        [JsonProperty("post_to_twitter")]
        public bool PostToTwitter { get; set; }

        [JsonProperty("display_on_embed_menu")]
        public bool DisplayOnEmbedMenu { get; set; }

        [JsonProperty("display_on_print_menu")]
        public bool DisplayOnPrintMenu { get; set; }

        [JsonProperty("display_on_digital_board")]
        public bool DisplayOnDigitalBoard { get; set; }
    }
}
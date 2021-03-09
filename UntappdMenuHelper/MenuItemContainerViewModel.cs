using Newtonsoft.Json;
using System;

namespace UntappdMenuHelper
{
    public partial class UntappdMenuItemContainers
    {
        [JsonProperty("containers")]
        public UntappdMenuItemContainer[] Containers { get; set; }
    }
    public partial class UntappdMenuItemContainer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        [JsonProperty("container_size_id")]
        public long ContainerSizeId { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("container_size")]
        public UntappdMenuItemContainerSize ContainerSize { get; set; }

        [JsonProperty("_track_by")]
        public long TrackBy { get; set; }
    }

    public partial class UntappdMenuItemContainerSize
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("container_size_group_id")]
        public long ContainerSizeGroupId { get; set; }
    }
}
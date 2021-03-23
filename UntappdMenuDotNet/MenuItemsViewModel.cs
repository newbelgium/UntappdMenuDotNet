using Newtonsoft.Json;
using System;

namespace UntappdMenuDotNet
{
    public class UntappdMenuItems
    {
        [JsonProperty("items")]
        public UntappdMenuItem[] Items { get; set; }
    }

    public class UntappdMenuItem
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("section_id")]
        public long? SectionId { get; set; }

        [JsonProperty("position")]
        public long? Position { get; set; }

        [JsonProperty("untappd_id")]
        public long? UntappdId { get; set; }

        [JsonProperty("label_image")]
        public Uri LabelImage { get; set; }

        [JsonProperty("label_image_hd")]
        public Uri LabelImageHd { get; set; }

        [JsonProperty("brewery_location")]
        public string BreweryLocation { get; set; }

        [JsonProperty("abv")]
        public string Abv { get; set; }

        [JsonProperty("ibu")]
        public string Ibu { get; set; }

        [JsonProperty("cask")]
        public bool Cask { get; set; }

        [JsonProperty("nitro")]
        public bool Nitro { get; set; }

        [JsonProperty("tap_number")]
        public object TapNumber { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("in_production")]
        public bool InProduction { get; set; }

        [JsonProperty("untappd_beer_slug")]
        public string UntappdBeerSlug { get; set; }

        [JsonProperty("untappd_brewery_id")]
        public long? UntappdBreweryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("custom_name")]
        public object CustomName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("custom_description")]
        public object CustomDescription { get; set; }

        [JsonProperty("original_description")]
        public string OriginalDescription { get; set; }

        [JsonProperty("style")]
        public string Style { get; set; }

        [JsonProperty("custom_style")]
        public object CustomStyle { get; set; }

        [JsonProperty("original_style")]
        public string OriginalStyle { get; set; }

        [JsonProperty("brewery")]
        public string Brewery { get; set; }

        [JsonProperty("custom_brewery")]
        public object CustomBrewery { get; set; }

        [JsonProperty("original_brewery")]
        public string OriginalBrewery { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("containers")]
        public UntappdMenuItemContainers Containers { get; set; }
    }
}
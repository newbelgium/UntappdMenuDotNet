using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UntappdMenuJSON
{

    public partial class UntappdLocation
    {
        [JsonProperty("locations")]
        public List<UntappdLocationElement> Locations { get; set; }
    }

    public partial class UntappdLocationElement
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("full_address")]
        public string FullAddress { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postcode")]
        // [JsonConverter(typeof(ParseStringConverter))]
        public long? Postcode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("website")]
        public Uri Website { get; set; }

        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("untappd_venue_id")]
        public long? UntappdVenueId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("business_id")]
        public long? BusinessId { get; set; }

        [JsonProperty("cross_streets")]
        public string CrossStreets { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("tz_offset")]
        public long? TzOffset { get; set; }

        [JsonProperty("directions")]
        public string Directions { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("in_business_since")]
        public long? InBusinessSince { get; set; }

        [JsonProperty("number_of_taps")]
        public object NumberOfTaps { get; set; }

        [JsonProperty("food_served")]
        public string FoodServed { get; set; }

        [JsonProperty("growler_filling_station")]
        public string GrowlerFillingStation { get; set; }

        [JsonProperty("crowler_filling_station")]
        public string CrowlerFillingStation { get; set; }

        [JsonProperty("kegs")]
        public string Kegs { get; set; }

        [JsonProperty("hours")]
        public UntappdHour[] Hours { get; set; }

        [JsonProperty("nitro_on_tap")]
        public string NitroOnTap { get; set; }

        [JsonProperty("cask_on_tap")]
        public string CaskOnTap { get; set; }

        [JsonProperty("serve_wine")]
        public string ServeWine { get; set; }

        [JsonProperty("serve_cocktails")]
        public string ServeCocktails { get; set; }

        [JsonProperty("serve_liquor")]
        public string ServeLiquor { get; set; }

        [JsonProperty("outdoor_seating")]
        public string OutdoorSeating { get; set; }

        [JsonProperty("pet_friendly")]
        public string PetFriendly { get; set; }

        [JsonProperty("contact_name")]
        public string ContactName { get; set; }

        [JsonProperty("contact_phone")]
        public string ContactPhone { get; set; }

        [JsonProperty("published_at_untappd")]
        public object PublishedAtUntappd { get; set; }

        [JsonProperty("published_at_embed")]
        public object PublishedAtEmbed { get; set; }

        [JsonProperty("published_at_facebook")]
        public object PublishedAtFacebook { get; set; }

        [JsonProperty("published_count")]
        public long? PublishedCount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("suspended")]
        public bool Suspended { get; set; }

        [JsonProperty("accepted_payment_types")]
        public string[] AcceptedPaymentTypes { get; set; }

        [JsonProperty("twitter_linked")]
        public bool TwitterLinked { get; set; }

        [JsonProperty("facebook_post_page")]
        public bool FacebookPostPage { get; set; }

        [JsonProperty("facebook_menu_page")]
        public bool FacebookMenuPage { get; set; }

        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        [JsonProperty("website_url")]
        public Uri WebsiteUrl { get; set; }


        public List<UntappdMenu> UntappdMenus { get; set; }
        public UntappdMenuAnnouncements UntappdMenuAnnouncements { get; set; }
    }

    public partial class UntappdHour
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("always_open")]
        public bool AlwaysOpen { get; set; }

        [JsonProperty("closed")]
        public bool Closed { get; set; }

        [JsonProperty("open_at")]
        public DateTimeOffset OpenAt { get; set; }

        [JsonProperty("close_at")]
        public DateTimeOffset CloseAt { get; set; }

        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("location_id")]
        public long? LocationId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
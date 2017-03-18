using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CineFy.Entities
{
    public class Cinema
    {
        [JsonProperty(propertyName: "id")]
        public string Id { get; set; }

        [JsonProperty(propertyName: "slug")]
        public string Slug { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "chain_id")]
        public string ChainId { get; set; }

        [JsonProperty(propertyName: "telephone")]
        public string Telephone { get; set; }

        [JsonProperty(propertyName: "Email")]
        public string Email { get; set; }

        [JsonProperty(propertyName: "website")]
        public string Website { get; set; }

        [JsonProperty(propertyName: "booking_type")]
        public string BookingType { get; set; }

        [JsonProperty(propertyName: "location")]
        public Location Location { get; set; }
    }

    public class Location
    {
        [JsonProperty(propertyName: "lat")]
        public double Latitude { get; set; }

        [JsonProperty(propertyName: "lon")]
        public double Longitude { get; set; }

        [JsonProperty(propertyName: "address")]
        public string Address { get; set; }
    }

    public class Address
    {
        [JsonProperty(propertyName: "display_text")]
        public string DisplayText { get; set; }

        [JsonProperty(propertyName: "street")]
        public string Street { get; set; }

        [JsonProperty(propertyName: "house")]
        public string House { get; set; }

        [JsonProperty(propertyName: "zipcode")]
        public string ZipCode { get; set; }

        [JsonProperty(propertyName: "city")]
        public string City { get; set; }

        [JsonProperty(propertyName: "state")]
        public string State { get; set; }

        [JsonProperty(propertyName: "state_abbr")]
        public string StateAbbreviation { get; set; }

        [JsonProperty(propertyName: "country")]
        public string Country { get; set; }

        [JsonProperty(propertyName: "country_code")]
        public string CountryCode { get; set; }
    }
}

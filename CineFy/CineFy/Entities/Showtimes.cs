using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CineFy.Entities
{
    class ShowtimesViewModel
    {
        [JsonProperty("showtimes")]
        public List<Showtime> Showtimes { get; set; }
    }

    public class Showtime
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("movie_id")]
        public string MovieId { get; set; }

        [JsonProperty("cinemas_id")]
        public string CinemaId { get; set; }

        [JsonProperty("start_at")]
        public string StartAt { get; set; }

        [JsonProperty("is_3d")]
        public bool Is3D { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("subtitle_language")]
        public string SubtitleLanguage { get; set; }

        [JsonProperty("auditorium")]
        public string Auditorium { get; set; }

        [JsonProperty("booking_type")]
        public string BookingType { get; set; }

        [JsonProperty("booking_link")]
        public string BookingLink { get; set; }

    }
}

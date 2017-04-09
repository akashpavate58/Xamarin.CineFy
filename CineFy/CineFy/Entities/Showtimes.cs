using System;
using System.Collections.Generic;
using System.Globalization;
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
        public string StartTime {
            get
            {
                return $"Date: {StartAt_AsDateTime.ToString("dd-MM-yyy  @  hh:mm tt")}";
            }
        }

        public DateTime StartAt_AsDateTime
        {
            get
            {
                //2017-04-08T21:30:00-04:00
                return DateTime.ParseExact(StartAt, "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture);
            }
        }

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

    class ShowtimeComparer : IComparer<Showtime>
    {
        public int Compare(Showtime x, Showtime y)
        {
            if (x.StartAt_AsDateTime > y.StartAt_AsDateTime)
                return 1;
            else if (x.StartAt_AsDateTime < y.StartAt_AsDateTime)
                return -1;
            else
                return 0;
        }
    }
}

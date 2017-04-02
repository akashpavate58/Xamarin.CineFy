using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CineFy.Entities
{
    public class MoviesViewModel
    {
        [JsonProperty("meta_info")]
        public MetaInfo MetaInfo { get; set; }

        [JsonProperty("movies")]
        public List<Movie> Movies { get; set; }
    }

    public class MetaInfo
    {
        [JsonProperty("range_from")]
        public int RangeFrom { get; set; }

        [JsonProperty("range_to")]
        public int RangeTo { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("page_index")]
        public int? PageIndex { get; set; }

        [JsonProperty("page_count")]
        public int? PageCount { get; set; }

        [JsonProperty("next_page_token")]
        public string NextPageToken { get; set; }
    }

    public class Movie
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

        [JsonProperty("poster_image")]
        public Image PosterImage { get; set; }

        [JsonProperty("poster_image_thumbnail")]
        public string PosterImageThumbnail { get; set; }

        [JsonProperty("scene_images")]
        public List<Image> SceneImages { get; set; }

        [JsonProperty("runtime")]
        public int? Runtime { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("trailers")]
        public List<Trailer> Trailers { get; set; }

        [JsonProperty("ratings")]
        public Dictionary<string,Rating> Ratings { get; set; } //imdb, tmdb, rotten_tomatos

        [JsonProperty("age_limits")]
        public Dictionary<string,string> AgeLimits { get; set; }

        [JsonProperty("release_dates")]
        public Dictionary<string, List<ReleaseDate>> ReleaseDates { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("production_companies")]
        public List<string> ProductionCompanies { get; set; }

        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; }

        [JsonProperty("imdb_id")]
        public string IMBD_Id { get; set; }

        [JsonProperty("tmdb_id")]
        public string TMBD_Id { get; set; }

        [JsonProperty("rentrak_film__id")]
        public string RentrakFilmId { get; set; }

        [JsonProperty("cast")]
        public List<Person> Cast { get; set; }

        [JsonProperty("crew")]
        public List<Person> Crew { get; set; }
    }

    public class Genre
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Rating
    {
        [JsonProperty("value")]
        public float Value { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
    }

    public class ReleaseDate
    {
        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; } //FORMAT:YYYY-MM-DD
    }

    public class Image
    {
        [JsonProperty("image_files")]
        public List<ImageFile> ImageFiles { get; set; }
    }

    public class ImageFile
    {
        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("size")]
        public Size Size { get; set; }
    }

    public class Size
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class Trailer
    {
        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("is_offical")]
        public bool? IsOfficial { get; set; }

        [JsonProperty("trailer_files")]
        public List<Trailer_File> TrailerFiles { get; set; }
    }

    public class Trailer_File
    {
        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("transfert")]
        public string Transfert { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }

    public class Person
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }
    }
}

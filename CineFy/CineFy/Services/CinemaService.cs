using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CineFy.Entities;

namespace CineFy.Services
{
    public class CinemaService
    {
        private const string URL = "https://api.internationalshowtimes.com/v4";

        public async Task<IEnumerable<Cinema>> GetCinemas(double latitude, double longitude, int radius)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Token token=kLX96klXdgMYefir77EqQH8wtXGJdFjK");

                string url = URL + $"/cinemas/?location={latitude},{longitude}&distance={radius}";

                var response = await client.GetStringAsync(url);

                var cinemasViewModel = JsonConvert.DeserializeObject<CinemasViewModel>(response);

                return cinemasViewModel.Cinemas;
            }
        }

        public async Task<IEnumerable<Movie>> GetMoviesByCinemaId(string CinemaId)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Token token=cvudNN9dpN7WQzpuf1uW6GpiWO4UDx8M");

                string url = URL + $"/movies/?cinema_id={CinemaId}&all_fields=true";

                var response = await client.GetStringAsync(url);

                var moviesViewModel = JsonConvert.DeserializeObject<MoviesViewModel>(response);

                return moviesViewModel.Movies;
            }
        }

        public async Task<IEnumerable<Showtime>> GetShowtimes(string CinemaId, string MovieId)
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Token token=cvudNN9dpN7WQzpuf1uW6GpiWO4UDx8M");

                string url = URL + $"/showtimes/?cinema_id={CinemaId}&movie_id={MovieId}";

                var response = await client.GetStringAsync(url);

                var showtimesViewModel = JsonConvert.DeserializeObject<ShowtimesViewModel>(response);

                return showtimesViewModel.Showtimes;
            }
        }
    }
}

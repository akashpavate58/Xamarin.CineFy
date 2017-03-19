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
                client.DefaultRequestHeaders.Add("Authorization", "Token token=cvudNN9dpN7WQzpuf1uW6GpiWO4UDx8M");

                string url = URL + $"/cinemas/?location={latitude},{longitude}&distance={radius}";

                var response = await client.GetStringAsync(url);

                var cinemasViewModel = JsonConvert.DeserializeObject<CinemasViewModel>(response);

                return cinemasViewModel.Cinemas;
            }
        }
    }
}

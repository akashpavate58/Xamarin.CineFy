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

        public IEnumerable<Cinema> GetCinemas(double latitude, double longitude)
        {
            return new List<Cinema>()
            {
                new Cinema { Id = "123", Name = "AMC"},
                new Cinema { Id = "456", Name = "FTC"},
                new Cinema { Id = "789", Name = "INOX"}
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace CineFy.Services
{
    public class GeoLocation
    {
        public static async Task<Position> GetCurrentLocation()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                
                return position;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

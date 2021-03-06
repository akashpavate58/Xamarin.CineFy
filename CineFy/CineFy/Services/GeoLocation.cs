﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace CineFy.Services
{
    public class GeoLocation
    {
        public static async Task<Position> GetCurrentLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            
            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

            return position;

        }
    }
}

﻿using Newtonsoft.Json;
using System;

namespace Airport.Web.Controllers
{
    public class UpdateAirCraftTypeModel
    {
        [JsonProperty("id")]
        public Guid AirCraftTypeId { get; set; }
        public string Model { get; set; }
        public int Seats { get; set; }
        public int LoadCapacity { get; set; }
    }
}
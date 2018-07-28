﻿using Newtonsoft.Json;
using System;

namespace Airport.Web.Controllers
{
    public class UpdateStewardessModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
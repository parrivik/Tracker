using System;
using Newtonsoft.Json;


namespace Tracker.RestService.Data
{
    public class UserData
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

    }
}

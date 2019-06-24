using System;
using Newtonsoft.Json;

namespace Tracker.RestService.Data
{
    public class PersonData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("prename")]
        public string Prename { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CitizensRegistryApp.Core.Profiles.Dto
{
    public class ProfileDto
    {
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }
    }
}

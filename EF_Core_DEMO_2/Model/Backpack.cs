﻿using System.Text.Json.Serialization;

namespace EF_Core_DEMO_2.Model
{
    public class Backpack
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CharacterId { get; set; }

        [JsonIgnore]
        public Character Character { get; set; }
    }
}

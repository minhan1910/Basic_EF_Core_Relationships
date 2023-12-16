using System.Text.Json.Serialization;

namespace EF_Core_DEMO_2.Model
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Character> Characters { get; set; }
    }
}

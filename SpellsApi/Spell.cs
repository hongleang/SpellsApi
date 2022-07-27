namespace SpellsApi
{
    // Spell myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Spell
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Incantation { get; set; }
        public string? Effect { get; set; }
        public bool? CanBeVerbal { get; set; }
        public string? Type { get; set; }
        public string? Light { get; set; }
        public string? Creator { get; set; }
    }
}

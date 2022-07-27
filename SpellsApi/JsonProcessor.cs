using Newtonsoft.Json;

namespace SpellsApi
{
    public class JsonProcessor
    {
        public async Task<List<Spell>> LoadFile(string pathName)
        {
            using (StreamReader reader = File.OpenText(pathName))
            {
                string json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<Spell>>(json) ?? new List<Spell>();
            }
        }

        public async Task UpdateJsonFile(string pathName, List<Spell> data)
        {
            string json = JsonConvert.SerializeObject(data.ToArray());
            await File.WriteAllTextAsync(pathName, json);
        }
    }
}

using SpellsApi;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

JsonProcessor jsonLoader = new JsonProcessor();

string fileName = "spells.json";
string path = Path.Combine(Environment.CurrentDirectory, @"DB\", fileName);


// @Db
List<Spell> spells = await jsonLoader.LoadFile(path);


// @Route controller
// @Get all Items
app.MapGet("/spells", () => spells);

// @Get one Item
app.MapGet("/spells/{id}", (int id) =>
{
    var spell = spells.Find(s => s.Id == id);
    if (spell != null)
    {
        return Results.Ok(spell);
    }
    return Results.NotFound("Spell not found!");
});

// @Post create an Item
app.MapPost("/spells", async (HttpRequest request) =>
{
    var newSpell = await request.ReadFromJsonAsync<Spell>();
    if (newSpell != null)
    {
        newSpell.Id = spells.Last().Id + 1; // generate random id for the new item
        spells.Add(newSpell);

        await jsonLoader.UpdateJsonFile(path, spells);

        return Results.Created(@"/spells/{newSpell.id}", newSpell);
    }

    return Results.NotFound("Spell not found!");
});

// @Update an item
app.MapPut("/spells/{id}", async (HttpRequest request, int id) =>
{
    var spell = spells.Find(s => s.Id == id);
    var requestedSpell = await request.ReadFromJsonAsync<Spell>();

    if (spell is null || requestedSpell is null) return Results.NotFound("Spell not found!");

    foreach (PropertyInfo prop in requestedSpell.GetType().GetProperties())
    {
        var value = prop.GetValue(requestedSpell, null);
        var objProp = spell.GetType().GetProperty(prop.Name ?? "");

        // Update on the prop that match new given prop
        if (value != null && objProp != null)
        {
            objProp.SetValue(spell, value);
        }
    }

    await jsonLoader.UpdateJsonFile(path, spells);

    return Results.Ok(spell);
});


// @Delete an Item
app.MapDelete("spells/{id}", async (int id, HttpRequest request) =>
{
    int index = spells.FindIndex(s => s.Id == id);

    if (index > -1 && index < spells.Count)
    {
        spells.RemoveAt(index);

        await jsonLoader.UpdateJsonFile(path, spells);

        return Results.Ok(spells[index]);
    }

    return Results.NotFound("Spell not found!");
});


app.Run();

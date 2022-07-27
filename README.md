# Wizard world spells

### Description
Json data used for this project is derived from: https://wizard-world-api.herokuapp.com/swagger/index.html.

This is a basic CRUD api that I built using ASP.NET 6.0 minimal api template. It allows user to do basic CRUD operation on the Json file locate inside DB directory.
There are four spells exist inside the Json file which are used across the Harry potter book series.

### Usage
Run the code with Visual studio and use postman to test the following endpoints.

#### GET Spells
`https://localhost:7190/spells`

Get all spell from the Json file.

#### POST AddSpells
`https://localhost:7190/spells`

Create a new spell with the given body json.

##### Bodyraw (json):
```
{
  "name": "Animagaylum Spell",
  "incantation": "Amanamto Animistetisa",
  "effect": "May not work just created",
  "creator": "Hongleang"
}
```

#### GET Spell
`https://localhost:7190/spells/{id}`

Get a spell based on the given id {eg: 1, 2, 3 ...}.

#### UPDATE Spells
`https://localhost:7190/spells/{id}`

Update a spell based on the given id {eg: 1, 2, 3 ...} and a given json prop.

##### Bodyraw (json):
```
{
   "name": "Juggle spell"
}
```

#### DELETE Spells
`https://localhost:7190/spells/{id}`

Delete a spell based on the given id {eg: 1, 2, 3 ...}.






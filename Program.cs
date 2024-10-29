using System.Text.Json;
using game1402_a2_starter;


string fileName = "../../../game_data.json";//if you are ever worried about whether your json is valid or not, check out JSON Lint: 

GameData yourGameData;
string jsonString = File.ReadAllText(@fileName);
GameData gameData = JsonSerializer.Deserialize<GameData>(jsonString);

Game game = new Game(gameData);
game.Start();


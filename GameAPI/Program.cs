using GameAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndPointName = "GetGame";

List<GameDTos> games = [
    new (1,"FIFA","Sports",79.99M, new DateOnly(2022,9,27)),
    new (2,"COD","Action",58.99M, new DateOnly(2022,9,27)),
    new (3,"GTA V","Action",100.99M, new DateOnly(2022,9,27)),
];


//GET //games
app.MapGet("/", () => "Hello World!");

app.MapGet("/games/{id}",(int id)=>games.Find(game=>game.Id == id)).WithName(GetGameEndPointName);

//POST /games
app.MapPost("/games",(CreateGameDTos newGame)=>{
    GameDTos gameDTos = new GameDTos(games.Count+1,newGame.Name,newGame.Genre,newGame.Price,newGame.ReleaseDate);
    games.Add(gameDTos);
    return Results.CreatedAtRoute(GetGameEndPointName,new {id=gameDTos.Id},gameDTos);
});


//PUT /games
app.MapPut("/games/{id}",(int id, UpdateGameD updateGame)=>{
    int index  = games.FindIndex(game=> game.Id ==id);
    games[index] = new GameDTos(id,updateGame.Name,updateGame.Genre,updateGame.Price,updateGame.ReleaseDate);
});

app.Run();

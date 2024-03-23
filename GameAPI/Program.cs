using GameAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



//GET //games
app.MapGet("/", () => "Hello World!");

app.MapGet("/games/{id}",(int id)=>{
    GameDTos? gameDTos = games.Find(game=>game.Id == id);
    if(gameDTos == null){
        return Results.NotFound();
    }else{
        return Results.Ok(gameDTos);
    }
}).WithName(GetGameEndPointName);

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
    return Results.NoContent();
});

app.MapDelete("/games/{id}",(int id)=>{
    games.RemoveAll(game=>game.Id == id);
    return Results.NoContent();
});

app.Run();

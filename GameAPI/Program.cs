using GameAPI;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDTos> games = new List<GameDTos>{
    new (1,"FIFA","Sports",79.99M, new DateOnly(2022,9,27)),
    new (2,"COD","Action",58.99M, new DateOnly(2022,9,27)),
    new (3,"GTA V","Action",100.99M, new DateOnly(2022,9,27)),
};

app.MapGet("/games",()=>games);
app.MapGet("/", () => "Hello World!");

app.Run();

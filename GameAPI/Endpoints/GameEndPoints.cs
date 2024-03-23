namespace GameAPI;


//this is an extension method
public static class GameEndPoints
{
    const string GetGameEndPointName = "GetGame";

    private static readonly List<GameDTos> games = [
        new (1,"FIFA","Sports",79.99M, new DateOnly(2022,9,27)),
        new (2,"COD","Action",58.99M, new DateOnly(2022,9,27)),
        new (3,"GTA V","Action",100.99M, new DateOnly(2022,9,27)),
    ];

    public static 
}

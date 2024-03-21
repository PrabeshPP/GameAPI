namespace GameAPI;

public record class GameDTos(int Id, string Name, string Genre, decimal Price, DateOnly ReleaseDate);

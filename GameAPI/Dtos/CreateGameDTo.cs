namespace GameAPI;

public record class CreateGameDTos(string Name, string Genre, decimal Price, DateOnly ReleaseDate);
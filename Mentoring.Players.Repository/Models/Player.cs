namespace players_app;

public class Player
{
    public Player(string name, int level)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(level);

        Name = name;
        Level = level;
        Id = Guid.NewGuid();
    }

    public Guid Id { get; }
    public string Name { get; }
    public int Level { get; }
    public bool IsBanned { get; set; }
    
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Level: {Level}, Banned: {IsBanned}";
    }
}
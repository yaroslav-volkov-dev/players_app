namespace Mentoring.Players.Repository.Models;

public class Player
{
    public Guid Id { get; }
    public string Name { get; }
    public int Level { get; }
    public bool IsBanned { get; set; }
    
    public Player(string name, int level)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(level);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
        Level = level;
        Id = Guid.NewGuid();
        IsBanned = false;
    }
    
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Level: {Level}, Banned: {IsBanned}";
    }
}
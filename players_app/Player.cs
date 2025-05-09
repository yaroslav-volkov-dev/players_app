namespace players_app;

public class Player(string name, int level)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public int Level { get; set; } = level;
    public bool IsBanned { get; set; }
    
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Level: {Level}, Banned: {IsBanned}";
    }
}
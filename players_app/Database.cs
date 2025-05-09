using System.Diagnostics.CodeAnalysis;

namespace players_app;

public class PlayersDatabase
{
    private Dictionary<Guid, Player> Players { get; } = [];

    public void AddPlayer(string name, int level)
    {
        Player newPlayer = new(name, level);
        Players.Add(newPlayer.Id, newPlayer);
    }

    public void RemovePlayer(Guid id)
    {
        bool isPlayerExists = TryFindPlayerById(id, out Player? player);

        if (!isPlayerExists)
        {
            Console.WriteLine($"There's no player with id {id}");
            return;
        }

        Players.Remove(id);
    }

    public void BanPlayerById(Guid id)
    {
        if (TryFindPlayerById(id, out Player? player))
        {
            player.IsBanned = true;
            Console.WriteLine($"Player {player.Name} has been banned");
            return;
        }

        Console.WriteLine($"There's no player with id {id}");
    }

    public void UnbanPlayerById(Guid id)
    {
        if (TryFindPlayerById(id, out Player? player))
        {
            player.IsBanned = false;
            Console.WriteLine($"Player {player.Name} has been unbanned");
            return;
        }

        Console.WriteLine($"There's no player with id {id}");
    }

    public Player[] GetAllPlayers()
    {
        return Players.Values.ToArray();
    }

    public Player? GetPlayerById(Guid id)
    {
        return TryFindPlayerById(id, out Player? player) ? player : null;
    }

    private bool TryFindPlayerById(Guid id, [NotNullWhen(true)] out Player? player)
    {
        return Players.TryGetValue(id, out player);
    }
}

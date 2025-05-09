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

    public Player? RemovePlayer(Guid id)
    {
        bool isPlayerExists = TryFindPlayerById(id, out Player? player);

        if (!isPlayerExists) return null;

        Players.Remove(id);
        
        return player;
    }

    public Player? BanPlayerById(Guid id)
    {
        if (!TryFindPlayerById(id, out Player? player)) return null;
        player.IsBanned = true;
        return player;
    }

    public Player? UnbanPlayerById(Guid id)
    {
        if (!TryFindPlayerById(id, out Player? player)) return null;
        player.IsBanned = false;
        return player;

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

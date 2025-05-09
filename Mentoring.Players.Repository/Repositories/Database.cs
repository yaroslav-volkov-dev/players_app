using System.Diagnostics.CodeAnalysis;

namespace players_app;

public interface IPlayersDatabase
{
    void AddPlayer(string name, int level);
    Player? TryRemovePlayer(Guid id);
    Player? BanPlayerById(Guid id);
    Player? UnbanPlayerById(Guid id);
    Player[] GetAllPlayers();
    Player? GetPlayerById(Guid id);
}


public class PlayersPostgresRepository : IPlayersDatabase
{
    public void AddPlayer(string name, int level)
    {
        throw new NotImplementedException();
    }

    public Player? TryRemovePlayer(Guid id)
    {
        throw new NotImplementedException();
    }

    public Player? BanPlayerById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Player? UnbanPlayerById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Player[] GetAllPlayers()
    {
        throw new NotImplementedException();
    }

    public Player? GetPlayerById(Guid id)
    {
        throw new NotImplementedException();
    }
}

public class PlayersInMemoryRepository : IPlayersDatabase
{
    //TODO: Dictionary може бути лишнім, тоже не надо проперті, сенсу в ньому немає,
    private readonly Dictionary<Guid, Player> _players = [];

    public void AddPlayer(string name, int level)
    {
        //TODO: валіадція вхідних параметрів
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (level < 1) throw new ArgumentOutOfRangeException(nameof(level));

        Player newPlayer = new(name, level);
        _players.Add(newPlayer.Id, newPlayer);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Is player does not exists</exception>
    public bool TryRemovePlayer(Guid id)
    {
        bool isPlayerExists = TryFindPlayerById(id, out Player? player);

        if (!isPlayerExists)
        {
            return false;
        }

        _players.Remove(id);
        
        return true;
    }

    PlayersInMemoryRepository();


    public Player? BanPlayerByIdAndReturnPlayer(Guid id)
    {
        //TODO: ми ніколи не вертаєм null, поганий тон, краще throw new Exception()
        if (!TryFindPlayerById(id, out Player? player))
        {
            return null;
        }

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
        return _players.Values.ToArray();
    }

    public Player? GetPlayerById(Guid id)
    {
        return TryFindPlayerById(id, out Player? player) ? player : null;
    }

    private bool TryFindPlayerById(Guid id, [NotNullWhen(true)] out Player? player)
    {
        return _players.TryGetValue(id, out player);
    }
}

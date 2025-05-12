using System.Diagnostics.CodeAnalysis;
using Mentoring.Players.Repository.Interfaces;
using Mentoring.Players.Repository.Models;

namespace Mentoring.Players.Repository.Repositories;

public class PlayersInMemoryRepository : IPlayersRepository
{
    private readonly List<Player> _playersDatabase = [];

    public void AddPlayer(string name, int level)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(level);

        Player newPlayer = new(name, level);
        _playersDatabase.Add(newPlayer);
    }

    public void RemovePlayer(Guid id)
    {
        bool isPlayerExists = _playersDatabase.Any(player => player.Id == id);
        
        if (!isPlayerExists)
        {
            throw new KeyNotFoundException();
        }
        
        _playersDatabase.RemoveAll(player => player.Id == id);
    }

    public void BanPlayerById(Guid id)
    {
        Player player = GetPlayerById(id);
        player.IsBanned = true;
    }

    public void UnbanPlayerById(Guid id)
    {
        Player player = GetPlayerById(id);
        player.IsBanned = false;

    }

    public Player[] GetAllPlayers()
    {
        return _playersDatabase.ToArray();
    }

    public Player GetPlayerById(Guid id)
    {
        Player? player = _playersDatabase.Find(player => player.Id == id);
        
        if (player is null)
        {
            throw new KeyNotFoundException("The player was not found.");
        };

        return player;
    }
}
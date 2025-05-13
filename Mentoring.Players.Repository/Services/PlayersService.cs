using Mentoring.Players.Repository.Interfaces;
using Mentoring.Players.Repository.Models;

namespace Mentoring.Players.Repository.Services;

public class PlayersService
{
    public List<Player> Filter(List<Player> players, Predicate<Player> callback)
    {
        ArgumentNullException.ThrowIfNull(callback);

        List<Player> filteredPlayers = new();

        for (int i = 0; i < players.Count; i++)
        {
            Player currentPlayer = players[i];
            bool isCheckPassed = callback(currentPlayer);
           
            if (isCheckPassed)
            {
                filteredPlayers.Add(currentPlayer);
            }
        }

        return filteredPlayers;
    }

    public List<Player> Map(List<Player> players, Func<Player, Player> callback)
    {
        ArgumentNullException.ThrowIfNull(callback);

        return players.Select(callback).ToList();
    }
    
    public void ForEach(List<Player> players, Action<Player> callback)
    {
        ArgumentNullException.ThrowIfNull(callback);

        foreach (Player player in players)
        {
            callback(player);
        }
    }
}
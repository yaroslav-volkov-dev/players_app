
using Mentoring.Players.Repository.Models;
using Mentoring.Players.Repository.Services;

namespace Mentoring.Players.Repository;

public static class Program
{
    private static List<Player> mockPlayers = new()
    {
        new Player("Yaroslav", 10),
        new Player("Dmitriy", 30)
    };
    
    private static PlayersService _playersService = new();
    
    private static void Main(string[] args)
    {
        // ConsoleInterface consoleInterface = new();
        // consoleInterface.Run();
        
        List<Player> filteredPlayers = _playersService.Filter(mockPlayers, (player) => player.Level > 10);
        
        List<Player> mappedPlayers = _playersService.Map(mockPlayers, (player) =>
        {
            player.IsBanned = true;
            return player;
        });
        
        _playersService.ForEach(mappedPlayers, Console.WriteLine);
        _playersService.ForEach(filteredPlayers, Console.WriteLine);
    }
}
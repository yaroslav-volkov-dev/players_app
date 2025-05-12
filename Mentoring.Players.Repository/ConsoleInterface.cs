using Mentoring.Players.Repository.Models;
using Mentoring.Players.Repository.Repositories;

namespace Mentoring.Players.Repository;

public class ConsoleInterface
{
    private enum ConsoleStateEnum
    {
        None,
        MainMenu,
        AddPlayer,
        RemovePlayer,
        BanPlayer,
        UnbanPlayer,
        ShowAllPlayers,
        ShowPlayerById,
        Exit
    }
    
    private readonly PlayersInMemoryRepository _playersRepository = new();
    private ConsoleStateEnum ConsoleState { get; set; } = ConsoleStateEnum.MainMenu;

    public void Run()
    {
        while (ConsoleState != ConsoleStateEnum.Exit)
        {
            switch (ConsoleState)
            {
                case ConsoleStateEnum.MainMenu:
                    ShowMainMenuUI();
                    break;
                case ConsoleStateEnum.AddPlayer:
                    ShowAddPlayerUI();
                    break;
                case ConsoleStateEnum.RemovePlayer:
                    ShowRemovePlayerUI();
                    break;
                case ConsoleStateEnum.ShowAllPlayers:
                    ShowGetAllPlayersUI();
                    break;
                case ConsoleStateEnum.ShowPlayerById:
                    ShowPlayerByIdUI();
                    break;
                case ConsoleStateEnum.BanPlayer: 
                    ShowBanPlayerUI();
                    break;
                case ConsoleStateEnum.UnbanPlayer:
                    ShowUnbanPlayerUI();
                    break;
                default:
                    Console.WriteLine("There's no such action");
                    break;
            }
        }
    }
    
    private void ShowMainMenuUI()
    {
        Console.WriteLine("Please, select an action by number:");
        Console.WriteLine("1) Add");
        Console.WriteLine("2) Remove");
        Console.WriteLine("3) Show players list");
        Console.WriteLine("4) Show player by ID");
        Console.WriteLine("5) Ban player by ID");
        Console.WriteLine("6) Unban player by ID");
        Console.WriteLine("7) Exit");
        
        string? input = Console.ReadLine()?.Trim();

        switch (input)
        {
            case "1":
                ConsoleState = ConsoleStateEnum.AddPlayer;
                break;
            case "2":
                ConsoleState = ConsoleStateEnum.RemovePlayer;
                break;
            case "3":
                ConsoleState = ConsoleStateEnum.ShowAllPlayers;
                break;
            case "4":
                ConsoleState = ConsoleStateEnum.ShowPlayerById;
                break;
            case "5":
                ConsoleState = ConsoleStateEnum.BanPlayer;
                break;
            case "6":
                ConsoleState = ConsoleStateEnum.UnbanPlayer;
                break;
            case "7":
                ConsoleState = ConsoleStateEnum.Exit;
                break;
            default:
                Console.WriteLine("There's no such action");
                ConsoleState = ConsoleStateEnum.MainMenu;
                break;
        }
        
    }

    private void ShowAddPlayerUI()
    {
        Console.WriteLine("Please, enter a name:");
        string? name = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty");
            ConsoleState = ConsoleStateEnum.AddPlayer;
            return;
        }
        
        Console.WriteLine("Please, enter a level");
        string? levelInput = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(levelInput)) 
        {
            Console.WriteLine("Level cannot be empty");
            ConsoleState = ConsoleStateEnum.AddPlayer;
            return;
        }
        
        if (!int.TryParse(levelInput, out int level)) 
        {
            Console.WriteLine("Invalid level format. Please enter a valid number.");
            ConsoleState = ConsoleStateEnum.AddPlayer;
            return;
        }
        
        if (level <= 0) 
        {
            Console.WriteLine("Level must be a positive number");
            ConsoleState = ConsoleStateEnum.AddPlayer;
            return;
        }
        
        _playersRepository.AddPlayer(name, level);
        Console.WriteLine("Player successfully added");
        ConsoleState = ConsoleStateEnum.MainMenu;
    }
    
    private void ShowRemovePlayerUI()
    {
        Console.WriteLine("Please, enter a player ID:");
        string? playerId = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(playerId))
        {
            Console.WriteLine("Id cannot be empty");
            ConsoleState = ConsoleStateEnum.RemovePlayer;
            return;
        } 
        
        _playersRepository.RemovePlayer(Guid.Parse(playerId));
        Console.WriteLine("Player successfully removed");
        ConsoleState = ConsoleStateEnum.MainMenu;
    }
    
    private void ShowBanPlayerUI()
    {
        Console.WriteLine("Please, enter a player ID:");
        string? playerId = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(playerId))
        {
            Console.WriteLine("Id cannot be empty");
            ConsoleState = ConsoleStateEnum.BanPlayer;
            return;
        } 
        
        _playersRepository.BanPlayerById(Guid.Parse(playerId));
        Console.WriteLine("Player successfully banned");
        ConsoleState = ConsoleStateEnum.MainMenu;
    }

    private void ShowUnbanPlayerUI()
    {
        Console.WriteLine("Please, enter a player ID:");
        string? playerId = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(playerId))
        {
            Console.WriteLine("Id cannot be empty");
            ConsoleState = ConsoleStateEnum.UnbanPlayer;
            return;
        } 
        
        _playersRepository.UnbanPlayerById(Guid.Parse(playerId));
        Console.WriteLine("Player successfully unbanned");
        ConsoleState = ConsoleStateEnum.MainMenu;
    }

    private void ShowGetAllPlayersUI()
    {
        Player[] players = _playersRepository.GetAllPlayers();
        foreach (Player player in players)
        {
            Console.WriteLine(player);
        }

        ConsoleState = ConsoleStateEnum.MainMenu;
    }

    private void ShowPlayerByIdUI()
    {
        Console.WriteLine("Please, enter a player ID:");
        string? playerId = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(playerId))
        {
            Console.WriteLine("Id cannot be empty");
            ConsoleState = ConsoleStateEnum.UnbanPlayer;
            return;
        } 
        
        Player player = _playersRepository.GetPlayerById(Guid.Parse(playerId));
        Console.WriteLine(player);
    }
}
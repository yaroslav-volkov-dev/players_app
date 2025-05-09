namespace players_app;

public class ConsoleInterface
{
    private enum ConsoleStateEnum
    {
        //TODO: тут надо добавляти None
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

    //todo: readonly and IPlayersDatabase
    private readonly IPlayersDatabase _repository = new PlayersPostgresRepository();

    //todo; нема сенсу робити проперті, якщо воно приватне
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
                case ConsoleStateEnum.Exit:
                    Exit();
                    break;
                default:
                    Console.WriteLine("There's no such action");
                    break;
            }
        }
    }

    private void ShowMainMenuUI()
    {
        //TODO Add selectable interface
        Console.WriteLine("Please, select an action by number:");
        Console.WriteLine("1) Add");
        Console.WriteLine("2) Remove");
        Console.WriteLine("3) Show players list");
        Console.WriteLine("4) Show player by ID");
        Console.WriteLine("5) Exit");
        
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
                ConsoleState = ConsoleStateEnum.BanPlayer;
                break;
            case "5":
                ConsoleState = ConsoleStateEnum.UnbanPlayer;
                break;
            case "6":
                ConsoleState = ConsoleStateEnum.ShowPlayerById;
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
        
        Console.WriteLine("Please, enter a level");
        string? level =  Console.ReadLine()?.Trim();

        bool isInvalidLevel = !int.TryParse(level, out int levelInt);

        //TODO: refactoring
        if (isInvalidLevel || string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("One of the values is invalid");
            ConsoleState = ConsoleStateEnum.AddPlayer;
            return;
        };
        
        _repository.AddPlayer(name, levelInt);

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

        //TODO: не дуже коректно вертати, можна вертати true false
        Player? removedPlayer = _repository.TryRemovePlayer(Guid.Parse(playerId));
        if (removedPlayer == null)
        {
            Console.WriteLine("Player not found");
            ConsoleState = ConsoleStateEnum.RemovePlayer;
            return;
        }
        
        Console.WriteLine("Player successfully removed");
        ConsoleState = ConsoleStateEnum.MainMenu;
    }
    
    private void ShowBanPlayerUI()
    {
        
    }

    private void ShowUnbanPlayerUI()
    {
        
    }

    private void ShowGetAllPlayersUI()
    {
        Player[] players = _repository.GetAllPlayers();
        foreach (Player player in players)
        {
            Console.WriteLine(player);
        }

        ConsoleState = ConsoleStateEnum.MainMenu;
    }

    private void ShowPlayerByIdUI()
    {
        
    }

    private void Exit()
    {
        ConsoleState = ConsoleStateEnum.Exit;
    }
}
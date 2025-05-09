namespace players_app;

public class ConsoleInterface
{
    private enum ConsoleStateEnum
    {
        MainMenu,
        AddPlayer,
        RemovePlayer,
        ShowAllPlayers,
        ShowPlayerById,
        Exit
    }
    
    private PlayersDatabase _db = new();
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
                ConsoleState = ConsoleStateEnum.ShowPlayerById;
                break;
            case "5":
                ConsoleState = ConsoleStateEnum.Exit;
                break;
            default:
                Console.WriteLine("There's no such action");
                break;
        }
        
    }

    private void ShowAddPlayerUI()
    {
        
    }

    private void ShowRemovePlayerUI()
    {
        
    }

    private void ShowGetAllPlayersUI()
    {
        
    }

    private void ShowPlayerByIdUI()
    {
        
    }

    private void Exit()
    {
        ConsoleState = ConsoleStateEnum.Exit;
    }
}
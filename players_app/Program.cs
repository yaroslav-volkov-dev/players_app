
namespace players_app;

public static class Program
{
    private static void Main(string[] args)
    {
        bool running = true;
        PlayersDatabase db = new PlayersDatabase();

        while (running)
        {
            Console.WriteLine("Hello! Please select an action");
            string? action = Console.ReadLine();

            switch (action)
            {
                case "add":
                    db.AddPlayer("Yarik", 20);
               
                    foreach (var player in db.GetAllPlayers())
                    {
                        Console.WriteLine(player);
                    }
                
                    break;
            
            }
        }
    }
}
using Mohaymen_Cmd.Model;

namespace Mohaymen_Cmd.Controller
{
    internal class CommandProcessor : ICommandProcessor
    {
        private readonly ApplicationDbContext dbcontext;

        public CommandProcessor(ApplicationDbContext context)
        {
            dbcontext = context;
        }

        public void ProcessCommand(string[] commandParts)
        {
            string command = commandParts[0].ToLower();
            switch (command)
            {
                case "hello":
                    Console.WriteLine("Hello there!");
                    break;
                case "time":
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                    break;
                case "search":
                    if (commandParts.Length > 1)
                    {
                        string searchTerm = string.Join(" ", commandParts, 1, commandParts.Length - 1);
                        Console.WriteLine($"You searched for: {searchTerm}");
                    }
                    else
                    {
                        Console.WriteLine("Usage: search [term]");
                    }
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }

    }
}

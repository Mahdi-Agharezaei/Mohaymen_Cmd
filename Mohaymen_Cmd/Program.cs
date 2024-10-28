using Mohaymen_Cmd.Controller;
using Mohaymen_Cmd.Model;

namespace Mohaymen_Cmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mohaymen Cmd App :)");

            do
            {
                Console.Write("Enter instruction:>");
                string[] input = Console.ReadLine().Trim().Split();

                if (input.Length != 0 && !string.IsNullOrEmpty(input[0]))
                {
                    string? Instruction = CommandProcessor.Instructions_PartCounts.Select(x => x.Key).Where(x => x == input[0].ToLower()).FirstOrDefault();
                    if (Instruction is not null)
                    {
                        if (CommandProcessor.Instructions_PartCounts.First(x => x.Key == Instruction).Value == input.Length)
                        {
                            if (Instruction == "exit")
                            {
                                break;
                            }
                            else
                            {
                                using (var context = new ApplicationDbContext())
                                {
                                    ICommandProcessor commandProcessor = new CommandProcessor(context);
                                    commandProcessor.ProcessCommand(Instruction, input[1..]);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Wrong Part Count!");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong instruction!");
                        continue;
                    }
                }
            }
            while (true);

            Environment.Exit(0);
        }
    }
}

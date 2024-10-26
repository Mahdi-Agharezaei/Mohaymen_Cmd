namespace Mohaymen_Cmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>();
            bool IsLogin = false;
            List<int> PartCounts = new List<int> { 1, 3, 5 };

            do
            {
                Console.Write("Enter instruction:>");
                input = Console.ReadLine().Trim().Split().ToList();

                bool IsAnomaly = false;
                if (!PartCounts.Contains(input.Count)) { IsAnomaly = true; }

                if (!string.IsNullOrEmpty(input.First()))
                {
                    string CurrentInstruction = string.Empty;

                    var MaybeInstruction = Instructions.Where(x => x == input.First().ToLower());
                    if (MaybeInstruction.Any())
                    {
                        CurrentInstruction = MaybeInstruction.First();

                        //ToDo

                        if (CurrentInstruction == "register" && input.Count == 5)
                        {

                        }

                        if (CurrentInstruction == "login" && input.Count == 5)
                        {

                        }

                        if (CurrentInstruction == "change" && input.Count == 3)
                        {

                        }

                        if (CurrentInstruction == "search" && input.Count == 3)
                        {

                        }

                        if (CurrentInstruction == "changepassword" && input.Count == 5)
                        {

                        }

                        if (CurrentInstruction == "logout" && input.Count == 1)
                        {
                            IsLogin = false;
                            Console.WriteLine("You are logged out!");
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
            while (input.First().ToLower() != "exit"); ///Feature: || input.ToLower() == "clear"

            Environment.Exit(0);
        }

        static List<string> Instructions = new List<string>
        {
            "register",
            "login",
            "change",
            "search",
            "changepassword",
            "logout"
        };

        static List<string> Keys = new List<string>
        {
            "--username",
            "--password",
            "--status",
            "--old",
            "--new"
        };
    }
}

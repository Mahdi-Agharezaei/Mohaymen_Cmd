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

        public static Dictionary<string, int> Instructions_PartCounts = new Dictionary<string, int>()
        {
            { "register", 5},
            { "login", 5},
            { "change", 3},
            { "search", 3},
            { "changepassword", 5},
            { "logout", 1},
            { "clear", 1},
            { "exit", 1},
            { "Delete", 5 }
        };

        static List<string> Keys = new List<string>
        {
            "--username",
            "--password",
            "--status",
            "--old",
            "--new"
        };

        public void ProcessCommand(string Instruction, string[] CommandParts)
        {
            UserServices userServices = new UserServices(dbcontext);

            string Username = GetParameterValue(CommandParts, "--username");
            string Password = GetParameterValue(CommandParts, "--password");
            string Status = GetParameterValue(CommandParts, "--status");
            string OldPassword = GetParameterValue(CommandParts, "--old");
            string NewPassword = GetParameterValue(CommandParts, "--new");

            switch (Instruction)
            {
                case "register":
                    userServices.Register(Username, Password);
                    break;

                case "login":
                    userServices.Login(Username, Password);
                    break;

                case "change":
                    userServices.Change(Status);
                    break;

                case "search":
                    userServices.Search(Username);
                    break;

                case "changepassword":
                    userServices.ChangePassword(OldPassword, NewPassword);
                    break;

                case "logout":
                    userServices.Logout();
                    break;

                case "clear":
                    userServices.Clear();
                    break;

                case "Delete":
                    userServices.DeleteUser(Username, Password);
                    break;
                default:
                    break;
            }
        }

        private string GetParameterValue(string[] CommandParts, string ParameterName)
        {
            int i = 0;
            foreach (string CP in CommandParts)
            {
                if (CP.ToLower() == ParameterName.ToLower() && i + 1 < CommandParts.Length)
                {
                    return CommandParts[i + 1];
                }

                i++;
            }

            return null;
        }
    }
}

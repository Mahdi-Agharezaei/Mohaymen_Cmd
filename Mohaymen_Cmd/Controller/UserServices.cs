using Mohaymen_Cmd.Model;

namespace Mohaymen_Cmd.Controller
{
    internal class UserServices
    {
        private readonly ApplicationDbContext dbcontext;

        public UserServices(ApplicationDbContext context)
        {
            dbcontext = context;
        }

        public void ProcessCommand(string[] commandParts)
        {
            string command = commandParts[0].ToLower();
            switch (command)
            {
                case "register":
                    string registerUsername = GetParameterValue(commandParts, "--username");
                    string registerPassword = GetParameterValue(commandParts, "--password");
                    Register(registerUsername, registerPassword);
                    break;
                case "login":
                    string loginUsername = GetParameterValue(commandParts, "--username");
                    string loginPassword = GetParameterValue(commandParts, "--password");
                    Login(loginUsername, loginPassword);
                    break;
                case "logout":
                    Logout();
                    break;
                default:
                    Console.WriteLine("Unknown user command.");
                    break;
            }
        }
        public void Register(string username, string password)
        {
            if (dbcontext.Users.Any(u => u.UserName == username))
            {
                Console.WriteLine("Username already exists. Try a different one.");
            }
            else
            {
                dbcontext.Users.Add(new User { UserName = username, Password = password, Status = true, CreationDate = DateTime.Now, ModificationDate = DateTime.Now });
                dbcontext.SaveChanges();
                Console.WriteLine("Registration successful. You can now log in.");
            }
        }
        public bool Login(string username, string password)
        {
            var user = dbcontext.Users.SingleOrDefault(u => u.UserName == username && u.Password == password);
            if (user != null)
            {
                Console.WriteLine("Login successful!");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid credentials. Try again.");
                return false;
            }
        }
        public void Logout()
        {
            Console.WriteLine("Logged out successfully.");
        }
        private string GetParameterValue(string[] commandParts, string parameterName)
        {
            for (int i = 0; i < commandParts.Length; i++)
            {
                if (commandParts[i].ToLower() == parameterName.ToLower() && i + 1 < commandParts.Length)
                {
                    return commandParts[i + 1];
                }
            }
            return null;
        }

    }
}

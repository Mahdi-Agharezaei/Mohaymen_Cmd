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

        private bool IsLogin = false;
        private string CurrentUser = string.Empty;

        public void Register(string username, string password)
        {
            try
            {
                if (!Validators.IsValid_Username(username))
                {
                    Console.WriteLine("Username is not valid!");
                }
                else if (!Validators.IsValid_Password(password))
                {
                    Console.WriteLine("Password is not valid!");
                }
                else if (dbcontext.Users.Any(u => u.UserName == username))
                {
                    Console.WriteLine("Username already exists! Try a different one.");
                }
                else
                {
                    dbcontext.Users.Add(new User { UserName = username, Password = password, Status = true, CreationDate = DateTime.Now, ModificationDate = DateTime.Now });
                    dbcontext.SaveChanges();
                    Console.WriteLine("Registration successful. You can now log in.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Login(string username, string password)
        {
            try
            {
                var user = dbcontext.Users.SingleOrDefault(u => u.UserName == username && u.Password == password);
                if (user is not null)
                {
                    IsLogin = true;
                    CurrentUser = user.UserName;
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Logout();
                    Console.WriteLine("Username or password is incorrect!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Change(string status)
        {
            if (IsLogin && !string.IsNullOrEmpty(CurrentUser))
            {
                try
                {
                    var user = dbcontext.Users.SingleOrDefault(u => u.UserName == CurrentUser);
                    if (user is not null)
                    {
                        if (status.ToLower() == "available")
                        {
                            user.Status = true;
                        }
                        else if (status.ToLower() == "notavailable")
                        {
                            user.Status = false;
                        }

                        dbcontext.SaveChanges();
                    }
                    else
                    {
                        Logout();
                        Console.WriteLine("You must login!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Logout();
                Console.WriteLine("You must login!");
            }
        }

        public void Search(string username)
        {
            try
            {
                var user = dbcontext.Users.SingleOrDefault(u => u.UserName == username);

                if (user is not null)
                {
                    if (user.Status)
                    {
                        Console.WriteLine(user.UserName + " | status: available");
                    }
                    else if (!user.Status)
                    {
                        Console.WriteLine(user.UserName + " | status: not available");
                    }
                }
                else
                {
                    Console.WriteLine("Username is not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ChangePassword(string Old, string New)
        {
            if (IsLogin && !string.IsNullOrEmpty(CurrentUser))
            {
                try
                {
                    var user = dbcontext.Users.SingleOrDefault(u => u.UserName == CurrentUser);
                    if (user is not null)
                    {
                        if (!Validators.IsValid_Password(New))
                        {
                            Console.WriteLine("Password is not valid!");
                        }

                        user.Password = New;
                        dbcontext.SaveChanges();
                    }
                    else
                    {
                        Logout();
                        Console.WriteLine("You must login!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Logout();
                Console.WriteLine("You must login!");
            }
        }

        public void Logout()
        {
            IsLogin = false;
            CurrentUser = string.Empty;
            Console.WriteLine("You are logged out!");
        }

        public void Clear()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Mohaymen Cmd App :)");
        }
    }
}

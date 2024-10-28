namespace Mohaymen_Cmd.Controller
{
    internal class Validators
    {
        public static bool IsValid_Username(string username)
        {
            if (username.Length < 5 || username.Length > 63)
            {
                return false;
            }

            return true;
        }

        public static bool IsValid_Password(string password)
        {
            if (password.Length < 10 || password.Length > 63)
            {
                return false;
            }

            return true;
        }
    }
}

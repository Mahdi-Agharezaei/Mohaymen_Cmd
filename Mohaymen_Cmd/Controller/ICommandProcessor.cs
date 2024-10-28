namespace Mohaymen_Cmd.Controller
{
    internal interface ICommandProcessor
    {
        void ProcessCommand(string Instruction, string[] CommandParts);
    }
}

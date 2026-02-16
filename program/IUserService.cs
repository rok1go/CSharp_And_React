public interface ILogic
{
    
    public bool IIsItInt(string UserInput, out int CheckedUserInput);
    public User LoggingUserData();

    public bool ILogin(string username, string password, bool NextStep);
    public bool IRegister(string username, string password, bool NextStep);
}
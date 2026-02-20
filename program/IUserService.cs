public interface ILogic
{
    public bool IIsItInt(string UserInput, out int CheckedUserInput);
    public User LoggingUserData();

    public LoginResult Login(string username, string password);
    public RegisterResult Register(string username, string password);
}
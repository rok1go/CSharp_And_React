public enum LoginResult
{
    Success,
    InvalidUsername,
    InvalidPassword,
}
public enum RegisterResult
{
    Success,
    UsernameTaken,
    IncorrectUsername,
    IncorrectPassword,
}
public class Logic : ILogic
{   
    User UserVessel = null;
    int TotalId = 0;
    List<User> Users = new List<User>();
//Publics   
    public bool IIsItInt(string UserInput, out int CheckedUserInput)
    {
        return IsItInt(UserInput, out CheckedUserInput);
    }
    public User LoggingUserData()
    {
        return UserVessel;
    }
    public LoginResult Login(string username, string password)
    {   
        UserVessel = null;
        
        if(!IsUsernameIn(username)) return LoginResult.InvalidUsername;
        if(!PasswordCheck(password)) return LoginResult.InvalidPassword;

        return LoginResult.Success;
        
    }
    public RegisterResult Register(string username, string password)
    {
        if(IsUsernameTaken(username)) return RegisterResult.UsernameTaken;
        if(!IsUsernameValid(username)) return RegisterResult.IncorrectUsername;
        if(!IsPasswordValid(password)) return RegisterResult.IncorrectPassword;

        CreateUser(username, password);
        return RegisterResult.Success;
    }
    
//Privates
    private bool IsItInt(string UserInput, out int CheckedUserInput)
    {
        return int.TryParse(UserInput, out CheckedUserInput);
    }
    // Login
    private bool IsUsernameIn(string username)
    {   
        foreach(User u in Users)
        {   
            if (u.username == username)
            {   
                UserVessel = u;
                return true;
            }
        }
        return false;
    }

    private bool PasswordCheck(string password)
    {   
        if(UserVessel == null) return false;
        if (string.IsNullOrWhiteSpace(password)) return false;

        return UserVessel.password == password;
    }

    //Register
    private bool IsUsernameTaken(string username)
    {   
        foreach(User u in Users)
        {
            if(u.username == username)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsUsernameValid(string username)
    {
        if (string.IsNullOrWhiteSpace(username)) return false;
        if(username.Length >= 4 && username.Length <= 12) return true;

        return false;
    }

    private bool IsPasswordValid(string password)
    {   
        if (string.IsNullOrWhiteSpace(password)) return false;
        if (password.Length >= 4 && password.Length <= 12) return true;

        return false;
    }

    private void CreateUser(string username, string password)
    {
        Users.Add(new User
        {
            id = ++TotalId,
            username = username,
            password = password,
        });
    }

}
public class Logic : ILogic
{   
    User LoggingUser = new User();
    int TotalId = 0;
    List<User> Users = new List<User>();
//Publics
    public bool IIsItInt(string UserInput, out int CheckedUserInput)
    {
        return IsItInt(UserInput, out CheckedUserInput);
    }
    public User LoggingUserData()
    {
        return LoggingUser;
    }
    public bool ILogin(string username, string password, bool NextStep)
    {
        return Login(username, password, NextStep);
    }
    public bool IRegister(string username, string password, bool NextStep)
    {
        return Register(username, password, NextStep);
    }
    
//Privates
    private bool IsItInt(string UserInput, out int CheckedUserInput)
    {
        return int.TryParse(UserInput, out CheckedUserInput);
    }
    // Login
    private bool Login(string username, string password, bool NextStep)
    {
        User UserVessel = new User();
        bool UsernameExist = false;
        foreach (User u in Users)
        {
            if (u.username == username)
            {
                UsernameExist = true;
                UserVessel = u;
            }
        }
        if (UsernameExist)
        {
            if (NextStep)
            {
                if (UserVessel.password == password)
                {   
                    LoggingUser = UserVessel;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
    //Register
    private bool Register(string username, string password, bool NextStep)
    {   
        User UserVessel = new User();
        bool UsernameExist = false;

        foreach(User u in Users)
        {
            if (u.username == username)
            {
                UsernameExist = true;
            }
        }

        if (!UsernameExist)
        {
            if (username.Length >= 4 && username.Length <= 12)
            {   
                UserVessel.username = username;
                if (NextStep)
                {
                    if (password.Length >= 4 && password.Length <= 12)
                    {   
                        UserVessel.password = password;
                        TotalId += 1;
                        UserVessel.id = TotalId;
                        Users.Add(UserVessel);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
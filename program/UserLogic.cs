public class Logic : ILogic
{   
    public bool IIsItInt(string UserInput, out int CheckedUserInput)
    {
        return IsItInt(UserInput, out CheckedUserInput);
    }

    public bool IIsLoginGood(string UserInput, List<User> users)
    {
        return IsLoginGood(UserInput, users);
    }

    public bool IIsPasswordGood(string UserInput)
    {
        return IsPasswordGood(UserInput);
    }



    private bool IsItInt(string UserInput, out int CheckedUserInput)
    {
        return int.TryParse(UserInput, out CheckedUserInput);
    }

    private bool IsLoginGood(string UserInput, List<User> users)
    {   
        bool IsLoginExist = false;
        foreach(User u in users)
        {
            if (u.username == UserInput)
            {
                IsLoginExist = true;
            }
        }

        if (!IsLoginExist)
        {
            return UserInput.Length >= 4 && UserInput.Length <= 12;
        }
        else
        {
            return false;
        }
    }

    private bool IsPasswordGood(string UserInput)
    {
        return UserInput.Length >= 4 && UserInput.Length <= 12;
    }
}
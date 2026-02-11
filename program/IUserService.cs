public interface ILogic
{
    public bool IIsItInt(string UserInput, out int CheckedUserInput);

    public bool IIsLoginGood(string UserInput, List<User> users);

    public bool IIsPasswordGood(string UserInput);
}
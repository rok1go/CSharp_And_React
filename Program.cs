using System;
using System.Collections.Generic;

class User
{
    public int id;
    public string username;
    public string password;
}
class Program
{
    static void Main(string[] args)
    {
        List<User> users = new List<User>();
        int TotalId = 0;
        User LoginedUser = null;
        bool IsUserLogin = false;

        while (true)
        {   
            bool back = false;

            if (IsUserLogin)
            {
                Console.WriteLine($"Вы сейчас находитесь под логином {LoginedUser.username}");
            }
            else
            {
                Console.WriteLine("Вы не вошедший пользователь!");
            }

            Console.WriteLine("0 - выйти, 1 - зарегестрировать пользователя, 2 - логин, 3 - список пользователей, 4 - выйти из пользователя");
            string choice = Console.ReadLine();
            int CheckedChoice;

            bool decide = CheckingChoice(choice, out CheckedChoice);
            if (decide)
            {
                if (CheckedChoice == 0)
                {
                    break;
                }
                else if (CheckedChoice == 1)
                {   
                    bool UserCreated = false;
                    while (true)
                    {   
                        if (UserCreated)
                        {
                            break;
                        }

                        Console.WriteLine("Напишите новый логин пользователя! (от 4 до 12 символов)");
                        Console.WriteLine("0 - вернуться");
                        string NewUsername = Console.ReadLine();

                        if (NewUsername == "0")
                        {
                            break;
                        }
                        
                        bool HowLongUsername = NewUsername.Length >= 4 && NewUsername.Length <= 12;


                        if (HowLongUsername)
                        {
                            int existence = 0;
                            foreach (User u in users)
                            {
                                if (u.username == NewUsername)
                                {
                                    existence += 1;
                                }
                            }

                            if (existence >= 1)
                            {
                                Console.WriteLine("Этот логин уже занят!");
                            }
                            if (existence == 0)
                            {                                 
                                User u = new User();
                                u.username = NewUsername;
                                Console.WriteLine($"Вы успешно создали логин {u.username}");

                                while(true){
                                    Console.WriteLine("Теперь вы должны придумать пароль (от 4 до 12 символов)");
                                    Console.WriteLine("0 - вернуться");

                                    string NewPassword = Console.ReadLine();

                                    if (NewPassword == "0")
                                    {
                                        break;
                                    }
                                    bool HowLongPassword = NewPassword.Length >= 4 && NewPassword.Length <= 12;

                                    if (HowLongPassword)
                                    {   
                                        u.password = NewPassword;
                                        Console.WriteLine($"Вы успешно создали пароль {u.password}, логин {u.username}");
                                        TotalId += 1;
                                        u.id = TotalId;
                                        Console.WriteLine($"Айди пользователя {u.username} - {u.id}");
                                        users.Add(u);
                                        UserCreated = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ваш пароль не подходит криетриям!");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ваш логин не подходит критериям!");
                        }
                        
                    }
                }

                else if (CheckedChoice == 3)
                {
                    foreach (User s in users)
                    {   
                        Console.WriteLine("---------------");
                        Console.WriteLine(s.username);
                        Console.WriteLine(s.password);
                        Console.WriteLine(s.id);
                        Console.WriteLine("---------------");
                    }
                }

                else if (CheckedChoice == 2)
                {
                    while (true)
                    {   
                        if (back)
                        {
                            break;
                        }
                        if (IsUserLogin)
                        {   
                            Console.WriteLine("Вы уже вошли в аккаунт!");
                            break;
                        }

                        Console.WriteLine("Введите ваш логин!");
                        Console.WriteLine("0 - вернуться");
                        string Login = Console.ReadLine();
                        bool LoginCheck = false;
                        User FoundUser = null;

                        if (Login == "0")
                        {
                            break;    
                        }

                        foreach (User u in users)
                        {
                            if (u.username == Login)
                            {
                                LoginCheck = true;
                                FoundUser = u;;
                            }
                        }
                        if (LoginCheck)
                        {   
                            while (true)
                            {
                                Console.WriteLine("Введите пароль логина!");
                                Console.WriteLine("0 - вернуться");
                                string LoginPassword = Console.ReadLine();
                                bool PasswordCheck = false;
                                
                                if (LoginPassword == "0")
                                {
                                    break;
                                }

                                if (FoundUser.password == LoginPassword)
                                {
                                    PasswordCheck = true;
                                }

                                if (PasswordCheck)
                                {
                                    Console.WriteLine("Вы успешно вошли в аккаунт!");
                                    LoginedUser = FoundUser;
                                    IsUserLogin = true;
                                    back = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Этот пароль не правильный");
                                }


                            }
                        }
                        else
                        {
                            Console.WriteLine("Этого логина не существует!");
                        }
                    }
                }

                else if(CheckedChoice == 4)
                {
                    if (IsUserLogin)
                    {
                        IsUserLogin = false;
                        LoginedUser = null;
                        Console.WriteLine("Вы успешно вышли из пользователя!");
                    }
                    else
                    {
                        Console.WriteLine("Вы и так не находитесь под каким либо пользователем!");
                    }    
                }

                else
                {
                    Console.WriteLine("Этой команды нету в списке!");
                }

            }
            else
            {
                Console.WriteLine("Пожалуйста введите число!");
            }
        }
    }

    static bool CheckingChoice(string choice, out int CheckedChoice)
    {
        return int.TryParse(choice, out CheckedChoice);
    }
}
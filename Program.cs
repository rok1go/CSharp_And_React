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

        while (true)
        {   

            Console.WriteLine("0 - выйти, 1 - добавить пользователя, 2 - вывести список всех пользователей, 3 - залогинеться");
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
                                        Console.WriteLine($"Вы успешно создали пароль {u.password}, для логина {u.username}");
                                        TotalId += 1;
                                        u.id = TotalId;
                                        Console.WriteLine($"Айди нового пользователя {u.id}");
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

                else if (CheckedChoice == 2)
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
                else if (CheckedChoice == 3)
                {   
                    while(true)
                    {
                        Console.WriteLine("Пожалуйста введите логин");
                        Console.WriteLine("0 - вернуться");
                        string login = Console.ReadLine();

                        if (login == "0")
                        {
                            break;
                        }
                        int existence = 0;
                        foreach (User s in users)
                        {   
                            if(s.username == login)
                            {
                                existence += 1;
                            }
                        }

                        if (existence == 0)
                        {

                        }
                        else
                        {
                            Console.WriteLine("Этого логина не существует!");
                        }
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
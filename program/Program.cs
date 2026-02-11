using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        List<User> Users = new List<User>();
        User LoginedUser = null;
        
        ILogic logic = new Logic();

        bool IsLoggedIn = false;
        bool Checking;

        int TotalId = 0;
        int CheckedUserInputInt;
        string CheckedUserInputString;
        string UserInput;
     
        while(true){
                
            if (!IsLoggedIn)
            {

                bool back = false;
                
                Console.WriteLine("Добро пожаловать, в программу.");
                Console.WriteLine("1 - войти");
                Console.WriteLine("2 - зарегестрироваться");
                Console.WriteLine("0 - выйти");
                Console.WriteLine("");

                UserInput = Console.ReadLine();
                Checking = logic.IIsItInt(UserInput, out CheckedUserInputInt);
                
                if (Checking)
                {
                    if (CheckedUserInputInt == 0)
                    {
                        break;
                    }

                    else if (CheckedUserInputInt == 1)
                    {
                        while(true)
                        {   

                            if (back)
                            {
                                break;
                            }

                            User LoggingUser = new User();

                            Console.WriteLine("Введите свой логин!");
                            Console.WriteLine("0 - выйти");
                            Console.WriteLine("");

                            UserInput = Console.ReadLine();

                            if (UserInput == "0")
                            {
                                break;
                            }

                            Checking = false;
                            foreach (User u in Users)
                            {
                                if (u.username == UserInput)
                                {
                                    Checking = true;
                                    LoggingUser = u;
                                }
                            }

                            if (Checking)
                            {   
                                while(true)
                                {
                                    Console.WriteLine("Введите свой пароль!");
                                    Console.WriteLine("0 - вернуться");
                                    Console.WriteLine("");

                                    UserInput = Console.ReadLine();

                                    if (UserInput == "0")
                                    {
                                        break;
                                    }

                                    if (UserInput == LoggingUser.password)
                                    {
                                        LoginedUser = LoggingUser;
                                        IsLoggedIn = true;
                                        back = true;

                                        Console.WriteLine("Вы успешно вошли в пользователя!");
                                        Console.WriteLine("");
                                        break;
                                    }

                                    else
                                    {
                                        Console.WriteLine("Ваш пароль не верный!");
                                        Console.WriteLine("");
                                    }
                                }
                                
                            }

                            else
                            {
                                Console.WriteLine("Такого логина не существует в системе!");
                                Console.WriteLine("");
                            }

                        }
                    }

                    else if (CheckedUserInputInt == 2)
                    {   
                        while(true)
                        {

                            if (back)
                            {
                                break;
                            }

                            User NewUser = new User();
                            Console.WriteLine("Чтобы зарегестрироваться введите новый логин! (от 4 до 12 символов)");
                            Console.WriteLine("0 - вернуться");
                            Console.WriteLine("");

                            UserInput = Console.ReadLine();
                            Checking = logic.IIsLoginGood(UserInput, Users);

                            if (UserInput == "0")
                            {
                                break;
                            }

                            if (Checking)
                            {   
                                while(true)
                                {
                                    NewUser.username = UserInput;

                                    Console.WriteLine("Ваш логин прошёл по критериям!");
                                    Console.WriteLine("Теперь придумайте новый пароль! (от 4 до 12 символов)");
                                    Console.WriteLine("0 - вернуться");
                                    Console.WriteLine("");

                                    UserInput = Console.ReadLine();
                                    Checking = logic.IIsPasswordGood(UserInput);

                                    if (UserInput == "0")
                                    {
                                        break;
                                    }

                                    else if (Checking)
                                    {
                                        NewUser.password = UserInput;
                                        TotalId += 1;
                                        NewUser.id = TotalId;
                                        Users.Add(NewUser);
                                        back = true;

                                        Console.WriteLine("Вы успешно создали новый аккаунт! ");
                                        Console.WriteLine("");
                                        break;
                                    }

                                    else
                                    {
                                        Console.WriteLine("Ваш пароль не подходит по критериям!");
                                        Console.WriteLine("");
                                    }
                                }
                            }

                            else
                            {
                                Console.WriteLine("Ваш логин не подходит критериям или уже существует в системе!");
                                Console.WriteLine("");
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("Этой команды нету в списке!");
                        Console.WriteLine("");
                    }
                }

                else
                {
                    Console.WriteLine("Это не число!");
                    Console.WriteLine("");
                }
            }

            else
            {
                Console.WriteLine($"Здравствуйте {LoginedUser.username}");
                return;
            }       
        }
    }
}
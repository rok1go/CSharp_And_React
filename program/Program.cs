using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        User LoginedUser = null;
        ILogic logic = new Logic();

        bool IsLoggedIn = false;
        bool NextStep;

        int CheckedUserInputInt;
        string UserInput;
        string username = null;
        string password = null;
     
        while(true){
                
            if (!IsLoggedIn)
            {
                bool Checking = false;
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
                            NextStep = false;

                            if (back)
                            {
                                break;
                            }

                            Console.WriteLine("Введите свой логин!");
                            Console.WriteLine("0 - выйти");
                            Console.WriteLine("");

                            username = Console.ReadLine();

                            if (username == "0")
                            {
                                break;
                            }

                            Checking = logic.ILogin(username, password, NextStep);

                            if (Checking)
                            {   
                                NextStep = true;
                                while(true)
                                {   
                                    Console.WriteLine("Введите свой пароль!");
                                    Console.WriteLine("0 - вернуться");
                                    Console.WriteLine("");

                                    password = Console.ReadLine();

                                    if (password == "0")
                                    {
                                        break;
                                    }

                                    Checking = logic.ILogin(username, password, NextStep);

                                    if (Checking)
                                    {   
                                        LoginedUser = logic.LoggingUserData();
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
                            NextStep = false;
                            if (back)
                            {
                                break;
                            }

                            Console.WriteLine("Чтобы зарегестрироваться введите новый логин! (от 4 до 12 символов)");
                            Console.WriteLine("0 - вернуться");
                            Console.WriteLine("");

                            username = Console.ReadLine();
                            Checking = logic.IRegister(username, password, NextStep);

                            if (username == "0")
                            {
                                break;
                            }

                            if (Checking)
                            {   
                                NextStep = true;
                                Console.WriteLine("Ваш логин прошёл по критериям!");
                                while(true)
                                {

                                    Console.WriteLine("Теперь придумайте новый пароль! (от 4 до 12 символов)");
                                    Console.WriteLine("0 - вернуться");
                                    Console.WriteLine("");

                                    password = Console.ReadLine();
                                    Checking = logic.IRegister(username, password, NextStep);

                                    if (password == "0")
                                    {
                                        break;
                                    }

                                    else if (Checking)
                                    {
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
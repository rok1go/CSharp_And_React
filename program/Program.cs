using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        User LoginedUser = null;
        ILogic logic = new Logic();

        bool IsLoggedIn = false;

        int CheckedUserInputInt;
        string UserInput;
        string username;
        string password;
     
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
                    if (CheckedUserInputInt == 0) break;

                    else if (CheckedUserInputInt == 1)
                    {
                        while(true)
                        {   

                            if (back) break;

                            Console.WriteLine("Введите свой логин!");
                            Console.WriteLine("0 - выйти");
                            Console.WriteLine("");

                            username = Console.ReadLine();

                            if (username == "0") break;
                        
                            while(true)
                            {   
                                Console.WriteLine("Введите свой пароль!");
                                Console.WriteLine("0 - вернуться");
                                Console.WriteLine("");

                                password = Console.ReadLine();
                                Console.WriteLine("");

                                if (password == "0") break;
                                
                                LoginResult result = logic.Login(username, password);

                                if (result == LoginResult.InvalidUsername)
                                {
                                    Console.WriteLine("Неверный логин!");
                                    Console.WriteLine("");
                                    break;
                                }
                                if (result == LoginResult.InvalidPassword)
                                {
                                    Console.WriteLine($"Неверный пароль для пользователя {username}!");
                                    Console.WriteLine("");
                                    continue;
                                }
                                if (result == LoginResult.Success)
                                {
                                    Console.WriteLine("Вы успешно вошли в пользователя!");
                                    Console.WriteLine("");

                                    LoginedUser = logic.LoggingUserData();
                                    IsLoggedIn = true;
                                    back = true;
                                    break;
                                }                   
                            }
                        }
                    }

                    else if (CheckedUserInputInt == 2)
                    {   
                        while(true)
                        {
                
                            if (back) break;

                            Console.WriteLine("Чтобы зарегестрироваться введите новый логин! (от 4 до 12 символов)");
                            Console.WriteLine("0 - вернуться");
                            Console.WriteLine("");

                            username = Console.ReadLine();

                            if (username == "0") break;

                            while(true)
                            {
                                Console.WriteLine("Теперь придумайте новый пароль! (от 4 до 12 символов)");
                                Console.WriteLine("0 - вернуться");
                                Console.WriteLine("");

                                password = Console.ReadLine();
                                Console.WriteLine("");

                                if (password == "0") break;

                                RegisterResult result = logic.Register(username, password);
                                
                                if (result == RegisterResult.UsernameTaken)
                                {
                                    Console.WriteLine("Это имя уже занято другим пользователем!");
                                    Console.WriteLine("");
                                    break;
                                }
                                if(result == RegisterResult.IncorrectUsername)
                                {
                                    Console.WriteLine("Это имя не подходит критериям!");
                                    Console.WriteLine("");
                                    break;
                                }
                                if(result == RegisterResult.IncorrectPassword)
                                {
                                    Console.WriteLine($"Этот пароль для {username} не подходит критериям!");
                                    Console.WriteLine("");
                                    continue;
                                }
                                if(result == RegisterResult.Success)
                                {
                                    Console.WriteLine("Вы успешно создали пользователя!");
                                    Console.WriteLine("");

                                    back = true;
                                    break;
                                }
                            }
                        }
                    }
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
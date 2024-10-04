using System;
using System.Security.Cryptography.X509Certificates;

namespace InlamningBankkonto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            User user = new User("Felicia", 1111);

            bool userIsLoggedIn = false;

            Console.WriteLine("Välkommen till Felicias Bank!");

            while (!userIsLoggedIn)
            {

                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Logga in");
                Console.WriteLine("2. Avsluta");


                string userOptionChoosed = Console.ReadLine()!;

                if (userOptionChoosed == "1")
                {
                    Console.Write("Ange ditt namn: ");
                    string userTypeInName = Console.ReadLine()!;


                    Console.Write("Skriv in din PIN-kod: ");
                    int userTypeInPinCode = Convert.ToInt32(Console.ReadLine());

                    if (user.UserPinCode == userTypeInPinCode && user.UserName == userTypeInName)
                {
                        Console.WriteLine($"Välkommen {user.UserName}! Du är inloggad");
                        userIsLoggedIn = true;
                        
                        Transaktioner account = new Transaktioner(user);
                        bool runing = true;

                    while (runing)
                    {
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("Välj vad du vill göra");
                        Console.WriteLine("1. Visa saldo");
                        Console.WriteLine("2. Sätta in pengar");
                        Console.WriteLine("3. Ta ut pengar");
                        Console.WriteLine("4. Föra över pengar");
                        Console.WriteLine("5. Logga ut");


                        string userOptionChoosedWhenLoggedIn = Console.ReadLine()!;

                        switch (userOptionChoosedWhenLoggedIn)
                        {
                            case "1":
                                account.CheckAccountBalance();
                                break;
                            case "2":
                                account.Deposit();
                                break;
                            case "3":
                                account.Withdraw();
                                break;
                            case "4":
                                account.TransferMoney();
                                break;
                            case "5":
                                Console.WriteLine("Loggar ut.... Hejdå!");
                                userIsLoggedIn = false;
                                runing = false;
                                break;
                        }
                    }
                }
                else
                {
                        Console.WriteLine("FEL PIN-KOD! Försök igen");
                        
                }
                }
                else if (userOptionChoosed == "2")
                {
                    Console.WriteLine("Avslutar...");
                    break;
                }
            }
        }
    }
}

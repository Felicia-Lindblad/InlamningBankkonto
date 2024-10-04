

namespace InlamningBankkonto
{
    internal class Transaktioner
    {
        private User user;

        public Transaktioner(User user)
        {
            this.user = user;
        }

        public void CheckAccountBalance()
        {
            Bankkonto account = SelectAccount();

            if (account != null)
            {
                Console.WriteLine($"Saldot {account.KontoTyp} är {account.Saldo}kr");
            } else
            {
                Console.WriteLine("Inget konto är valt");
            }
        }

        public void Deposit()
        {
            Bankkonto account = SelectAccount();
            if (account == null) return;

            Console.WriteLine($"Skriv den summan du vill sätta in på {account.KontoTyp}");
            int amount = Convert.ToInt32(Console.ReadLine());

            if (account.Deposit(amount))
            {
                Console.WriteLine($"{amount}kr har satts in på ditt konto. Nytt saldo för {account.KontoTyp} är {account.Saldo}kr");
            }
        }

        public void Withdraw()
        {
            Bankkonto account = SelectAccount();
            if (account == null) return ;

            Console.WriteLine($"Skriv den summan du vill ta ut från {account.KontoTyp}");
            int amount = Convert.ToInt32(Console.ReadLine());

            if (account.Withdraw(amount))
            {
                Console.WriteLine($"{amount}kr har tagits ut från kontot. Nytt saldo för {account.KontoTyp} är {account.Saldo}kr");
            }
        }

        public void TransferMoney()
        {
            Console.WriteLine("Vilket konto ska pengarna skickas ifrån?");
            Console.Write("Skriv in kontonummer: ");

            Bankkonto fromAccount = SelcectAccountByKontoNummer();
            if (fromAccount == null) return;

            Console.WriteLine("Vilket konto ska ta emot pengarna?");
            Console.Write("Skriv in kontonummer: ");

            Bankkonto toAccount = SelcectAccountByKontoNummer();
            if (toAccount == null) return;

            Console.WriteLine("Skriv den summan du vill föra över");
            int amount = Convert.ToInt32(Console.ReadLine());

            if (amount <= 0)
            {
                Console.WriteLine("Summan måste vara högre än 0");
            }
            if (fromAccount.Withdraw(amount))
            {
                if (toAccount.Deposit(amount))
                {
                    Console.WriteLine("Överföringen lyckades!");
                    Console.WriteLine($"Nytt saldo för {fromAccount.KontoTyp} är {fromAccount.Saldo}kr");
                    Console.WriteLine($"Nytt saldo för {toAccount.KontoTyp} är {toAccount.Saldo}kr");
                }
            }
        }

        private Bankkonto SelectAccount()
        {
            Console.WriteLine("Välj ett konto");
            Console.WriteLine("1. Personkonto");
            Console.WriteLine("2. Sparkonto");
            Console.WriteLine("3. Investeringskonto");

            string userAccountChoice = Console.ReadLine()!;

            switch (userAccountChoice)
            {
                case "1":
                    return user.Personkonto;
                case "2":
                    return user.Sparkonto;
                case "3":
                    return user.Investeringskonto;
                default:
                    Console.WriteLine("Invalin choice");
                    return null!;
            }
        }

        public Bankkonto SelcectAccountByKontoNummer()
        {
            int SelectedAccountNumberByUser = Convert.ToInt32(Console.ReadLine());

            if (user.Personkonto.Kontonummer == SelectedAccountNumberByUser)
            {
                return user.Personkonto;
            }
            if (user.Sparkonto.Kontonummer == SelectedAccountNumberByUser)
            {
                return user.Sparkonto;
            }
            if (user.Investeringskonto.Kontonummer == SelectedAccountNumberByUser)
            {
                return user.Investeringskonto;
            } else { return null!; }
        }
    }
}

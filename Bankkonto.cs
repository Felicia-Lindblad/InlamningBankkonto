
using System;

namespace InlamningBankkonto
{
    public abstract class Bankkonto
    {
        public string KontoTyp { get; set; }
        public int Kontonummer { get; set; }
        public string UserNamn { get; set; }
        public int Saldo { get; set; }
        public string förstaTransaktionsHistorik { get; set; }
        public string sistaTransaktionsHistorik { get; set; }

        public Bankkonto(string kontoTyp, int kontonummer, string userName, int saldo)
        {
            KontoTyp = kontoTyp;
            Kontonummer = kontonummer;
            UserNamn = userName;
            Saldo = saldo;
        }

        public virtual bool Deposit(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Summan måste vara högre än 0");
                return false;
            }
            Saldo += amount;
            UppdateraTransaktionsHistoriken();
            return true;
        }

        public virtual bool Withdraw(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Summan måste vara större än 0");
                return false;
            }
            if (amount > Saldo)
            {
                Console.WriteLine("Du har inte tillräckligt med pengar");
                return false;
            }
            Saldo -= amount;
            UppdateraTransaktionsHistoriken();
            return true;
        }

        //Skapa metod som uppdaterar första och sista transaktionen och sätt in i deposit och withdraw
        public void UppdateraTransaktionsHistoriken()
        {
            förstaTransaktionsHistorik ??= DateTime.Now.ToString();
            sistaTransaktionsHistorik = DateTime.Now.ToString();
        }
    }
}

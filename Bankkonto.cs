

using System;

namespace InlamningBankkonto
{
    public abstract class Bankkonto
    {
        public string KontoTyp { get; set; }
        public int Kontonummer { get; set; }
        public string UserNamn { get; set; }
        public int Saldo { get; set; }

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
            return true;
        }
    }
}

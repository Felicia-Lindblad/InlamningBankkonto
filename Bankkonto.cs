

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

        public virtual bool Deposit(int saldo)
        {
            if (saldo <= 0)
            {
                Console.WriteLine("Summan måste vara högre än 0");
                return false;
            }
            Saldo += saldo;
            return true;
        }

        public virtual bool Withdraw(int saldo)
        {
            if (saldo <= 0)
            {
                Console.WriteLine("Summan måste vara större än 0");
                return false;
            }
            if (saldo > Saldo)
            {
                Console.WriteLine("Du har inte tillräckligt med pengar");
                return false;
            }
            Saldo -= saldo;
            return true;
        }
    }
}

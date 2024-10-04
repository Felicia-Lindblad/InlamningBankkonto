

namespace InlamningBankkonto
{
    public class Investeringskonto : Bankkonto
    {
        public Investeringskonto(string kontotyp, int kontonummer, string userName, int saldo) 
            : base(kontotyp, kontonummer, userName, saldo) { }
    }
}

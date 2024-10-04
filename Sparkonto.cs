

namespace InlamningBankkonto
{
    public class Sparkonto : Bankkonto
    {
        public Sparkonto(string kontotyp, int kontonummer, string userName, int saldo)
        : base(kontotyp, kontonummer, userName, saldo) { }
    }
}

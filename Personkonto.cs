

namespace InlamningBankkonto
{
    public class Personkonto : Bankkonto
    {
        public Personkonto(string kontotyp, int kontonummer, string userName, int saldo)
        : base(kontotyp, kontonummer, userName, saldo) { }
    }
}

namespace InlamningBankkonto
{
    public class User
    {
        public int UserPinCode {  get; set; }
        public string UserName { get; set; }
        public Personkonto Personkonto { get; set; }
        public Sparkonto Sparkonto { get; set; }
        public Investeringskonto Investeringskonto { get; set; }

        public User (string name, int userPinCode)
        {
            UserPinCode = userPinCode; 
            UserName = name;
            
            Personkonto = new Personkonto("Personkonto", 11111, "Felicia", 5000);
            Sparkonto = new Sparkonto("Sparkonto", 22222, "Felicia", 15000);
            Investeringskonto = new Investeringskonto("Investeringskonto", 33333, "Felicia", 10000);
        }

    }
}

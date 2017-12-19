namespace Dominio
{
    public class Info
    {
        int id;
        string primeiroNome;
        string segundoNome;

        public int Id { get => id; set => id = value; }
        public string PrimeiroNome { get => primeiroNome; set => primeiroNome = value; }
        public string SegundoNome { get => segundoNome; set => segundoNome = value; }
    }
}

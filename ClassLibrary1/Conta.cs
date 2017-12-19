namespace Dominio
{
    public class Conta : UsuarioSenha
    {
        public override string ToString()
        {
            return PrimeiroNome + " " + SegundoNome;
        }
    }
}

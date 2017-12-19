namespace Dominio
{
    public class UsuarioSenha : Info
    {
        string passWord;
        string userName;

        public string PassWord { get => passWord; set => passWord = value; }
        public string UserName { get => userName; set => userName = value; }
    }
}

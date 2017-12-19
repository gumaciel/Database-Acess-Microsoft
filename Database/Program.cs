using System;
using Dominio;
using Sessao;

namespace Database
{
    class Program
    {
        static void Main(string[] args)
        {
            CIDA c = new CIDA();
            Principal();
            void Principal()
            {
                Console.Clear();
                Console.WriteLine("1 - Consulta (Lista as contas registradas no banco de dados)");
                Console.WriteLine("2 - Insere (Faz cadastro de conta)");
                Console.WriteLine("3 - Deleta (Deleta a conta)");
                Console.WriteLine("4 - Altera (Altera a senha da conta)");
                Console.WriteLine("5 - Login (Faz o login para usar a calculadora)");
                Console.WriteLine("6 - Sair (Fecha o programa)");
                Console.Write("\nO que você deseja fazer? ");
                ConsoleKeyInfo x = Console.ReadKey();

                switch (x.KeyChar)
                {
                    case '1':
                        Consulta();
                        break;
                    case '2':
                        Insere();
                        break;
                    case '3':
                        Deleta();
                        break;
                    case '4':
                        Altera();
                        break;
                    case '5':
                        Login();
                        break;
                    case '6':
                        Sair();
                        break;
                    default:
                        Principal();
                        break;
                }
            }

            void Consulta()
            {
                Console.Clear();
                c.CConsultar();
                Console.ReadKey(); Principal();
            }
            void Insere()
            {
                Console.Clear();
                Conta acc = new Conta();

                Console.Write("Digite seu primeiro nome: ");
                acc.PrimeiroNome = Console.ReadLine();
                Console.Write("Digite seu segundo nome: ");
                acc.SegundoNome = Console.ReadLine();
                Console.Write("Digite seu nome de usuario: ");
                acc.UserName = Console.ReadLine();
                Console.Write("Digite sua senha com no minimo 4 caracteres: ");
                acc.PassWord = Console.ReadLine();

                if (acc.PrimeiroNome != "" && acc.SegundoNome != "" && acc.UserName != "" && acc.PassWord != "" && acc.PassWord.Length >= 4)
                    if (c.CheckUserName(acc))
                        Console.Write("\nUsuario ja existe, tente novamente. ");
                    else
                        c.CInserir(acc);
                else
                    Console.Write("\nOs campos não podem ficar vazios e a senha tem que ser maior que 4 caracteres! ");

                Console.ReadKey(); Principal();

            }

            void Deleta()
            {
                Console.Clear();
                Conta acc = new Conta();
                Console.Write("Digite o nome da conta que quer deletar: ");
                acc.UserName = Console.ReadLine();
                if (c.CheckUserName(acc))
                    c.CDeletar(acc);
                else
                    Console.Write("\nUsuario não existe, tente novamente. ");

                Console.ReadKey(); Principal();
            }

            void Altera()
            {
                Console.Clear();
                Conta acc = new Conta();

                Console.Write("Digite o nome da conta que quer alterar a senha: ");
                acc.UserName = Console.ReadLine();
                if (c.CheckUserName(acc))
                {
                    Console.Write("Você realmente quer Alterar?\n1 - Sim, 2 - Não: ");
                    ConsoleKeyInfo x = Console.ReadKey();
                    switch (x.KeyChar)
                    {
                        case '1':
                            alterar();
                            break;
                    }
                    void alterar()
                    {
                        string senha, novasenha;
                        Console.Write("\n\nDigite a nova senha que você quer inserir com no minimo 4 caracteres: ");
                        senha = Console.ReadLine();
                        if (senha.Length >= 4)
                        {
                            Console.Write("Digite a senha novamente para verificação: ");
                            novasenha = Console.ReadLine();
                            if (senha == novasenha)
                            {
                                acc.PassWord = novasenha;
                                c.CAlterar(acc);
                                Console.Write("Senha alterada com sucesso! ");
                            }
                            else
                                Console.Write("As senhas não correspondem. ");
                        }
                        else
                            Console.Write("A senha tem que ser acima de 4 caracteres! ");
                    }
                }
                else
                    Console.Write("A conta não existe, tente novamente! ");
                Console.ReadKey(); Principal();
            }
            void Login()
            {
                Console.Clear();
                Conta acc = new Conta();

                Console.Write("Usuario: ");
                acc.UserName = Console.ReadLine();
                Console.Write("Senha: ");
                acc.PassWord = Console.ReadLine();

                if (c.CheckUserName(acc))
                {
                    if (c.CheckPassWord(acc))
                    {
                        if (c.CheckAccount())
                        {
                            c.Nomes();
                            new Calculadora();
                        }
                    }
                    else
                        Console.WriteLine("\nSenha incorreta. ");
                }
                else
                    Console.Write("O nome de usuario não existe, tente novamente. ");
                Console.ReadKey(); Principal();
            }

            void Sair() { Console.WriteLine("\n"); }
        }
    }
}

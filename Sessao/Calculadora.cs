using System;

namespace Sessao
{
    public class Calculadora
    {
        public Calculadora()
        {
            Principal();
            void Principal()
            {
                Console.WriteLine("1 - Adição");
                Console.WriteLine("2 - Subtração");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão");
                Console.WriteLine("5 - Sair");
                Console.Write("\nQual operação você deseja fazer? ");

                ConsoleKeyInfo x = Console.ReadKey();

                switch (x.KeyChar)
                {
                    case '1':
                        Adicao();
                        break;
                    case '2':
                        Subtracao();
                        break;
                    case '3':
                        Multiplicacao();
                        break;
                    case '4':
                        Divisao();
                        break;
                    case '5':
                        Sair();
                        break;
                    default:
                        Principal();
                        break;
                }
            }
            void Adicao()
            {
                Console.Clear();
                Console.Write("Quantos numeros você quer adicionar? ");
                int nums = int.Parse(Console.ReadLine());
                int arm = 0, num = 0;
                Console.Write("Digite os numeros que você quer adicionar: ");

                for (int i = 0; i < nums; i++)
                {
                    Console.WriteLine("+");
                    num = int.Parse(Console.ReadLine());
                    
                    arm = num + arm;
                }
                Console.Write("---\nResposta: " + arm);
                Console.ReadKey(); Console.Clear(); Principal();

            }

            void Subtracao()
            {
                Console.Clear();
                Console.Write("Quantos numeros você quer subtrair? ");
                int nums = int.Parse(Console.ReadLine());
                int arm = 0, num = 0;
                Console.Write("Digite os numeros que você quer subtrair: ");
                for (int i = 0; i < nums; i++)
                {
                    Console.WriteLine("-");
                    num = int.Parse(Console.ReadLine());
                    
                    arm = num - arm;
                }
                Console.Write("\nResposta: " + arm);
                Console.ReadKey(); Console.Clear(); Principal();
            }

            void Multiplicacao()
            {
                Console.Clear();
                Console.Write("Quantos numeros você quer multiplicar? ");
                int nums = int.Parse(Console.ReadLine());
                int arm = 1, num = 0;
                Console.Write("Digite os numeros que você quer multiplicar: ");
                for (int i = 0; i < nums; i++)
                {
                    Console.WriteLine("*");
                    num = int.Parse(Console.ReadLine());
                    
                    arm = num * arm;
                }
                Console.Write("\nResposta: " + arm);
                Console.ReadKey(); Console.Clear(); Principal();
            }

            void Divisao()
            {
                Console.Clear();
                Console.Write("Quantos numeros você quer dividir? ");
                int nums = int.Parse(Console.ReadLine());
                double arm = 1, num = 0;
                Console.Write("Digite os numeros que você quer dividir: ");
                for (int i = 0; i < nums; i++)
                {
                    Console.WriteLine("/");
                    num = double.Parse(Console.ReadLine());
                    
                    arm = num / arm;
                }
                Console.Write("\nResposta: " + arm);
                Console.ReadKey(); Console.Clear(); Principal();
            }
            void Sair() { Console.Write("\nPressione qualquer tecla para continuar... "); }
        }
    }
}

using System;
using System.Collections;
using Dominio;
using System.Data.OleDb;

namespace Sessao
{
    public class CIDA
    {
        OleDbConnection conexao;
        OleDbCommand comando;
        bool retorno;
        int idarm = 0, idpass = 0;
        public string primeironm, segundonm;

        public CIDA()
        {
            conexao = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\Database.mdb;Persist Security Info=False");
            comando = conexao.CreateCommand();
        }
        
        public void ExecuteNonQuery()
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.ExecuteNonQuery();
        }
        public bool CheckUserName(Conta acc)
        {
            ArrayList contaArray = new ArrayList();
            try
            {
                comando.CommandText = "SELECT * FROM Username";
                comando.CommandType = System.Data.CommandType.Text;
                conexao.Open();

                OleDbDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Conta p = new Conta();

                    p.Id = Convert.ToInt32(leitor["IDuser"]);
                    contaArray.Add(Convert.ToString(p.Id));
                    p.UserName = leitor["Usuario"].ToString();
                    contaArray.Add(Convert.ToString(p.UserName));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            } // fazer a leitura dos campos que estão no banco de dados

            for (int i = 0; i < contaArray.Count; i++)
            {
                if (Convert.ToString(contaArray[1]) == acc.UserName)
                {
                    idarm = Convert.ToInt32(contaArray[0]);
                    retorno = true;
                    break;
                }
                if (i % 2 == 1)
                {
                    if (Convert.ToString(contaArray[i]) == acc.UserName)
                    {
                        idarm = Convert.ToInt32(contaArray[i - 1]);
                        retorno = true;
                        break;
                    }
                }
                else
                    retorno = false;
            }
            return retorno;
        }
        public bool CheckPassWord(Conta acc)
        {
            ArrayList contaArray = new ArrayList();
            try
            {
                comando.CommandText = "SELECT * FROM Senha";
                comando.CommandType = System.Data.CommandType.Text;
                conexao.Open();

                OleDbDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Conta p = new Conta();

                    p.Id = Convert.ToInt32(leitor["IDpass"]);
                    contaArray.Add(Convert.ToString(p.Id));
                    p.PassWord = leitor["Senha"].ToString();
                    contaArray.Add(Convert.ToString(p.PassWord));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            } // fazer a leitura dos campos que estão no banco de dados

            for (int i = 0; i < contaArray.Count; i++)
            {
                if (Convert.ToString(contaArray[1]) == acc.PassWord)
                {
                    idpass = Convert.ToInt32(contaArray[0]);
                    retorno = true;
                    break;
                }
                if (i % 2 == 1)
                {
                    if (Convert.ToString(contaArray[i]) == acc.PassWord)
                    {
                        idpass = Convert.ToInt32(contaArray[i - 1]);
                        retorno = true;
                        break;
                    }
                }
                else
                    retorno = false;
            }
            return retorno;
        }
        public bool CheckAccount()
        {
            if (idarm == idpass)
                return true;
            else
                return false;
        }
        public void Nomes()
        {
            ArrayList contaArray = new ArrayList();
            try
            {
                comando.CommandText = "SELECT * FROM Account";
                comando.CommandType = System.Data.CommandType.Text;
                conexao.Open();

                OleDbDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Conta p = new Conta();

                    p.Id = Convert.ToInt32(leitor["IDacc"]);
                    contaArray.Add(Convert.ToString(p.Id));
                    p.PrimeiroNome = leitor["PrimeiroNome"].ToString();
                    contaArray.Add(Convert.ToString(p.PrimeiroNome));
                    p.SegundoNome = leitor["SegundoNome"].ToString();
                    contaArray.Add(Convert.ToString(p.SegundoNome));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            } // fazer a leitura dos campos que estão no banco de dados

            for (int i = 0; i < contaArray.Count; i += 3)
            {
                if (Convert.ToInt32(contaArray[i]) == idarm || Convert.ToInt32(contaArray[i]) == idpass)
                {
                    primeironm = Convert.ToString(contaArray[i+1]);
                    segundonm = Convert.ToString(contaArray[i+2]);
                    Console.Clear();
                    Console.WriteLine("Bem vindo, " + primeironm + " " + segundonm + "!\n");
                    break;
                }
            }
        }
        public void CConsultar()
        {
            ArrayList contaArray = new ArrayList();
            try
            {
                comando.CommandText = "SELECT * FROM Geral";
                comando.CommandType = System.Data.CommandType.Text;
                conexao.Open();

                OleDbDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Conta p = new Conta();
                    p.Id = Convert.ToInt32(leitor["IDgeral"]);
                    contaArray.Add("ID = " + Convert.ToString(p.Id));
                    p.PrimeiroNome = leitor["PrimeiroNome"].ToString();
                    contaArray.Add("Primeiro Nome = " + Convert.ToString(p.PrimeiroNome));
                    p.SegundoNome = leitor["SegundoNome"].ToString();
                    contaArray.Add("Segundo Nome = " + Convert.ToString(p.SegundoNome));
                    p.UserName = leitor["Usuario"].ToString();
                    contaArray.Add("Usuario = " + Convert.ToString(p.UserName));
                    p.PassWord = leitor["Senha"].ToString();
                    contaArray.Add("Senha = " + Convert.ToString(p.PassWord) + "\n");
                }
                foreach (string word in contaArray)
                {
                    Console.WriteLine(word);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }
        public void CInserir (Conta acc)
        {
             
            try
            {
                conexao.Open();
                comando.CommandText = "INSERT INTO Account (PrimeiroNome, SegundoNome) VALUES('" + acc.PrimeiroNome + "', '" + acc.SegundoNome + "')";
                ExecuteNonQuery();
                comando.CommandText = "INSERT INTO Username (Usuario) VALUES('" + acc.UserName + "')";
                ExecuteNonQuery();
                comando.CommandText = "INSERT INTO Senha (Senha) VALUES( '" + acc.PassWord + "')";
                ExecuteNonQuery();
                comando.CommandText = "INSERT INTO Geral (PrimeiroNome, SegundoNome, Usuario, Senha) VALUES( '" + acc.PrimeiroNome + "', '" + acc.SegundoNome + "', '" + acc.UserName + "', '" + acc.PassWord + "')";
                ExecuteNonQuery();
                Console.Write("\nCadastro realizado com sucesso! ");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }
        public void CDeletar (Conta acc)
        {
            Console.Write("Você realmente quer deletar?\n1 - Sim, 2 - Não: ");
            ConsoleKeyInfo x = Console.ReadKey();
            switch (x.KeyChar)
            {
                case '1':
                    dlt();
                    break;
            }
            Console.Write("\nPressione qualquer tecla para continuar... ");
            void dlt()
            {
                try
                {
                    conexao.Open();
                    comando.CommandText = "DELETE FROM Account WHERE IDacc = " + idarm;
                    ExecuteNonQuery();
                    comando.CommandText = "DELETE FROM Username WHERE IDuser = " + idarm;
                    ExecuteNonQuery();
                    comando.CommandText = "DELETE FROM Senha WHERE IDpass = " + idarm;
                    ExecuteNonQuery();
                    comando.CommandText = "DELETE FROM Geral WHERE IDgeral = " + idarm;
                    ExecuteNonQuery();
                    Console.WriteLine("\nDeletado com sucesso!");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conexao != null)
                    {
                        conexao.Close();
                    }
                }
            }
        }
        public void CAlterar (Conta senhanova)
        {
            try
            {
 
                conexao.Open();
                comando.CommandText = "UPDATE Senha SET Senha = '" + senhanova.PassWord + "' WHERE IDpass=" + idarm;
                ExecuteNonQuery();
                comando.CommandText = "UPDATE Geral SET Senha = '" + senhanova.PassWord + "' WHERE IDgeral=" + idarm;
                ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }
    }
}

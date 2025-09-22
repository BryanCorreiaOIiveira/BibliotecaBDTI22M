using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class DAOAutor
    {
        public MySqlConnection conexao;//Criando uma chave para a classe MYSQLCONNECTON
        public string dados;
        public string comando;
        public DAOAutor()
        {
            //Connectar com banco
            conexao = new MySqlConnection("server=localhost;DataBase=biblioteca;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                conexao.Open();//Tenta abrir a conexao com o Banco de DAdos
                Console.WriteLine("Conectado Sucesso!");

            }
            catch (Exception erro)
            {
                Console.WriteLine($"ALgo deu errado!\n\n {erro}");
                conexao.Close();//Fechar a conexao
            }//fim do try_catch
        }//fim do construtor

        public void Inserir(string nome, string nacionalidade)
        {
            try
            {
                dados = $"('','{nome}','{nacionalidade}')";
                comando = $"Insert into autor(código, nome, nacionalidade) values{dados}";


                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();// Comando de inserção/ações
                Console.WriteLine($"Inserido com sucesso!) {resultado}");//Visualiação do resultado
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu Errado!\n\n {erro}");
            }//fim do catch
        }
    }// fim do classe
}// fim do projeto



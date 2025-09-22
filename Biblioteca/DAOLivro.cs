using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using MySql.Data;//Import do MySQL
using MySql.Data.MySqlClient; //Import do MySql - Com métodos do crud

namespace Biblioteca
{
    class DAOLivro
    {
        public MySqlConnection conexao;//Criando uma chave para a classe MYSQLCONNECTON
        public string dados;
        public string comando;
        public DAOLivro()
        { 
            //Connectar com banco
            conexao = new MySqlConnection("server=localhost;DataBase=biblioteca;uid=root;Password=;Convert Zero DateTime=True");
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

        public void Inserir(long ISBN, String titulo, DateTime ano, string editora, int categoriacodigo)
        {
            try
            {
                dados = $"('','{ISBN}','{titulo}','{ano}','{editora}','{categoriacodigo}')";
                comando = $"Insert into livro(código, isbn, titulo, ano, editora, categorialcódigo) values{dados}";


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
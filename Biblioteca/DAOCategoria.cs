using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Import do MySQL
using MySql.Data.MySqlClient;
using Microsoft.SqlServer.Server;
using Google.Protobuf.WellKnownTypes;
using System.Xml;
using Org.BouncyCastle.Pqc.Crypto.Utilities; //Import do MySql - Com métodos do crud

namespace Biblioteca
{
    class DAOCategoria
    {
        public MySqlConnection conexao;//Criando uma chave para a classe MYSQLCONNECTON
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] descricao;
        public int i;//desclaração global do contador
        public int contador;
        public string msg;
        public DAOCategoria()
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

        public void Inserir(string descricao)
        {
            try
            {
                dados = $"('','{descricao}')";
                comando = $"Insert into categoria(código, descricao) values{dados}";


                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();// Comando de inserção/ações
                Console.WriteLine($"Inserido com sucesso!) {resultado}");//Visualiação do resultado
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu Errado!\n\n {erro}");
            }//fim do catch
        }//fim do inserir

        //método para preencher o vetor
        public void PreencherVetor()
        {
            String query = "select * from categoria";//Comando SQL para acesso aos dados
            //Instanciar os vetores
            codigo = new int[100];
            descricao = new string[100];

            //Reafirmar que eu quero preencher com 0 e "" os vetores
            for(i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                descricao[i] = "";
            }//fim do for

            //Executar o comando no BD
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //leitura dos dados do banco - por linha
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;
            //Buscar os dados do banco e preencher o vetor
            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["código"]);
                descricao[i] = leitura["descricao"] + "";
                i++;//Ande pelo vetor
                contador++;//Contar exatamente quantos dados foram inseridos 
            }//fim do while

            //fechar a leitura 
            leitura.Close();
        }//fim do preencher

        public string ConsultarTudo()
        {
            //preencher o vetor
            PreencherVetor();
            msg = "";//Instanciando a variável
            for (int i = 0; i < contador; i++)
            {
                msg += $"\nCódigo: {codigo[i]} \nDescrição: {descricao[i]}\n";
            }//fim
            return msg;
        }//fim do método

        public string ConsultarPorCodigo(int codigo)
        {
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msg = $"\nCódigo:{this.codigo[i]} \nDescrição: {descricao[i]}\n";
                    return msg;
                }//fim do if
            }//fim do método
            return "\n\nCódigo informedo não foi encontrado!";
        }//fim do método
        //PAREI AQUI -------------------------------------------------- 24/09/2025
        public string Atualizar(int codigo, string campo, string novoDado) 
        {
            try
            {
                string query = $"update categoria set {campo} = '{novoDado}' where código = '{codigo}'";
                //Executar o comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//fim do método

        public string Deletar(int codigo)
        { 
            try
            {
                string query = $"delete from categoria where código = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado excluido";
            }//fim do try
            catch (Exception erro)
            {
                return $"algo deu errado\n\n {erro}";
            }//fim do catch 
        }//fim do método

    }// fim do classe
}// fim do projeto

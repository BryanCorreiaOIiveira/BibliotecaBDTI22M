using System;
using System.Collections.Generic;
using System.IO.Pipes;
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
        public int[] codigo;
        public int i;
        public int contador;
        public long[] ISBN;
        public string[] titulo;
        public DateTime[] ano;
        public string[] editora;
        public int[] categoriacodigo;
        public string msg;
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
                //Modificar
                MySqlParameter parameter= new MySqlParameter();
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
                parameter.Value = $"{ano.Year}-{ano.Month}-{ano.Day}";

                dados = $"('','{ISBN}','{titulo}','{ano}','{editora}','{categoriacodigo}')";
                comando = $"Insert into livro(código, isbn, titulo, ano, editora, categorialcódigo) values{dados}";
                //Lançar os dados no banco
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();// Comando de inserção/ações
                Console.WriteLine($"Inserido com sucesso!) {resultado}");//Visualiação do resultado
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Algo deu Errado!\n\n {erro}");
            }//fim do catch
        }

        public string ConsultarISBN(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            { 
                if (this.codigo[i] == codigo) 
                {
                    return ISBN[i] + "";
                }//fim do if 
            }//fim do for
            return "Código não existe!";
        }//fim do método

        public string ConsultarTitulo(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    return titulo[i] + "";
                }//fim do if 
            }//fim do for
            return "Código não existe!";
        }//fim do método

        public string ConsultarAno(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    return ano[i] + "";
                }//fim do if 
            }//fim do for
            return "Código não existe!";
        }//fim do método

        public string ConsultarEditora(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    return editora[i] + "";
                }//fim do if 
            }//fim do for
            return "Código não existe!";
        }//fim do método

        public string ConsultarCategoriacodigo(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    return categoriacodigo[i] + "";
                }//fim do if 
            }//fim do for
            return "Código não existe!";
        }//fim do método

        public void PreencherVetor()
        {
            String query = "select * from livro";//Comando SQL para acesso aos dados
            //Instanciar os vetores
            codigo = new int[100];
            ISBN = new long[100];
            titulo = new string[100];
            ano = new DateTime[100];
            editora = new string[100];
            categoriacodigo = new int[100];
            //Reafirmar que eu quero preencher com 0 e "" os vetores
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                ISBN[i] = 0;
                titulo[i] = "";
                ano[i] = new DateTime();
                editora[i] = "";
                categoriacodigo[i] = 0;
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
                ISBN[i] = Convert.ToInt64(leitura["ISBN"]);
                titulo[i] = leitura["titulo"] + "";
                //ano[i] = Convert.ToDatetime(leitura["ano"]);
                editora[i] = leitura["editora"] + "";
                categoriacodigo[i] = Convert.ToInt32(leitura["categorialcódigo"]);
                i++;//Ande pelo vetor
                contador++;//Contar exatamente quantos dados foram inseridos 
            }//fim do while

            //fechar a leitura 
            leitura.Close();
        }//fim do preencher

        public int QuantidadeDeDados()
        {
            return contador;
        }//fim do método 

        public string ConsultarTudo()
        {
            //preencher o vetor
            PreencherVetor();
            msg = "";//Instanciando a variável
            for (int i = 0; i < contador; i++)
            {
                msg += $"\n Código: {codigo[i]} \n ISBN: {ISBN[i]}\n titulo: {titulo} \n ano: {ano} \n editora: {editora} \n categoriacódigo: {categoriacodigo}";
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
                    msg = $"\nCódigo:{this.codigo[i]} \nISBN: {ISBN[i]}\n titulo: {titulo[i]} \n ano: {ano[i]} \n editora {editora [i]} \n categoriacódigo: {categoriacodigo[i]}";
                    return msg;
                }//fim do if
            }//fim do método
            return "\n\nCódigo informado não foi encontrado!";
        }//fim do método

        public string Atualizar(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update Livro set {campo} = '{novoDado}' where código = '{codigo}'";
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

        public string Atualizar(int codigo, string campo, long novoDado)
        {
            try
            {
                string query = $"update Livro set {campo} = '{novoDado}' where código = '{codigo}'";
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

        public string Atualizar(int codigo, string campo, DateTime novoDado)
        {
            try
            {
                string query = $"update Livro set {campo} = '{novoDado}' where código = '{codigo}'";
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

        public string Atualizar(int codigo, string campo, int novoDado)
        {
            try
            {
                string query = $"update Livro set {campo} = '{novoDado}' where código = '{codigo}'";
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
                string query = $"delete from Livro where código = '{codigo}'";
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
using Google.Protobuf.WellKnownTypes;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class ControlCategoria
    {
        private Categoria categoria;
        private DAOCategoria dao;

        public ControlCategoria()
        {
            categoria = new Categoria();
        }//fim do construtor

        public ControlCategoria(string descricao)
        {
            this.dao = new DAOCategoria();
            this.dao.Inserir(descricao);
        }//fim do construtor

        public void Imprimir()
        {
            this.dao = new DAOCategoria();
            Console.WriteLine(this.dao.ConsultarTudo());
        }//fim do imprimir

        //Método para consulto por código
        public void ConsultarPorCodigo()
        {
            this.dao = new DAOCategoria();
            Console.WriteLine("Informe o código que deseja buscar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Pedindo para o usuário digital
            Console.WriteLine(this.dao.ConsultarPorCodigo(codigo));
        }//fim do método

        public void Atualizar()
        {
            this.dao = new DAOCategoria();
            Console.WriteLine("Escolha o que deseja atualizar: " +
                              "\n1. Descricao ");
            int escolha = Convert.ToInt32(Console.ReadLine());
            //pequeno escolha
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Atualizar descrição");
                    Console.WriteLine("informe o código de onde vai atualizar");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    //Nova descrição
                    Console.WriteLine("Informe a nova descrição:");
                    string descricao = Console.ReadLine();
                    //Atualizar
                    Console.WriteLine(this.dao.Atualizar(codigo, "descricao", descricao));
                    break;
                default:
                    Console.WriteLine("Impossível atualizar, algo deu errado!");
                    break;
            }//fim do método

        }//fim do atualizar
        
        public void Excluir()
        {
            this.dao = new DAOCategoria();

            Console.WriteLine("informe o código que deseja Excluir: ");
            int código = Convert.ToInt32(Console.ReadLine());

            //Chama o método para excluir
            Console.WriteLine(this.dao.Deletar(código));
        }//fim do excluir
    }//fim da classe
}//fim do projeto

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class ControlAutor
    {
        private Autor autor;
        private DAOAutor dao;

        public ControlAutor()
        {
            autor = new Autor();
        }//fim do construtor

        public ControlAutor(string nome, string nacionalidade)
        {
            this.dao = new DAOAutor();
            this.dao.Inserir(nome, nacionalidade);
        }//fim do construtor

        public void Imprimir()
        {
            this.dao = new DAOAutor();
            Console.WriteLine(this.dao.ConsultarTudo());
        }//fim do imprimir

        public void ConsultarPorCodigo()
        {
            this.dao = new DAOAutor();
            Console.WriteLine("Informe o código que deseja buscar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());
            //Pedindo para o usuário digital
            Console.WriteLine(this.dao.ConsultarPorCodigo(codigo));
        }//fim do método

        public void Atualizar(int opcao, string dado)
        {
            switch (opcao)
            {
                case 1:
                    this.autor.ModificarNome = dado;
                    Console.WriteLine("Nome atualizado com sucesso!");
                    break;
                case 2:
                    this.autor.ModificarNacionalidade = dado;
                    Console.WriteLine("Nacionalidade atualizada com sucesso!");
                    break;
                default:
                    Console.WriteLine("Opção não é válida!");
                    break;
            }//fim do escolha
        }//fim do método atualizar
    }//fim da classe
}//fim do projeto

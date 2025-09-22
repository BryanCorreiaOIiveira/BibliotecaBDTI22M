using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine(categoria.Imprimir());
        }//fim do imprimir

        public void Atualizar(string categoria)
        {
            this.categoria.ModificarDescricao = categoria;
        }//fim do atualizar
    }//fim da classe
}//fim do projeto

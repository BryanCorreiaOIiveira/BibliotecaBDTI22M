using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class MenuAutor : Form
    {
        public MenuAutor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastrarAutor cadastrar = new CadastrarAutor();
            cadastrar.ShowDialog();
        }//Cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultarAutor consultar = new ConsultarAutor();
            consultar.ShowDialog();
        }//Consultar

        private void button3_Click(object sender, EventArgs e)
        {
            AtualizarAutor atualizar = new AtualizarAutor();
            atualizar.ShowDialog();
        }//Atualizar

        private void button4_Click(object sender, EventArgs e)
        {
            ExcluirAutor excluir = new ExcluirAutor();
            excluir.ShowDialog();
        }//Excluir
    }
}

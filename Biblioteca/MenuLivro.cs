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
    public partial class MenuLivro : Form
    {
        public MenuLivro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastrarLivro cadastrarLivro = new CadastrarLivro();
            cadastrarLivro.ShowDialog();
        }//Cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultarLivro consultarLivro = new ConsultarLivro();
            consultarLivro.ShowDialog();
        }//Consultar

        private void button3_Click(object sender, EventArgs e)
        {
            AtualizaLivro atualizaLivro = new AtualizaLivro();
            atualizaLivro.ShowDialog();
        }//Atulizar

        private void button4_Click(object sender, EventArgs e)
        {
            ExcluirLivro excluirLivro = new ExcluirLivro();
            excluirLivro.ShowDialog();
        }//Excluir
    }
}
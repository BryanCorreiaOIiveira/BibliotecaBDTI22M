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
    public partial class MenuCategoria : Form
    {
        public MenuCategoria()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AtualizaCategoria atualiza = new AtualizaCategoria();
            atualiza.ShowDialog();
        }//Atualizar

        private void button1_Click(object sender, EventArgs e)
        {
            CadastrarCategoria cadastrar = new CadastrarCategoria();
            cadastrar.ShowDialog();
        }//Cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultarCategoria consultar = new ConsultarCategoria();
            consultar.ShowDialog();
        }//Consultar

        private void button4_Click(object sender, EventArgs e)
        {
            ExcluirCategoria exluir = new ExcluirCategoria();
            exluir.ShowDialog();
        }//Excluir
    }
}

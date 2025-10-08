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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }//Botão Livro

        private void button2_Click(object sender, EventArgs e)
        {
            MenuLivro menuLivro = new MenuLivro();
            menuLivro.ShowDialog();
        }//Botão Autor

        private void button3_Click(object sender, EventArgs e)
        {

        }//Botão Categoria
    }//fim da classe
}//fim do projeto

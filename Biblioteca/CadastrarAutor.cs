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
    public partial class CadastrarAutor : Form
    {
        public CadastrarAutor()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//Nome

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//nacionalidade

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //coletar os dados
                string Nome = textBox1.Text;
                string nacionalidade = textBox2.Text;
                //Cadastrar no Banco de Dados
                ControlAutor controlAutor = new ControlAutor(
                                                   Nome,
                                                   nacionalidade);
                //Confirmar que foi inserido
                MessageBox.Show($"cadastrado com sucesso!!! \n\n\nome: {Nome}" +
                                                        $"\nnacionalidade: {nacionalidade}");
                //Limpar os campos após cadastro
                textBox1.Text = "";
                textBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Algo deu errado!!!! \n\n{ex}");
            }
        }//Cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//voltar
    }
}

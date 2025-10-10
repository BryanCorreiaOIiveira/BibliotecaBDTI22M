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
    public partial class CadastrarLivro : Form
    {
        public CadastrarLivro()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //coletar os dado
                int ISBN = Convert.ToInt32(textBox1.Text);
                string titulo = textBox2.Text;
                DateTime data = Convert.ToDateTime(textBox3.Text);
                string editora = textBox4.Text;
                int CodigoCategoria = Convert.ToInt32(textBox5.Text);
                //Cadastrar no Banco de Dados
                ControlLivro controleLivro = new ControlLivro(
                                                    ISBN,
                                                    titulo,
                                                    data,
                                                    editora,
                                                    CodigoCategoria);
                //Confirmar que foi inserido
                MessageBox.Show("Cadastrado com sucesso!!!");
                //Limpar os campos após cadastro
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Algo deu errado!!!! \n\n{ex}");
            }
            

            
        }//botão Cadastrar

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//ISBN

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//titulo

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//Data

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//Editora

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }//código Categoria

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Botão Voltar

        private void CadastrarLivro_Load(object sender, EventArgs e)
        {

        }
    }
}

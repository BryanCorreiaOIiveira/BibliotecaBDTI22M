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
    public partial class Atualizar : Form
    {
        DAOLivro dao;
        public Atualizar()
        {
            InitializeComponent();
            dao = new DAOLivro();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text);
            textBox2.Text = dao.ConsultarISBN(codigo);
            textBox3.Text = dao.ConsultarTitulo(codigo);
            textBox4.Text = dao.ConsultarAno(codigo);
            textBox5.Text = dao.ConsultarEditora(codigo);
            textBox6.Text = dao.ConsultarCategoriacodigo(codigo);
        }//botão buscar

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//código

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//isbn

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//data

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//titulo

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }//editoria

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }//codigocategoria

        private void button9_Click(object sender, EventArgs e)
        {

        }//botão voltar

        private void button8_Click(object sender, EventArgs e)
        {
            //pegar os dados
            int isbn = Convert.ToInt32(textBox2.Text);
            string titulo = textBox3.Text;
            DateTime data = Convert.ToDateTime(textBox4.Text);
            string editora = textBox5.Text;
            int codigoCategoria = Convert.ToInt32(textBox6.Text);
            //Atualizar
            int codigo = Convert.ToInt32(textBox1.Text);
            dao.Atualizar(codigo, "isbn", isbn);
            dao.Atualizar(codigo, "titulo", titulo);
            dao.Atualizar(codigo, "data", data);
            dao.Atualizar(codigo, "editora", editora);
            dao.Atualizar(codigo, "categoriaCodigo", codigoCategoria);
            //Mensagem:
            MessageBox.Show("Atualizado com  sucesso!");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }//botao atualizar
    }
}

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
    public partial class AtualizarAutor : Form
    {
        DAOAutor dao;
        public AtualizarAutor()
        {
            InitializeComponent();
            dao = new DAOAutor();
        }//fim do construtor

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//Código

        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text);
            textBox2.Text = dao.ConsultarNome(codigo);
            textBox3.Text = dao.ConsultarNacionalidade(codigo);
        }//Botão Buscar

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//Nome

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//Nacionalidade

        private void button2_Click(object sender, EventArgs e)
        {
            //Pegar os dados
            string nome = textBox2.Text;
            string nacionalidade = textBox3.Text;
            //Atualizar
            int codigo = Convert.ToInt32(textBox1.Text);
            dao.Atualizar(codigo, "nome", nome);
            dao.Atualizar(codigo, "nacionalidade", nacionalidade);
            //Mensagem:
            MessageBox.Show("Atualizado com sucesso!");
            textBox2.Text = "";
            textBox3.Text = "";
        }//Botão Atualizar

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Botão Voltar
    }//fim do classe
}//fim do projeto

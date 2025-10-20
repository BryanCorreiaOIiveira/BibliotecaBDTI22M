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
    public partial class AtualizaCategoria : Form
    {
        DAOCategoria dao;
        public AtualizaCategoria()
        {
            InitializeComponent();
            dao = new DAOCategoria();
        }//fim do construtor

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//Código

        private void button2_Click(object sender, EventArgs e)
        {
            //Pegar os dados
            string descriçao = textBox2.Text;
            //Atualizar
            int codigo = Convert.ToInt32(textBox1.Text);
            dao.Atualizar(codigo, "descriçao", descriçao);
            //Mensagem
            MessageBox.Show("Atualizado com sucesso!");
            textBox1.Text = "";
            textBox2.Text = "";
        }//Atualizar

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//Nome

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Voltar

        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text);
            textBox2.Text = dao.ConsultarPorCodigo(codigo);
        }//Buscar
    }//fim da classe
}//fim do projeto

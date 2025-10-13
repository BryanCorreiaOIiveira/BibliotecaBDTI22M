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
    public partial class CadastrarCategoria : Form
    {
        public CadastrarCategoria()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CadastrarCategoria_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//descricao

        private void button2_Click(object sender, EventArgs e)
        {

        }//voltar

        private void button1_Click_1(object sender, EventArgs e)
        {
            try { 
                string descricao = textBox1.Text;

            //Cadastrar no Banco de Dados
                ControlCategoria controlCategoria = new ControlCategoria(descricao);

            //Confirmar que foi inserido
                MessageBox.Show($"Cadastrado com sucesso!!! \ndescricao: {descricao}");

            //Limpar os Campos após Cadastro
                textBox1 .Text = "";

            }catch(Exception ex)
            {
                MessageBox.Show($"Algo deu errado!!!! \n\n{ex}");
            }    
        }//cadastrar
    }//Fim do classe
}//Fim do projeto
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
    public partial class ConsultarCategoria : Form
    {
        ControlCategoria controle;
        DAOCategoria dao;
        public ConsultarCategoria()
        {
            InitializeComponent();
            controle = new ControlCategoria();
            dao = new DAOCategoria();
            //Chamar TODOS OS MÉTODOS NA ORDEN
            ConfigurarGrid();//Estruturando o Grid
            NomeDados();//Nomear as colunas
            dao.PreencherVetor();//Preencher os vetores e consultar o banco
            AdicionarDados();//inserir os dados na tela, linha por linha
        }//fim do construtor

        public void AdicionarDados()
        {
            for(int i = 0; i < dao.QuantidadeDeDados(); i++)
            {
                dataGridView1.Rows.Add(dao.codigo[i], dao.descricao[i]);
            }//fim do for
        }//fim do  método

        public void ConfigurarGrid()
        {
            dataGridView1.AllowUserToAddRows = false;//Adicionar linhas
            dataGridView1.AllowUserToDeleteRows = false;//Apagar linhas
            dataGridView1.AllowUserToResizeColumns = false;//Modificar colunas
            dataGridView1.AllowUserToResizeRows = false;//Modificar Linhas
            dataGridView1.ColumnCount = 2;
        }//fim do configurarGrid

        public void NomeDados()
        {
            dataGridView1.Columns[0].Name = "Código";
            dataGridView1.Columns[1].Name = "Descricao";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }//Volta

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }



    }//fim da classe
}//fim do projeto

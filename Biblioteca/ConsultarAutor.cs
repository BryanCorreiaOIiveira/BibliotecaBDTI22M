using Org.BouncyCastle.Asn1.BC;
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
    public partial class ConsultarAutor : Form
    {
        ControlAutor controle;
        DAOAutor dao;
        public ConsultarAutor()
        {
            InitializeComponent();
            controle = new ControlAutor();
            dao = new DAOAutor();
            //Chamar TODOS OS MÉTODOS NA ORDEm
            ConfigurarGrid();//Estruturando o Grid
            NomeDados();//Nomear as colunas
            dao.PreencherVetor();//Preencher os vetores e consultar o banco
            AdicionarDados();//Inserir os dados na tela, linha por linhas
        }//fim do Construtor

        public void  AdicionarDados()
        {
            for(int i = 0; i < dao.QuantidadeDeDados(); i++)
            {
                dataGridView1.Rows.Add(dao.codigo[i], dao.nome[i], dao.nacionalidade[i]);
            }//fim do for
        }//fim do método

        public void ConfigurarGrid()
        {
            dataGridView1.AllowUserToAddRows = false;//Adicionar linhas
            dataGridView1.AllowUserToDeleteRows = false;//Apagar linhas
            dataGridView1.AllowUserToResizeColumns = false;//Modificar colunas
            dataGridView1.ColumnCount = 3;
        }//fim do configurarGrid

        public void NomeDados()
        {
            dataGridView1.Columns[0].Name = "codigo";
            dataGridView1.Columns[1].Name = "nome";
            dataGridView1.Columns[2].Name = "nacionalidade";
        }//fim do método

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }//fim do dataGridView1
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }//fim de voltar
    }
}
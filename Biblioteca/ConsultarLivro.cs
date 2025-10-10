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
    public partial class ConsultarLivro : Form
    {
        ControlLivro Controle;
        DAOLivro dao;
        public ConsultarLivro()
        {
            InitializeComponent();
            Controle = new ControlLivro();
            dao      = new DAOLivro();
            //Chamar TODOS OS MÉTODOS NA ORDEM
            ConfigurarGrid();//Estruturando o Grid
            NomeDados();//Nomear as colunas
            dao.PreencherVetor();//Preencher
            AdicionarDados();
        }//fim do construtor

        public void AdicionarDados()
        {
            for (int i = 0; i < dao.QuantidadeDeDados(); i++)
            {
                dataGridView1.Rows.Add(dao.codigo[i], dao.ISBN[i], dao.titulo[i], dao.ano[i], dao.editora[i], dao.categoriacodigo[i]);
            }//fim do for
        }//fim do método    

        public void ConfigurarGrid()
        {
            dataGridView1.AllowUserToAddRows = false;//Adicionar linha
            dataGridView1.AllowUserToDeleteRows = false;//Apagar linha
            dataGridView1.AllowUserToResizeColumns = false;//modificar coluna
            dataGridView1.AllowUserToResizeRows = false;//modificar linha
            dataGridView1.ColumnCount = 6;
        }//fim do configurarGrid

        public void NomeDados()
        {
            dataGridView1.Columns[0].Name = "Código";
            dataGridView1.Columns[1].Name = "ISBN";
            dataGridView1.Columns[2].Name = "Título";
            dataGridView1.Columns[3].Name = "Data Publicação";
            dataGridView1.Columns[4].Name = "Editora";
            dataGridView1.Columns[5].Name = "Código Categoria";
        }//fim do método 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }//fim do DataGridView1

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using AppExemplo;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppExemplos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparDados();
        }

        private void LimparDados()
        {
            txtId.Clear();
            txtDescricao.Clear();
            txtQuantidade.Text = "0";
            dtpValidade.Value = DateTime.Now;
            txtId.Text = "0";
            txtPreco.Text = "0";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        conexao objBD = new conexao();

        private void btnInserir_Click(object sender, EventArgs e)
        {

            try { 
            string desc = txtDescricao.Text;
            int quant = int.Parse(txtQuantidade.Text);
            DateTime dt = dtpValidade.Value;
            double preco = double.Parse(txtPreco.Text);

            string inserir = $"INSERT INTO tblProduto VALUES (null, '{desc}', '{quant}','{dt.ToString("yyyy/MM/dd")}','{preco.ToString().Replace(',','.')}');";
            objBD.ExecutarComando(inserir);
            LimparDados();
            MessageBox.Show("Dados armazenados.");
            ExibirDados();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);

                string deletar = $"DELETE FROM tblProduto WHERE id = '{id}';";
                objBD.ExecutarComando(deletar);
                MessageBox.Show("Dados deletados.");
                LimparDados();
                ExibirDados();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string desc = txtDescricao.Text;
                int quant = int.Parse(txtQuantidade.Text);
                DateTime dt = dtpValidade.Value;
                double preco = double.Parse(txtPreco.Text);

                string alterar = $"UPDATE tblProduto SET descricao = '{desc}', quantidade = '{quant}', dtValidade = '{dt.ToString("yyyy/MM/dd")}', preco = '{preco.ToString().Replace(',', '.')}' WHERE id = '{id}';";
                objBD.ExecutarComando(alterar);
                LimparDados();
                MessageBox.Show("Os dados foram alterados");
                ExibirDados();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ExibirDados()
        {
            string consulta = "SELECT * FROM  tblProduto ORDER BY id;";
            dtgProdutos.DataSource = objBD.ExecutarConsulta(consulta);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ExibirDados();
        }

        private void dtgProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text         = dtgProdutos.Rows[e.RowIndex].Cells["id"].Value.ToString();
            txtDescricao.Text  = dtgProdutos.Rows[e.RowIndex].Cells["descricao"].Value.ToString();
            txtQuantidade.Text = dtgProdutos.Rows[e.RowIndex].Cells["quantidade"].Value.ToString();
            dtpValidade.Value  = DateTime.Parse(dtgProdutos.Rows[e.RowIndex].Cells["dtValidade"].Value.ToString());
            txtPreco.Text      = dtgProdutos.Rows[e.RowIndex].Cells["preco"].Value.ToString();
        }
    }
}

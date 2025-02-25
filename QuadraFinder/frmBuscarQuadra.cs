using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuadraFinder
{
    public partial class frmBuscarQuadra: Form
    {
        public frmBuscarQuadra()
        {
            InitializeComponent();
        }

        clQuadra quadra = new clQuadra();

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dgvQuadra.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection linha = dgvQuadra.SelectedRows;
                quadra.idquadra = int.Parse(linha[0].Cells[0].Value.ToString());
                quadra.name = linha[0].Cells[1].Value.ToString();
                quadra.publicplace = linha[0].Cells[2].Value.ToString();
                quadra.zipcode = linha[0].Cells[3].Value.ToString();
                quadra.type = linha[0].Cells[4].Value.ToString();
                quadra.photos = linha[0].Cells[5].Value.ToString();
                quadra.state = linha[0].Cells[6].Value.ToString();
                quadra.city = linha[0].Cells[7].Value.ToString();
                quadra.neighborhood = linha[0].Cells[8].Value.ToString();
                quadra.preco = decimal.Parse(linha[0].Cells[9].Value.ToString());
                quadra.status = bool.Parse(linha[0].Cells[10].Value.ToString());

                frmCadastrarQuadra formulario = new frmCadastrarQuadra();
                formulario.quadra = quadra;
                formulario.ShowDialog();
            }
        }

        private void dgvQuadra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPesquisa.Text != "")
                {
                    quadra.name = txtPesquisa.Text;
                    dgvQuadra.DataSource = quadra.PesquisaPorNome();
                }

                // Ajuste de colunas no DataGridView
                dgvQuadra.Columns[0].Visible = false;  // ID
                dgvQuadra.Columns[6].Visible = false;  // State
                dgvQuadra.Columns[7].Visible = false;  // City
                dgvQuadra.Columns[8].Visible = false;  // Neighborhood
                dgvQuadra.Columns[10].Visible = false; // Alugado
                dgvQuadra.Columns[11].Visible = false; // Não Alugado

                dgvQuadra.Columns[1].Width = 200; // Nome

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO.: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvQuadra.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection linha = dgvQuadra.SelectedRows;
                quadra.idquadra = int.Parse(linha[0].Cells[0].Value.ToString());

                DialogResult resposta = MessageBox.Show("Você tem certeza que deseja excluir a quadra " + linha[0].Cells[1].Value.ToString() + " ?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    quadra.Excluir();
                    txtPesquisa_TextChanged(null, null);
                }
            }
            else
            {
                MessageBox.Show("Você precisa selecionar uma quadra para poder excluí-la!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBuscarQuadra_Load(object sender, EventArgs e)
        {
            try
            {
                
                dgvQuadra.DataSource = quadra.PesquisaTudo();
                
                dgvQuadra.Columns[1].Width = 200; // Nome

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO.: " + ex.Message);
            }
        }
    }
}

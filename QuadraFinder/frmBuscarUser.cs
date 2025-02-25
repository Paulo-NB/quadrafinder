using QuadraFinder;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuadraFinder
{
    public partial class frmBuscarUser : Form
    {
        public frmBuscarUser()
        {
            InitializeComponent();
        }

        
        clUser user = new clUser();

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

            DataGridViewSelectedRowCollection linha = dgvuserAdm.SelectedRows;
            user.iduser = int.Parse(linha[0].Cells[0].Value.ToString());
            user.name = linha[0].Cells[1].Value.ToString();
            user.cpf = linha[0].Cells[2].Value.ToString();
            user.email = linha[0].Cells[3].Value.ToString();
            user.pass = linha[0].Cells[4].Value.ToString();
            user.phone = linha[0].Cells[5].Value.ToString();

            frmCadastrarUser formulario = new frmCadastrarUser();
            formulario.user = user;
            formulario.ShowDialog();

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (txtPesquisa.Text != "")
                {
                    user.name = txtPesquisa.Text;
                    dgvuserAdm.DataSource = user.PesquisaPorNome();
                }

                dgvuserAdm.Columns[0].Visible = false;
                dgvuserAdm.Columns[3].Visible = false;
                dgvuserAdm.Columns[4].Visible = false;
                dgvuserAdm.Columns[5].Visible = false;

                dgvuserAdm.Columns[1].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO.: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (dgvuserAdm.SelectedRows.Count > 0)
            {
                DataGridViewSelectedRowCollection linha = dgvuserAdm.SelectedRows;
                user.iduser = int.Parse(linha[0].Cells[0].Value.ToString());

                DialogResult resposta = MessageBox.Show("Você tem certeza que deseja excluir o usuário " + linha[0].Cells[1].Value.ToString() + " ?", "Tem certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {
                    user.Excluir();
                    txtPesquisa_TextChanged(null, null);
                }
            }
            else
            {
                MessageBox.Show("Você precisa selecionar um usuário para poder excluí-lo!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dgvuserAdm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmBuscarUser_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

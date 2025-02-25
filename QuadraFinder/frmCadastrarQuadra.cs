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
    public partial class frmCadastrarQuadra: Form
    {
        public frmCadastrarQuadra()
        {
            InitializeComponent();
        }

        public clQuadra quadra;

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            clQuadra quadras = new clQuadra();
            quadras.name = txtNome.Text;
            quadras.publicplace = txtLogradouro.Text;
            quadras.zipcode = txtCEP.Text;
            quadras.photos = txtFoto.Text;
            quadras.type = txtTipos.Text;
            quadras.state = txtEstado.Text;
            quadras.city = txtCidade.Text;
            quadras.neighborhood = txtBairro.Text;
            quadras.preco = decimal.TryParse(txtPreco.Text, out decimal preco) ? preco : 0;
            quadras.status = chkAlugado.Checked;

            if (txtID.Text == "")
            {
                txtID.Text = Convert.ToString(quadras.Salvar());
            }
            else
            {
                quadras.idquadra = int.Parse(txtID.Text);
                quadras.Atualizar();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastrarQuadra_Load(object sender, EventArgs e)
        {
            if (quadra != null)
            {
                txtID.Text = quadra.idquadra.ToString();
                txtNome.Text = quadra.name;
                txtLogradouro.Text = quadra.publicplace;
                txtCEP.Text = quadra.zipcode;
                txtTipos.Text = quadra.type;
                txtEstado.Text = quadra.state;
                txtCidade.Text = quadra.city;
                txtBairro.Text = quadra.neighborhood;
                txtPreco.Text = quadra.preco.ToString();
                if(quadra.status.Equals("alugado"))
                {
                    chkAlugado.Checked = true;
                }
                else
                {
                    chkAlugado.Checked = false;
                }
                btnSalvar.Text = "Atualizar";
            }
        }
    }
}


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
    public partial class frmCadastrarUser: Form
    {
        public frmCadastrarUser()
        {
            InitializeComponent();
        }

        public clUser user;

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            clUser user = new clUser();
            user.name = txtNome.Text;
            user.cpf = txtCpf.Text;
            user.email = txtEmail.Text;
            user.pass = txtSenha.Text;
            user.phone = txtCelular.Text;

            if (txtID.Text == "")
            {
                txtID.Text = Convert.ToString(user.Salvar());
            }
            else
            {
                user.iduser = int.Parse(txtID.Text);
                user.Atualizar();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastrarUser_Load(object sender, EventArgs e)
        {
            if (user != null)
            {
                txtID.Text = user.iduser.ToString();
                txtNome.Text = user.name;
                txtCpf.Text = user.cpf;
                txtEmail.Text = user.email;
                txtSenha.Text = user.pass;
                txtCelular.Text = user.phone;
                btnSalvar.Text = "Atualizar";
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

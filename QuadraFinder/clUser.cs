using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace QuadraFinder
{
    public class clUser
    {
        // Atributos
        public int iduser;
        public string name;
        public string pass;
        public string cpf;
        public string email;
        public string phone;

        conectaBD BD = new conectaBD();

        // Método para salvar um usuário
        public int Salvar()
        {
            int id = 0;
            try
            {
                BD._sql = String.Format(new CultureInfo("en-US"), "INSERT INTO USER (NAME, CPF, EMAIL, PASS, PHONE) " +
                                       "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')" +
                                       "; SELECT SCOPE_IDENTITY();",
                                        name, cpf, email, pass, phone);

                BD.ExecutaComando(false, out id);

                if (id > 0)
                {
                    MessageBox.Show("User cadastrado com sucesso!", "Cadastro com sucesso",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar User", "Erro", MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
            }

            return id;
        }

        // Método para excluir um usuário
        public void Excluir()
        {
            try
            {
                int exOK = 0;
                BD._sql = "DELETE FROM USER WHERE IDUSER = " + iduser;
                exOK = BD.ExecutaComando(false);

                if (exOK == 1)
                {
                    MessageBox.Show("User deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao deletar User", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para atualizar um usuário
        public void Atualizar()
        {
            try
            {
                int exOK = 0;
                BD._sql = "UPDATE USER SET NAME = '" + name + "', CPF = '" + cpf + "', EMAIL = '" + email + "', PASS = '" + pass + "', PHONE = '" + phone + "' " +
                          "WHERE IDUSER = " + iduser;

                exOK = BD.ExecutaComando(false);

                if (exOK == 1)
                {
                    MessageBox.Show("User alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao alterar User", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para pesquisar um usuário pelo nome
        public DataTable PesquisaPorNome()
        {
            try
            {
                BD._sql = "SELECT * FROM USER WHERE NAME LIKE '%" + name + "%'";
                return BD.ExecutaSelect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Método para buscar usuário pelo email
        public DataTable EfetuarLogin()
        {
            try
            {
                BD._sql = "SELECT * FROM USER WHERE EMAIL LIKE '" + email + "'";
                return BD.ExecutaSelect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

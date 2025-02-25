using QuadraFinder;
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

            DateTime dataHoraAtual = DateTime.UtcNow;

            // Formata a data e hora para o formato desejado
            string hoje = dataHoraAtual.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            try
            {
                BD._sql = String.Format(new CultureInfo("en-US"), "INSERT INTO USERS (NAME, CPF, EMAIL, PASS, PHONE,createdAt, updatedAt) " +
                                       "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')" +
                                       "; SELECT LAST_INSERT_ID();",
                                        name, cpf, email, pass, phone, hoje,hoje);

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
                BD._sql = "DELETE FROM users WHERE ID = " + iduser;
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
                BD._sql = "UPDATE users SET NAME = '" + name + "', CPF = '" + cpf + "', EMAIL = '" + email + "', PASS = '" + pass + "', PHONE = '" + phone + "' " +
                          "WHERE ID = " + iduser;

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
                BD._sql = "SELECT * FROM users WHERE NAME LIKE '%" + name + "%'";
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
                BD._sql = "SELECT * FROM users WHERE EMAIL LIKE '" + email + "'";
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

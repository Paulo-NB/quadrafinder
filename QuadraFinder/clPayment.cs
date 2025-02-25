using QuadraFinder;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace QuadraFinder
{
    public class clPayment
    {
        // Atributos
        public int idpayment;
        public decimal total;
        public DateTime date;
        public int iduser;
        public int idlocation;
        public string cvv;
        public string numbercard;
        public int yearcard;
        public int monthcard;

        conectaBD BD = new conectaBD();

        // Método para salvar um pagamento
        public int Salvar()
        {
            int id = 0;
            try
            {
                BD._sql = String.Format(new CultureInfo("en-US"), "INSERT INTO PAYMENT (TOTAL, DATE, IDUSER, IDLOCATION, CVV, NUMBERCARD, YEARCARD, MONTHCARD) " +
                                       "VALUES ({0}, '{1}', {2}, {3}, '{4}', '{5}', {6}, {7})" +
                                       "; SELECT LAST_INSERT_ID();",
                                        total, date.ToString("yyyy-MM-dd HH:mm:ss"), iduser, idlocation, cvv, numbercard, yearcard, monthcard);

                BD.ExecutaComando(false, out id);

                if (id > 0)
                {
                    MessageBox.Show("Pagamento cadastrado com sucesso!", "Cadastro com sucesso",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar pagamento", "Erro", MessageBoxButtons.OK,
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

        // Método para excluir um pagamento
        public void Excluir()
        {
            try
            {
                int exOK = 0;
                BD._sql = "DELETE FROM PAYMENT WHERE IDPAYMENT = " + idpayment;
                exOK = BD.ExecutaComando(false);

                if (exOK == 1)
                {
                    MessageBox.Show("Pagamento deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao deletar pagamento", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para atualizar um pagamento
        public void Atualizar()
        {
            try
            {
                int exOK = 0;
                BD._sql = "UPDATE PAYMENT SET TOTAL = " + total + ", DATE = '" + date.ToString("yyyy-MM-dd HH:mm:ss") + "', IDUSER = " + iduser + ", IDLOCATION = " + idlocation + ", " +
                          "CVV = '" + cvv + "', NUMBERCARD = '" + numbercard + "', YEARCARD = " + yearcard + ", MONTHCARD = " + monthcard + " WHERE IDPAYMENT = " + idpayment;

                exOK = BD.ExecutaComando(false);

                if (exOK == 1)
                {
                    MessageBox.Show("Pagamento atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar pagamento", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para pesquisar pagamentos por usuário
        public DataTable PesquisaPorUsuario()
        {
            try
            {
                BD._sql = "SELECT * FROM PAYMENT WHERE IDUSER = " + iduser;
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

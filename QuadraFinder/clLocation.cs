using QuadraFinder;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace QuadraFinder
{
    public class clLocation
    {
        // Atributos
        public int idlocation;
        public int iduser;
        public int idcourt;
        public DateTime date;

        conectaBD BD = new conectaBD();

        // Método para salvar uma localização
        public int Salvar()
        {
            int id = 0;
            try
            {
                BD._sql = String.Format("INSERT INTO LOCATION (IDUSER, IDCOURT, DATE) VALUES ({0}, {1}, '{2}')" +
                                       "; SELECT SCOPE_IDENTITY();",
                                        iduser, idcourt, date.ToString("yyyy-MM-dd HH:mm:ss"));

                BD.ExecutaComando(false, out id);

                if (id > 0)
                {
                    MessageBox.Show("Localização cadastrada com sucesso!", "Cadastro com sucesso",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar localização", "Erro", MessageBoxButtons.OK,
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

        // Método para excluir uma localização
        public void Excluir()
        {
            try
            {
                int exOK = 0;
                BD._sql = "DELETE FROM LOCATION WHERE IDLOCATION = " + idlocation;
                exOK = BD.ExecutaComando(false);

                if (exOK == 1)
                {
                    MessageBox.Show("Localização deletada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao deletar localização", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para atualizar uma localização
        public void Atualizar()
        {
            try
            {
                int exOK = 0;
                BD._sql = "UPDATE LOCATION SET IDUSER = " + iduser + ", IDCOURT = " + idcourt + ", DATE = '" + date.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE IDLOCATION = " + idlocation;

                exOK = BD.ExecutaComando(false);

                if (exOK == 1)
                {
                    MessageBox.Show("Localização atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar localização", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para pesquisar localizações por usuário
        public DataTable PesquisaPorUsuario()
        {
            try
            {
                BD._sql = "SELECT * FROM LOCATION WHERE IDUSER = " + iduser;
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

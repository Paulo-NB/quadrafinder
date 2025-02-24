using QuadraFinder;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace QuadraFinder
{
    public class clQuadra
    {
        // Atributos
        public int idquadra;
        public string publicplace;
        public string zipcode;
        public string photos;
        public string type;
        public string name;
        public string state;
        public string city;
        public string neighborhood;
        public decimal preco;
        public bool alugado;
        public bool naoalugado;

        conectaBD BD = new conectaBD();

        // Método para salvar uma quadra
        public int Salvar()
        {
            int id = 0;
            try
            {
                BD._sql = String.Format(new CultureInfo("en-US"), "INSERT INTO QUADRA (PUBLICPLACE, ZIPCODE, PHOTOS, TYPE, NAME, STATE, CITY, NEIGHBORHOOD, PRECO, ALUGADO, NAOALUGADO) " +
                                       "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8}, {9}, {10})" +
                                       "; SELECT SCOPE_IDENTITY();",
                                        publicplace, zipcode, photos, type, name, state, city, neighborhood, preco, alugado ? 1 : 0, naoalugado ? 1 : 0);

                BD.ExecutaComando(false, out id);

                if (id > 0)
                {
                    MessageBox.Show("Quadra cadastrada com sucesso!", "Cadastro com sucesso",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar Quadra", "Erro", MessageBoxButtons.OK,
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

        // Método para excluir uma quadra
        public void Excluir()
        {
            try
            {
                int exOK = 0;
                BD._sql = "DELETE FROM QUADRA WHERE IDQUADRA = " + idquadra;
                exOK = BD.ExecutaComando(false);

                if (exOK == 1)
                {
                    MessageBox.Show("Quadra deletada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao deletar Quadra", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para atualizar uma quadra
        public void Atualizar()
        {
            try
            {
                int exOK = 0;
                BD._sql = "UPDATE QUADRA SET PUBLICPLACE = '" + publicplace + "', ZIPCODE = '" + zipcode + "', PHOTOS = '" + photos + "', TYPE = '" + type + "', NAME = '" + name + "', STATE = '" + state + "', CITY = '" + city + "', " +
                          "NEIGHBORHOOD = '" + neighborhood + "', PRECO = " + preco + ", ALUGADO = " + (alugado ? 1 : 0) + ", NAOALUGADO = " + (naoalugado ? 1 : 0) + " WHERE IDQUADRA = " + idquadra;

                exOK = BD.ExecutaComando(false);

                if (exOK == 1)
                {
                    MessageBox.Show("Quadra alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao alterar Quadra", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro.: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para pesquisar uma quadra pelo nome
        public DataTable PesquisaPorNome()
        {
            try
            {
                BD._sql = "SELECT * FROM QUADRA WHERE NAME LIKE '%" + name + "%'";
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

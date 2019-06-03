using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWSystems.modelo;
using MySql.Data.MySqlClient;

namespace HWSystems.Dao
{
    public class ClienteDao
    {
        public void Inserir(Cliente c)
        {
            String strConexaoCliente = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlCliente = "insert into tb_clientes" + "(nome_cliente, CPF_CNPJ, CNH, email_cliente, telefone_cliente) values" + "(@nome_cliente, @CPF_CNPJ, @CNH, @email_cliente, @telefone_cliente);";
            MySqlConnection conCliente = null;
            try
            {
                conCliente = new MySqlConnection(strConexaoCliente);
                conCliente.Open();
                MySqlCommand command = new MySqlCommand(sqlCliente, conCliente);
                
                command.Parameters.Add(new MySqlParameter("nome_cliente", c.nome));
                command.Parameters.Add(new MySqlParameter("CPF_CNPJ", c.CPF_CNPJ));
                command.Parameters.Add(new MySqlParameter("CNH", c.CNH));
                command.Parameters.Add(new MySqlParameter("email_cliente", c. email));
                command.Parameters.Add(new MySqlParameter("telefone_cliente", c.telefone));

                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Cliente cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (conCliente != null)
                    conCliente.Close();
            }
        }

        public void EditarTudo(Cliente c)
        {
            //Edita o nome
            String strConexaoNome = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlNome = "update tb_clientes set nome_cliente = @nome_cliente  where id_cliente =  @id_cliente;";
            MySqlConnection conNome = null;
            try
            {
                conNome = new MySqlConnection(strConexaoNome);
                conNome.Open();
                MySqlCommand command = new MySqlCommand(sqlNome, conNome);
                command.Parameters.Add(new MySqlParameter("id_cliente", c.id_cliente));
                command.Parameters.Add(new MySqlParameter("nome_cliente", c.nome));
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                if (conNome != null)
                    conNome.Close();
            }

            //Edita o CPF/CNPJ
            String strConexaoCPFCNPG = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlCPFCNPG = "update tb_clientes set CPF_CNPJ = @CPF_CNPJ  where id_cliente =  @id_cliente;";
            MySqlConnection conCPFCNPG = null;
            try
            {
                conNome = new MySqlConnection(strConexaoCPFCNPG);
                conNome.Open();
                MySqlCommand command = new MySqlCommand(sqlCPFCNPG, conCPFCNPG);
                command.Parameters.Add(new MySqlParameter("id_cliente", c.id_cliente));
                command.Parameters.Add(new MySqlParameter("nome_cliente", c.CPF_CNPJ));
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                if (conCPFCNPG != null)
                    conCPFCNPG.Close();
            }

            //Edita a CNH
            String strConexaoCNH = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlCNH = "update tb_clientes set CNH = @CNH  where id_cliente =  @id_cliente;";
            MySqlConnection conCNH = null;
            try
            {
                conCNH = new MySqlConnection(strConexaoCNH);
                conCNH.Open();
                MySqlCommand command = new MySqlCommand(sqlCNH, conCNH);
                command.Parameters.Add(new MySqlParameter("id_cliente", c.id_cliente));
                command.Parameters.Add(new MySqlParameter("CNH", c.CNH));
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                if (conCNH != null)
                    conCNH.Close();
            }

            //Edita o email
            String strConexaoEmail = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlEmail = "update tb_clientes set email_cliente = @email_cliente  where id_cliente =  @id_cliente;";
            MySqlConnection conEmail = null;
            try
            {
                conEmail = new MySqlConnection(strConexaoEmail);
                conEmail.Open();
                MySqlCommand command = new MySqlCommand(sqlEmail, conEmail);
                command.Parameters.Add(new MySqlParameter("id_cliente", c.id_cliente));
                command.Parameters.Add(new MySqlParameter("email_cliente", c.email));
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                if (conEmail != null)
                    conEmail.Close();
            }

            //Edita o telefone
            String strConexaoTelefone = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlTelefone = "update tb_clientes set telefone_cliente = @telefone_cliente  where id_cliente =  @id_cliente;";
            MySqlConnection conTelefone = null;
            try
            {
                conTelefone = new MySqlConnection(strConexaoTelefone);
                conTelefone.Open();
                MySqlCommand command = new MySqlCommand(sqlTelefone, conTelefone);
                command.Parameters.Add(new MySqlParameter("id_cliente", c.id_cliente));
                command.Parameters.Add(new MySqlParameter("telefone_cliente", c.telefone));
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                if (conTelefone != null)
                    conTelefone.Close();
            }
        }

        public void Excluir(Cliente c)
        {
            String strConexaoExcluir = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlExcluir = "update tb_clientes set fg_ativo = 0 where id_cliente =  @id_cliente;";
            MySqlConnection conExcluir = null;
            try
            {
                conExcluir = new MySqlConnection(strConexaoExcluir);
                conExcluir.Open();
                MySqlCommand command = new MySqlCommand(sqlExcluir, conExcluir);
                command.Parameters.Add(new MySqlParameter("id_cliente", c.id_cliente));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Cliente excluido com sucesso");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (conExcluir != null)
                    conExcluir.Close();
            }
        }
    }
}

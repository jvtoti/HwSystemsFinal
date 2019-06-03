using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using HWSystems;
using HWSystems.modelo;

namespace HWSystems.Dao
{
    public class FuncionarioDao
    {
        public void CadastrarFuncionario(Funcionario f)
        {
            String strConexaoFuncionario = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlFuncionario = "insert into tb_funcionarios" +"" + "(id_funcionario, nome_funcionario, CPF_funcionario, email_funcionario, telefone_funcionario, cargo, salario) values" + "(@id_funcionario, @nome_funcionario, @CPF_funcionario, @email_funcionario, @telefone_funcionario, @cargo, @salario);";
            MySqlConnection conFuncionario = null;
            try
            {
                conFuncionario = new MySqlConnection(strConexaoFuncionario);
                conFuncionario.Open();
                MySqlCommand command = new MySqlCommand(sqlFuncionario, conFuncionario);
                command.Parameters.Add(new MySqlParameter("id_funcionario", f.idFuncionario));
                command.Parameters.Add(new MySqlParameter("nome_funcionario", f.nome));
                command.Parameters.Add(new MySqlParameter("CPF_funcionario", f.CPF));
                command.Parameters.Add(new MySqlParameter("email_funcionario", f.email));
                command.Parameters.Add(new MySqlParameter("telefone_funcionario", f.telefone));
                command.Parameters.Add(new MySqlParameter("cargo", f.cargo));
                command.Parameters.Add(new MySqlParameter("salario", f.salario));

                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Funcionario cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (conFuncionario != null)
                    conFuncionario.Close();
            }
        }

        public void EditarTudoFuncionario(Funcionario f)
        {
            //Edita o nome
            String strConexaoNome = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlNome = "update tb_funcionarios set nome_funcionario = @nome_funcionario  where id_funcionario =  @id_funcionario;";
            MySqlConnection conNome = null;
            try
            {
                conNome = new MySqlConnection(strConexaoNome);
                conNome.Open();
                MySqlCommand command = new MySqlCommand(sqlNome, conNome);
                command.Parameters.Add(new MySqlParameter("id_funcionario", f.idFuncionario));
                command.Parameters.Add(new MySqlParameter("nome_funcionario", f.nome));
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

            //edita o CPF
            String strConexaoCPF = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlCPF = "update tb_funcionarios set CPF_funcionario = @CPF_funcionario  where id_funcionario =  @id_funcionario;";
            MySqlConnection conCPF = null;
            try
            {
                conCPF = new MySqlConnection(strConexaoCPF);
                conCPF.Open();
                MySqlCommand command = new MySqlCommand(sqlCPF, conCPF);
                command.Parameters.Add(new MySqlParameter("id_funcionario", f.idFuncionario));
                command.Parameters.Add(new MySqlParameter("CPF_funcionario", f.CPF));
                command.Prepare();
                command.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                if (conCPF != null)
                    conCPF.Close();
            }

            //edita o email
            String strConexaoEmail = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlEmail = "update tb_funcionarios set email_funcionario = @email_funcionario  where id_funcionario =  @id_funcionario;";
            MySqlConnection conEmail = null;
            try
            {
                conEmail = new MySqlConnection(strConexaoEmail);
                conEmail.Open();
                MySqlCommand command = new MySqlCommand(sqlEmail, conEmail);
                command.Parameters.Add(new MySqlParameter("id_funcionario", f.idFuncionario));
                command.Parameters.Add(new MySqlParameter("email_funcionario", f.email));
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

            //edita o telefone
            String strConexaoTelefone = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlTelefone = "update tb_funcionarios set telefone_funcionario = @telefone_funcionario  where id_funcionario =  @id_funcionario;";
            MySqlConnection conTelefone = null;
            try
            {
                conTelefone = new MySqlConnection(strConexaoTelefone);
                conTelefone.Open();
                MySqlCommand command = new MySqlCommand(sqlTelefone, conTelefone);
                command.Parameters.Add(new MySqlParameter("id_funcionario", f.idFuncionario));
                command.Parameters.Add(new MySqlParameter("telefone_funcionario", f.telefone));
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

            //edita o cargo
            String strConexaoCargo = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlCargo = "update tb_funcionarios set cargo = @cargo  where id_funcionario =  @id_funcionario;";
            MySqlConnection conCargo = null;
            try
            {
                conCargo = new MySqlConnection(strConexaoCargo);
                conCargo.Open();
                MySqlCommand command = new MySqlCommand(sqlCargo, conCargo);
                command.Parameters.Add(new MySqlParameter("id_funcionario", f.idFuncionario));
                command.Parameters.Add(new MySqlParameter("salario", f.salario));
                command.Prepare();
                command.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                if (conCargo != null)
                    conCargo.Close();
            }

            //edita o salario
            String strConexaoSalario = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlSalario = "update tb_funcionarios set salario = @salario  where id_funcionario =  @id_funcionario;";
            MySqlConnection conSalario = null;
            try
            {
                conSalario = new MySqlConnection(strConexaoSalario);
                conSalario.Open();
                MySqlCommand command = new MySqlCommand(sqlSalario, conSalario);
                command.Parameters.Add(new MySqlParameter("id_funcionario", f.idFuncionario));
                command.Parameters.Add(new MySqlParameter("salario", f.salario));
                command.Prepare();
                command.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                if (conSalario != null)
                    conSalario.Close();
            }
        }

        public void Excluir(Funcionario f)
        {
            String strConexaoExcluir = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlExcluir = "update tb_funcionarios set fg_ativo = 0 where id_funcionario =  @id_funcionario;";
            MySqlConnection conExcluir = null;
            try
            {
                conExcluir = new MySqlConnection(strConexaoExcluir);
                conExcluir.Open();
                MySqlCommand command = new MySqlCommand(sqlExcluir, conExcluir);
                command.Parameters.Add(new MySqlParameter("id_funcionario", f.idFuncionario));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Funcionario excluido com sucesso");
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

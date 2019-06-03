using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWSystems.modelo;
using MySql.Data.MySqlClient;

namespace HWSystems.Dao
{
    public class AluguelDao
    {
        public void Inserir(Aluguel a)
        {
            String strConexaoAluguel = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlAluguel = "insert into tb_alugueis" + "(id_veiculo, nome_cliente, data_saida, data_chegada, preco, status_aluguel) values" + "(@id_veiculo, @nome_cliente, @data_saida, @data_chegada, @preco, @status_aluguel);";
            MySqlConnection conAluguel = null;
            try
            {
                conAluguel = new MySqlConnection(strConexaoAluguel);
                conAluguel.Open();
                MySqlCommand command = new MySqlCommand(sqlAluguel, conAluguel);

                command.Parameters.Add(new MySqlParameter("id_veiculo", a.id_veiculo));
                command.Parameters.Add(new MySqlParameter("nome_cliente", a.nome));
                command.Parameters.Add(new MySqlParameter("data_saida", a.dataSaida));
                command.Parameters.Add(new MySqlParameter("data_chegada", a.dataChegada));
                command.Parameters.Add(new MySqlParameter("preco", a.preco));
                command.Parameters.Add(new MySqlParameter("status_aluguel", "em andamento"));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Aluguel feito com sucesso");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (conAluguel != null)
                    conAluguel.Close();
            }
        }

        public void EditarTudo(Aluguel a)
        {
            //Edita o id do veiculo
            String strConexaoVeiculo = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlVeiculo = "update tb_alugueis set id_veiculo = @id_veiculo  where id_aluguel =  @id_aluguel;";
            MySqlConnection conVeiculo = null;
            try
            {
                conVeiculo = new MySqlConnection(strConexaoVeiculo);
                conVeiculo.Open();
                MySqlCommand command = new MySqlCommand(sqlVeiculo, conVeiculo);
                command.Parameters.Add(new MySqlParameter("id_aluguel", a.idAluguel));
                command.Parameters.Add(new MySqlParameter("id_veiculo", a.id_veiculo));
                command.Prepare();
                command.ExecuteNonQuery();
                
            }
            catch
            {

            }
            finally
            {
                if (conVeiculo != null)
                    conVeiculo.Close();
            }

            //Edita o nome
            String strConexaoNome = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlNome = "update tb_alugueis set nome_cliente = @nome_cliente  where id_aluguel =  @id_aluguel;";
            MySqlConnection conNome = null;
            try
            {
                conNome = new MySqlConnection(strConexaoNome);
                conNome.Open();
                MySqlCommand command = new MySqlCommand(sqlNome, conNome);
                command.Parameters.Add(new MySqlParameter("id_aluguel", a.idAluguel));
                command.Parameters.Add(new MySqlParameter("nome_cliente", a.nome));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Atualizado com sucesso");
            }
            catch
            {

            }
            finally
            {
                if (conNome != null)
                    conNome.Close();
            }

            //Edita a saida
            String strConexaoSaida = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlSaida = "update tb_alugueis set data_saida = @data_saida  where id_aluguel =  @id_aluguel;";
            MySqlConnection conSaida = null;
            try
            {
                conSaida = new MySqlConnection(strConexaoSaida);
                conSaida.Open();
                MySqlCommand command = new MySqlCommand(sqlSaida, conSaida);
                command.Parameters.Add(new MySqlParameter("id_aluguel", a.idAluguel));
                command.Parameters.Add(new MySqlParameter("data_saida", a.dataSaida));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Atualizado com sucesso");
            }
            catch
            {

            }
            finally
            {
                if (conSaida != null)
                    conSaida.Close();
            }

            //Edita a entrada
            String strConexaoEntrada = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlEntrada = "update tb_alugueis set data_chegada = @data_chegada  where id_aluguel =  @id_aluguel;";
            MySqlConnection conEntrada = null;
            try
            {
                conEntrada = new MySqlConnection(strConexaoEntrada);
                conEntrada.Open();
                MySqlCommand command = new MySqlCommand(sqlEntrada, conEntrada);
                command.Parameters.Add(new MySqlParameter("id_aluguel", a.idAluguel));
                command.Parameters.Add(new MySqlParameter("data_chegada", a.dataChegada));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Atualizado com sucesso");
            }
            catch
            {

            }
            finally
            {
                if (conEntrada != null)
                    conEntrada.Close();
            }

            //Edita o preco
            String strConexaoPreco = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlPreco = "update tb_alugueis set data_entrada = @data_entrada  where id_aluguel =  @id_aluguel;";
            MySqlConnection conPreco = null;
            try
            {
                conPreco = new MySqlConnection(strConexaoPreco);
                conPreco.Open();
                MySqlCommand command = new MySqlCommand(sqlPreco, conPreco);
                command.Parameters.Add(new MySqlParameter("id_aluguel", a.idAluguel));
                command.Parameters.Add(new MySqlParameter("preco", a.preco));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Atualizado com sucesso");
            }
            catch
            {

            }
            finally
            {
                if (conEntrada != null)
                    conEntrada.Close();
            }
        }

        public void EditarStatustus(Aluguel a)
        {
            //Edita a entrada
            String strConexaoStatus = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlStatus = "update tb_alugueis set status_aluguel = @status_aluguel  where id_veiculo =  @id_veiculo;";
            MySqlConnection conStatus = null;
            try
            {
                conStatus = new MySqlConnection(strConexaoStatus);
                conStatus.Open();
                MySqlCommand command = new MySqlCommand(sqlStatus, conStatus);
                command.Parameters.Add(new MySqlParameter("id_veiculo", a.id_veiculo ));
                command.Parameters.Add(new MySqlParameter("status_aluguel", "Concluido"));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Atualizado com sucesso");
            }
            catch
            {

            }
            finally
            {
                if (conStatus != null)
                    conStatus.Close();
            }
        }

        public void Excluir(Aluguel a)
        {
            String strConexaoExcluirv = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlExcluirv = "update tb_alugueis set fg_ativo = 0 where id_aluguel =  @id_aluguel;";
            MySqlConnection conExcluirv = null;
            try
            {
                conExcluirv = new MySqlConnection(strConexaoExcluirv);
                conExcluirv.Open();
                MySqlCommand command = new MySqlCommand(sqlExcluirv, conExcluirv);
                command.Parameters.Add(new MySqlParameter("id_aluguel", a.idAluguel));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Aluguel excluido com sucesso");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (conExcluirv != null)
                    conExcluirv.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWSystems.modelo;
using MySql.Data.MySqlClient;

namespace HWSystems.Dao
{
    public class ViagemDao
    {
        public void InserirViagem(viagem vj)
        {
            String strConexaoViagem = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlViagem = "insert into tb_viagens" + "(id_veiculo, destino, data_saida, data_chegada, status_viagem) values" + "(@id_veiculo, @destino, @data_saida, @data_chegada, @status_viagem);";
            MySqlConnection conViagem = null;
            try
            {
                conViagem = new MySqlConnection(strConexaoViagem);
                conViagem.Open();
                MySqlCommand command = new MySqlCommand(sqlViagem, conViagem);
                command.Parameters.Add(new MySqlParameter("id_veiculo", vj.id_veiculo));
                command.Parameters.Add(new MySqlParameter("destino", vj.destino));
                command.Parameters.Add(new MySqlParameter("data_saida", vj.data_saida));
                command.Parameters.Add(new MySqlParameter("data_chegada", vj.data_chegada));
                command.Parameters.Add(new MySqlParameter("status_viagem", "Ativa"));
                
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Viagem Adicionada com sucesso");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (conViagem != null)
                    conViagem.Close();
            }
        }

        public void ExcluirViagens(viagem vj)
        {
            String strConexaoExcluirv = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlExcluirv = "delete from tb_viagens where id_viagem =  @id_viagem;";
            MySqlConnection conExcluirv = null;
            try
            {
                conExcluirv = new MySqlConnection(strConexaoExcluirv);
                conExcluirv.Open();
                MySqlCommand command = new MySqlCommand(sqlExcluirv, conExcluirv);
                command.Parameters.Add(new MySqlParameter("id_viagem", vj.idViagem));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Viagem excluida com sucesso");
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

        public void EditarViagem(viagem vj)
        {
            // Edita o id do veiculo
            String strConexaoPlaca = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlPlaca = "update tb_viagens set id_veiculo = @id_veiculo  where id_viagem =  @id_viagem;";
            MySqlConnection conPlaca = null;
            try
            {
                conPlaca = new MySqlConnection(strConexaoPlaca);
                conPlaca.Open();
                MySqlCommand command = new MySqlCommand(sqlPlaca, conPlaca);
                command.Parameters.Add(new MySqlParameter("id_viagem", vj.idViagem));
                command.Parameters.Add(new MySqlParameter("id_veiculo", vj.id_veiculo));
                command.Prepare();
                command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (conPlaca != null)
                    conPlaca.Close();
            }

            //edita o destino do veiculo
            String strConexaoModelo = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlModelo = "update tb_viagens set destino = @destino  where id_viagem =  @id_viagem;";
            MySqlConnection conModelo = null;
            try
            {
                conModelo = new MySqlConnection(strConexaoModelo);
                conModelo.Open();
                MySqlCommand command = new MySqlCommand(sqlModelo, conModelo);
                command.Parameters.Add(new MySqlParameter("id_viagem", vj.idViagem));
                command.Parameters.Add(new MySqlParameter("destino", vj.destino));
                command.Prepare();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (conModelo != null)
                    conModelo.Close();
            }

            // edita a data de saida
            String strConexaoMarca = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlMarca = "update tb_viagens set data_saida = @data_saida  where id_viagem =  @id_viagem;";
            MySqlConnection conMarca = null;
            try
            {
                conMarca = new MySqlConnection(strConexaoMarca);
                conMarca.Open();
                MySqlCommand command = new MySqlCommand(sqlMarca, conMarca);
                command.Parameters.Add(new MySqlParameter("id_viagem", vj.idViagem));
                command.Parameters.Add(new MySqlParameter("data_saida", vj.data_saida));
                command.Prepare();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (conModelo != null)
                    conModelo.Close();
            }

            //edita a data de chegada
            String strConexaoCor = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlCor = "update tb_viagens set data_chegada = @data_chegada  where id_viagem =  @id_viagem;";
            MySqlConnection conCor = null;
            try
            {
                conCor = new MySqlConnection(strConexaoCor);
                conCor.Open();
                MySqlCommand command = new MySqlCommand(sqlCor, conCor);
                command.Parameters.Add(new MySqlParameter("id_viagem", vj.idViagem));
                command.Parameters.Add(new MySqlParameter("data_chegada", vj.data_chegada));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Viagem Atualizada com sucesso");
            }
            catch
            {


            }
            finally
            {
                if (conModelo != null)
                    conModelo.Close();
            }

           
        }

        public void EditarStatusViagem(viagem vj)
        {
            // Edita o id do veiculo
            String strConexaoPlaca = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlPlaca = "update tb_viagens set status_viagem = @status_viagem  where id_viagem =  @id_viagem;";
            MySqlConnection conPlaca = null;
            try
            {
                conPlaca = new MySqlConnection(strConexaoPlaca);
                conPlaca.Open();
                MySqlCommand command = new MySqlCommand(sqlPlaca, conPlaca);
                command.Parameters.Add(new MySqlParameter("id_viagem", vj.idViagem));
                command.Parameters.Add(new MySqlParameter("status_viagem", "Concluida"));
                command.Prepare();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (conPlaca != null)
                    conPlaca.Close();
            }
        }
            
    }
}

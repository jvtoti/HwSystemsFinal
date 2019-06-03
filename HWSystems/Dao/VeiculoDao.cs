using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HWSystems.modelo;
using MySql.Data.MySqlClient;
using HWSystems;

namespace HWSystems.Dao
{
    public class VeiculoDao : ViagemDao
    {
        public void Inserir(Veiculo v)
        {
            String strConexao = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sql = "insert into tb_veiculos" + "(placa, modelo, marca, cor, ano_fabricacao, ano_modelo, quilometragem, status_veiculo) values" + "(@placa, @modelo, @marca, @cor, @ano_fabricacao, @ano_modelo, @quilometragem, @status_veiculo);";
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(strConexao);
                con.Open();
                MySqlCommand command = new MySqlCommand(sql, con);
                command.Parameters.Add(new MySqlParameter("placa", v.placa));
                command.Parameters.Add(new MySqlParameter("modelo", v.modelo));
                command.Parameters.Add(new MySqlParameter("marca", v.marca));
                command.Parameters.Add(new MySqlParameter("cor", v.Cor));
                command.Parameters.Add(new MySqlParameter("ano_fabricacao", v.ano_fabricacao));
                command.Parameters.Add(new MySqlParameter("ano_modelo", v.ano_modelo));
                command.Parameters.Add(new MySqlParameter("quilometragem", v.quilometragem));
                command.Parameters.Add(new MySqlParameter("status_veiculo", "Disponivel"));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Adicionado com sucesso");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (con != null)
                    con.Close();
            }

        }

        public void Editar(Veiculo v)
        {
            //Edita a placa
            String strConexaoPlaca = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlPlaca = "update tb_veiculos set placa = @placa  where id_veiculo =  @id_veiculo;";
            MySqlConnection conPlaca = null;
            try
            {
                conPlaca = new MySqlConnection(strConexaoPlaca);
                conPlaca.Open();
                MySqlCommand command = new MySqlCommand(sqlPlaca, conPlaca);
                command.Parameters.Add(new MySqlParameter("id_veiculo", v.idVeiculo));
                command.Parameters.Add(new MySqlParameter("placa", v.placa));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Atualizado com sucesso");
            }
            catch 
            {
                
            }
            finally
            {
                if (conPlaca != null)
                    conPlaca.Close();
            }

            //edita o modelo
            String strConexaoModelo = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlModelo = "update tb_veiculos set modelo = @modelo  where id_veiculo =  @id_veiculo;";
            MySqlConnection conModelo = null;
            try
            {
                conModelo = new MySqlConnection(strConexaoModelo);
                conModelo.Open();
                MySqlCommand command = new MySqlCommand(sqlModelo, conModelo);
                command.Parameters.Add(new MySqlParameter("id_veiculo", v.idVeiculo));
                command.Parameters.Add(new MySqlParameter("modelo", v.modelo));
                command.Prepare();
                command.ExecuteNonQuery();
                
            }
            catch
            {
                
            }
            finally
            {
                if (conModelo != null)
                    conModelo.Close();
            }

            // edita a marca
            String strConexaoMarca = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlMarca = "update tb_veiculos set marca = @marca  where id_veiculo =  @id_veiculo;";
            MySqlConnection conMarca = null;
            try
            {
                conMarca = new MySqlConnection(strConexaoMarca);
                conMarca.Open();
                MySqlCommand command = new MySqlCommand(sqlMarca, conMarca);
                command.Parameters.Add(new MySqlParameter("id_veiculo", v.idVeiculo));
                command.Parameters.Add(new MySqlParameter("marca", v.marca));
                command.Prepare();
                command.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                if (conModelo != null)
                    conModelo.Close();
            }

            //edita a cor
            String strConexaoCor = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlCor = "update tb_veiculos set Cor = @Cor  where id_veiculo =  @id_veiculo;";
            MySqlConnection conCor = null;
            try
            {
                conCor = new MySqlConnection(strConexaoCor);
                conCor.Open();
                MySqlCommand command = new MySqlCommand(sqlCor, conCor);
                command.Parameters.Add(new MySqlParameter("id_veiculo", v.idVeiculo));
                command.Parameters.Add(new MySqlParameter("cor", v.Cor));
                command.Prepare();
                command.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                if (conModelo != null)
                    conModelo.Close();
            }

            //edita o ano_fabricacao
            String strConexaoano_fabricacao = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlano_fabricacao = "update tb_veiculos set ano_fabricacao = @ano_fabricacao  where id_veiculo =  @id_veiculo;";
            MySqlConnection conano_fabricacao = null;
            try
            {
                conano_fabricacao = new MySqlConnection(strConexaoano_fabricacao);
                conano_fabricacao.Open();
                MySqlCommand command = new MySqlCommand(sqlano_fabricacao, conano_fabricacao);
                command.Parameters.Add(new MySqlParameter("id_veiculo", v.idVeiculo));
                command.Parameters.Add(new MySqlParameter("ano_fabricacao", v.ano_fabricacao));
                command.Prepare();
                command.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                if (conModelo != null)
                    conModelo.Close();
            }

            //edita o ano_modelo
            String strConexaoano_modelo = @"server=localhost;port=port=3306;database=hwsystemsData;userid=root;";
            String sqlano_modelo = "update tb_veiculos set ano_modelo = @ano_modelo  where id_veiculo =  @id_veiculo;";
            MySqlConnection conano_modelo = null;
            try
            {
                conano_modelo = new MySqlConnection(strConexaoano_modelo);
                conano_modelo.Open();
                MySqlCommand command = new MySqlCommand(sqlano_modelo, conano_modelo);
                command.Parameters.Add(new MySqlParameter("id_veiculo", v.idVeiculo));
                command.Parameters.Add(new MySqlParameter("ano_modelo", v.ano_modelo));
                command.Prepare();
                command.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                if (conModelo != null)
                    conModelo.Close();
            }

            //edita a quilometragem
            String strConexaoquilometragem = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlquilometragem = "update tb_veiculos set quilometragem = @quilometragem  where id_veiculo =  @id_veiculo;";
            MySqlConnection conquilometragem = null;
            try
            {
                conquilometragem = new MySqlConnection(strConexaoquilometragem);
                conquilometragem.Open();
                MySqlCommand command = new MySqlCommand(sqlquilometragem, conquilometragem);
                command.Parameters.Add(new MySqlParameter("id_veiculo", v.idVeiculo));
                command.Parameters.Add(new MySqlParameter("quilometragem", v.quilometragem));
                command.Prepare();
                command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
                System.Windows.Forms.MessageBox.Show("Atualizado com sucesso");
            }
            finally
            {
                if (conModelo != null)
                    conModelo.Close();
            }
        }
    
        public void excluir(Veiculo v)
        {
            String strConexaoExcluir = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlExcluir = "update tb_veiculos set fg_ativo = 0 where id_veiculo =  @id_veiculo;";
            MySqlConnection conExcluir = null;
            try
            {
                conExcluir = new MySqlConnection(strConexaoExcluir);
                conExcluir.Open();
                MySqlCommand command = new MySqlCommand(sqlExcluir, conExcluir);
                command.Parameters.Add(new MySqlParameter("id_veiculo", v.idVeiculo));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Veiculo excluido com sucesso");
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

        public void EditarStatusVeiculo(Veiculo v)
        {
            String strConexaostatus = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlstatus = "update tb_veiculos set status_veiculo = @status_veiculo  where id_veiculo =  @id_veiculo;";
            MySqlConnection constatus = null;
            try
            {
                constatus = new MySqlConnection(strConexaostatus);
                constatus.Open();
                MySqlCommand command = new MySqlCommand(sqlstatus, constatus);
                command.Parameters.Add(new MySqlParameter("id_veiculo", v.idVeiculo));
                command.Parameters.Add(new MySqlParameter("status_veiculo", "Em viagem"));
                command.Prepare();
                command.ExecuteNonQuery();
               
            }
            catch
            {

            }
            finally
            {
                if (constatus != null)
                    constatus.Close();
            }
        }

        public void EditarStatusVeiculo2(Veiculo v)
        {
            String strConexaostatus = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlstatus = "update tb_veiculos set status_veiculo = @status_veiculo  where id_veiculo =  @id_veiculo;";
            MySqlConnection constatus = null;
            try
            {
                constatus = new MySqlConnection(strConexaostatus);
                constatus.Open();
                MySqlCommand command = new MySqlCommand(sqlstatus, constatus);
                command.Parameters.Add(new MySqlParameter("id_veiculo", v.idVeiculo));
                command.Parameters.Add(new MySqlParameter("status_veiculo", "Disponivel"));
                command.Prepare();
                command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (constatus != null)
                    constatus.Close();
            }

            String strConexaostatusq = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            String sqlstatusq = "update tb_veiculos set quilometragem = @quilometragem  where id_veiculo =  @id_veiculo;";
            MySqlConnection constatusq = null;
            try
            {
                constatusq = new MySqlConnection(strConexaostatusq);
                constatusq.Open();
                MySqlCommand command = new MySqlCommand(sqlstatusq, constatusq);
                command.Parameters.Add(new MySqlParameter("id_veiculo", v.idVeiculo));
                command.Parameters.Add(new MySqlParameter("quilometragem", v.quilometragem));
                command.Prepare();
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Viagem concluida");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("ERROR" + ex.Message);
            }
            finally
            {
                if (constatusq != null)
                    constatusq.Close();
            }
        }
    }
    }


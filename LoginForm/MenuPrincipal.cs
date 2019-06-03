using HWSystems.Dao;
using HWSystems.modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginForm
{
    public partial class MenuPrincipal : MaterialSkin.Controls.MaterialForm
    {
        int idFunc;
        int idVeiculo;
        public MenuPrincipal()
        {
            InitializeComponent();

            // oculta as tabs Control
            gerenciarVeiculosTbc.Hide();
            gerenciaFuncionarioTbc.Hide();
            gerenciarclientesTbc.Hide();
            aluguelTbc.Hide();

            // Mensagenss de erro
            label19.Hide();
            erroMarcaLbl.Hide();
            erroModeloLbl.Hide();
            erroAnoFabricacaoLbl.Hide();
            erroAnoModeloLbl.Hide();
            erroQuilometragemLbl.Hide();
            erroCorLbl.Hide();




        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Mudar cor da barra de botões
            button1.BackColor = (Color.LightGray);
            gerenciarFuncionarioBtn.BackColor = (Color.Gray);
            gerenciarClienteBtn.BackColor = (Color.Gray);
            aluguelBtn.BackColor = (Color.Gray);

            // apagar imagem do logo da memoria
            pictureBox1.Dispose();

            //Gerenciando Tab controls
            gerenciarVeiculosTbc.Show();
            gerenciaFuncionarioTbc.Hide();
            gerenciarclientesTbc.Hide();
            aluguelTbc.Hide();

            //Mostrar e excluir botões principais

        }

        private void gerenciarFuncionarioBtn_Click(object sender, EventArgs e)
        {
            // Mudar cor da barra de botões
            button1.BackColor = (Color.Gray);
            gerenciarFuncionarioBtn.BackColor = (Color.LightGray);
            gerenciarClienteBtn.BackColor = (Color.Gray);
            aluguelBtn.BackColor = (Color.Gray);

            // apagar imagem do logo da memoria
            pictureBox1.Dispose();

            //Gerenciando Tab controls
            gerenciarVeiculosTbc.Hide();
            gerenciaFuncionarioTbc.Show();
            gerenciarFuncionarioTbc.Show();
            gerenciarclientesTbc.Hide();
            aluguelTbc.Hide();


        }

        private void gerenciarClienteBtn_Click(object sender, EventArgs e)
        {
            // Mudar cor da barra de botões
            button1.BackColor = (Color.Gray);
            gerenciarFuncionarioBtn.BackColor = (Color.Gray);
            gerenciarClienteBtn.BackColor = (Color.LightGray);
            aluguelBtn.BackColor = (Color.Gray);

            // apagar imagem do logo da memoria
            pictureBox1.Dispose();

            //Gerenciando Tab controls
            gerenciarVeiculosTbc.Hide();
            gerenciaFuncionarioTbc.Hide();
            gerenciarFuncionarioTbc.Hide();
            gerenciarclientesTbc.Show();
            aluguelTbc.Hide();


        }

        private void aluguelBtn_Click(object sender, EventArgs e)
        {
            // Mudar cor da barra de botões
            button1.BackColor = (Color.Gray);
            gerenciarFuncionarioBtn.BackColor = (Color.Gray);
            gerenciarClienteBtn.BackColor = (Color.Gray);
            aluguelBtn.BackColor = (Color.LightGray);

            // apagar imagem do logo da memoria
            pictureBox1.Dispose();

            //Gerenciando Tab controls
            gerenciarVeiculosTbc.Hide();
            gerenciaFuncionarioTbc.Hide();
            gerenciarFuncionarioTbc.Hide();
            gerenciarclientesTbc.Hide();
            aluguelTbc.Show();
        }

        private void fecharBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }



        // Cadastrar veiculo
        private void fazerCadastroBtn_Click(object sender, EventArgs e)
        {


            VeiculoDao veiculo = new VeiculoDao();
            Veiculo v = new Veiculo();


            v.Cor = corTbx.Text;
            v.placa = placaTbx.Text;
            v.marca = marcaTbx.Text;
            v.modelo = modeloTbx.Text;
            v.ano_fabricacao = Convert.ToInt32(anoFabricacaoTbx.Text);
            v.ano_modelo = Convert.ToInt32(anoModeloTbx.Text);
            v.quilometragem = Convert.ToDecimal(quilometragemTbx.Text);



            veiculo.Inserir(v);


            placaTbx.Text = String.Empty;
            corTbx.Text = String.Empty;
            marcaTbx.Text = String.Empty;
            modeloTbx.Text = String.Empty;
            anoFabricacaoTbx.Text = String.Empty;
            anoModeloTbx.Text = String.Empty;
            quilometragemTbx.Text = String.Empty;



        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void corCbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void placaTbx_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void veiculosDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        // botão para atualizar / carregar os veiculos
        private void button2_Click(object sender, EventArgs e)
        {

            // Carrega os veiculos
            String strConexao = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(strConexao);
                con.Open();
                String sql = ("select id_veiculo, placa, modelo, marca, cor, ano_fabricacao, ano_modelo, quilometragem, status_veiculo from tb_veiculos where fg_ativo = 1;");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader dados = cmd.ExecuteReader();
                if (dados.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dados);
                    veiculosDgv.DataSource = dt;
                }
                else
                {

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro" + erro);

            }
            finally
            {
                con.Close();
            }
        }

        private void veiculosDgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Centralizar os dados de algumas colunas
            /*
            veiculosDgv.Columns["placa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            veiculosDgv.Columns["modelo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            veiculosDgv.Columns["marca"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            veiculosDgv.Columns["quilometragem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            */

            // Manipular as colunas
            foreach (DataGridViewColumn coluna in veiculosDgv.Columns)
            {
                switch (coluna.Name)
                {
                    case "id_veiculo": // placa do veiculo
                        coluna.Width = 200;
                        //altera o titulo da coluna
                        coluna.HeaderText = "Numero de cadastro";
                        break;
                    case "placa": // placa do veiculo
                        coluna.Width = 80;
                        //altera o titulo da coluna
                        coluna.HeaderText = "Placa";
                        break;
                    case "modelo": // modelo do veiculo
                        coluna.Width = 80;
                        //altera o titulo da coluna
                        coluna.HeaderText = "Modelo";
                        break;
                    case "marca": // marca do veiculo
                        coluna.Width = 80;
                        //altera o titulo da coluna
                        coluna.HeaderText = "Marca";
                        break;
                    case "cor": // cor do veiculo
                        coluna.Width = 80;
                        //altera o titulo da coluna
                        coluna.HeaderText = "Cor";
                        break;
                    case "ano_fabricacao": // ano de fabricacao do veiculo
                        coluna.Width = 150;
                        //altera o titulo da coluna
                        coluna.HeaderText = "Ano de Fabricação";
                        break;
                    case "ano_modelo": // ano do modelo do veiculo
                        coluna.Width = 150;
                        //altera o titulo da coluna
                        coluna.HeaderText = "Ano do Modelo";
                        break;
                    case "quilometragem": // quilometragem do veiculo
                        coluna.Width = 150;
                        //altera o titulo da coluna
                        coluna.HeaderText = "Quilometragem";
                        break;
                    case "status_veiculo": // status do veiculo
                        coluna.Width = 80;
                        //altera o titulo da coluna
                        coluna.HeaderText = "Status";
                        break;
                    case "editar":
                        // alterar a ordem/posição
                        coluna.DisplayIndex = 8;
                        coluna.Width = 30;
                        break;
                    case "excluir":
                        // alterar a ordem/posição
                        coluna.DisplayIndex = 9;
                        coluna.Width = 30;
                        break;
                    default:
                        //ocultar a coluna
                        //coluna.Visible = false;
                        break;
                }
            }
        }

        private void veiculosDgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // adiciona o tooltip nas imagens do datagridview

            veiculosDgv.Rows[e.RowIndex].Cells["editar"].ToolTipText = "Clique aqui para editar";
            veiculosDgv.Rows[e.RowIndex].Cells["excluir"].ToolTipText = "Clique aqui para excluir";
        }

        private void veiculosDgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // pegar o id do veiculo
            int idFunc = Convert.ToInt32(veiculosDgv.Rows[e.RowIndex].Cells["id_veiculo"].Value.ToString());

            // verifica qual coluna foi clicada
            if (veiculosDgv.Columns[e.ColumnIndex] == veiculosDgv.Columns["editar"])
            {
                idVeiculoTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["id_veiculo"].Value.ToString();
                edPlacaTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["placa"].Value.ToString();
                edModeloTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["modelo"].Value.ToString();
                edMarcaTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["marca"].Value.ToString();
                edCorTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["cor"].Value.ToString();
                edAnoFabricacaoTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["ano_fabricacao"].Value.ToString();
                edAnoModeloTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["ano_modelo"].Value.ToString();
                edquilometragemTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["quilometragem"].Value.ToString();

                // coloca o foco na tab page ediçao
                gerenciarVeiculosTbc.SelectedIndex = 3;
                gerenciarVeiculosTbc.SelectedTab = tabPage3;
            }

            else if (veiculosDgv.Columns[e.ColumnIndex] == veiculosDgv.Columns["excluir"])
            {


                // confirmação de exclusão
                if (MessageBox.Show("Voce realmente deseja excluir ?", "Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {


                    idVeiculoTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["id_veiculo"].Value.ToString();
                    edPlacaTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["placa"].Value.ToString();
                    edModeloTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["modelo"].Value.ToString();
                    edMarcaTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["marca"].Value.ToString();
                    edCorTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["cor"].Value.ToString();
                    edAnoFabricacaoTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["ano_fabricacao"].Value.ToString();
                    edAnoModeloTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["ano_modelo"].Value.ToString();
                    edquilometragemTbx.Text = veiculosDgv.Rows[e.RowIndex].Cells["quilometragem"].Value.ToString();

                    // coloca o foco na tab page ediçao
                    gerenciarVeiculosTbc.SelectedTab = tabPage2;


                    VeiculoDao veiculo = new VeiculoDao();
                    Veiculo v = new Veiculo();

                    v.idVeiculo = Convert.ToInt32(idVeiculoTbx.Text);
                    v.Cor = edCorTbx.Text;
                    v.placa = edPlacaTbx.Text;
                    v.marca = edMarcaTbx.Text;
                    v.modelo = edModeloTbx.Text;
                    v.ano_fabricacao = Convert.ToInt32(edAnoFabricacaoTbx.Text);
                    v.ano_modelo = Convert.ToInt32(edAnoModeloTbx.Text);
                    v.quilometragem = Convert.ToDecimal(edquilometragemTbx.Text);
                    veiculo.excluir(v);
                }
                else
                {

                }


            }
        }

        // edita o veiculo
        private void button3_Click(object sender, EventArgs e)
        {
            VeiculoDao veiculo = new VeiculoDao();
            Veiculo v = new Veiculo();

            v.idVeiculo = Convert.ToInt32(idVeiculoTbx.Text);
            v.Cor = edCorTbx.Text;
            v.placa = edPlacaTbx.Text;
            v.marca = edMarcaTbx.Text;
            v.modelo = edModeloTbx.Text;
            v.ano_fabricacao = Convert.ToInt32(edAnoFabricacaoTbx.Text);
            v.ano_modelo = Convert.ToInt32(edAnoModeloTbx.Text);
            v.quilometragem = Convert.ToDecimal(edquilometragemTbx.Text);

            veiculo.Editar(v);

            edPlacaTbx.Text = String.Empty;
            edCorTbx.Text = String.Empty;
            edMarcaTbx.Text = String.Empty;
            edModeloTbx.Text = String.Empty;
            edAnoFabricacaoTbx.Text = String.Empty;
            edAnoModeloTbx.Text = String.Empty;
            edquilometragemTbx.Text = String.Empty;

            gerenciarVeiculosTbc.SelectedTab = tabPage2;
        }

        private void excluirVeiculoTbx_Click(object sender, EventArgs e)
        {

        }

        private void relatorioVeiculosBtn_Click(object sender, EventArgs e)
        {

        }

        // Cadastro de funcionario
        private void button4_Click(object sender, EventArgs e)
        {
            FuncionarioDao funcionario = new FuncionarioDao();
            Funcionario f = new Funcionario();

            f.nome = nomeFuncionarioTbx.Text;
            f.CPF = cpfFuncionarioTbx.Text;
            f.email = emailFuncionarioTbx.Text;
            f.telefone = telefoneFuncionarioTbx.Text;
            f.cargo = cargoFuncionarioTbx.Text;
            f.salario = Convert.ToDecimal(salarioTbx.Text);

            nomeFuncionarioTbx.Text = String.Empty;
            cpfFuncionarioTbx.Text = String.Empty;
            emailFuncionarioTbx.Text = String.Empty;
            telefoneFuncionarioTbx.Text = String.Empty;
            cargoFuncionarioTbx.Text = String.Empty;
            salarioTbx.Text = String.Empty;

            funcionario.CadastrarFuncionario(f);
        }

        private void funcionariosDgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        // atualizar / carregar funcionarios
        private void atualizarFuncionario_Click(object sender, EventArgs e)
        {
            // atualiza / carrega os funcionarios
            String strConexao = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(strConexao);
                con.Open();
                String sql = ("select id_funcionario, nome_funcionario, CPF_funcionario, email_funcionario, telefone_funcionario, cargo, salario from tb_funcionarios where fg_ativo = 1;");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader dados = cmd.ExecuteReader();
                if (dados.HasRows)
                {
                    DataTable dtfuncionario = new DataTable();
                    dtfuncionario.Load(dados);
                    funcionariosDgv.DataSource = dtfuncionario;
                }
                else
                {

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro" + erro);

            }
            finally
            {
                con.Close();
            }
        }

        // relatório dos funcionarios
        private void button6_Click(object sender, EventArgs e)
        {
            RelatorioFuncionario relatorioFuncionario = new RelatorioFuncionario();
            relatorioFuncionario.ShowDialog();
        }

        // atualiza o funcionario
        private void button5_Click(object sender, EventArgs e)
        {
            FuncionarioDao funcionario = new FuncionarioDao();
            Funcionario f = new Funcionario();

            f.idFuncionario = Convert.ToInt32(edIdFuncionarioTbx.Text);
            f.nome = edNomeFuncionarioTbx.Text;
            f.CPF = edCpfFuncionarioTbx.Text;
            f.email = edEmailFuncionarioTbx.Text;
            f.telefone = edTelefoneFuncionarioTbx.Text;
            f.cargo = edCargoFuncionarioTbx.Text;
            f.salario = Convert.ToDecimal(edSalarioFuncionarioTbx.Text);

            funcionario.EditarTudoFuncionario(f);

            edNomeFuncionarioTbx.Text = String.Empty;
            edCpfFuncionarioTbx.Text = String.Empty;
            edEmailFuncionarioTbx.Text = String.Empty;
            edTelefoneFuncionarioTbx.Text = String.Empty;
            edCargoFuncionarioTbx.Text = String.Empty;
            edSalarioFuncionarioTbx.Text = String.Empty;

            gerenciaFuncionarioTbc.SelectedTab = funcionarios;
        }

        private void marcaTbx_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(placaTbx.Text))
                label19.Show();
            else
                label19.Hide();
        }

        private void modeloTbx_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(placaTbx.Text) && string.IsNullOrEmpty(marcaTbx.Text))
            {
                label19.Show();
                erroMarcaLbl.Show();
            }
            else
            {
                label19.Hide();
                erroMarcaLbl.Hide();
            }

        }

        private void anoFabricacaoTbx_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(placaTbx.Text) && string.IsNullOrEmpty(marcaTbx.Text) && string.IsNullOrEmpty(modeloTbx.Text))
            {
                label19.Show();
                erroMarcaLbl.Show();
                erroModeloLbl.Show();
            }
            else
            {
                label19.Hide();
                erroMarcaLbl.Hide();
                erroModeloLbl.Hide();
            }
        }

        private void anoModeloTbx_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(placaTbx.Text) && string.IsNullOrEmpty(marcaTbx.Text) && string.IsNullOrEmpty(modeloTbx.Text) && string.IsNullOrEmpty(anoFabricacaoTbx.Text))
            {
                label19.Show();
                erroMarcaLbl.Show();
                erroModeloLbl.Show();
                erroAnoFabricacaoLbl.Show();
            }
            else
            {
                label19.Hide();
                erroMarcaLbl.Hide();
                erroModeloLbl.Hide();
                erroAnoFabricacaoLbl.Show();
            }
        }

        private void quilometragemTbx_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(placaTbx.Text) && string.IsNullOrEmpty(marcaTbx.Text) && string.IsNullOrEmpty(modeloTbx.Text) && string.IsNullOrEmpty(anoFabricacaoTbx.Text) && string.IsNullOrEmpty(anoModeloTbx.Text))
            {
                label19.Show();
                erroMarcaLbl.Show();
                erroModeloLbl.Show();
                erroAnoFabricacaoLbl.Show();
                erroAnoModeloLbl.Show();
            }
            else
            {
                label19.Hide();
                erroMarcaLbl.Hide();
                erroModeloLbl.Hide();
                erroAnoFabricacaoLbl.Hide();
                erroAnoModeloLbl.Hide();
            }
        }

        private void corTbx_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(placaTbx.Text) && string.IsNullOrEmpty(marcaTbx.Text) && string.IsNullOrEmpty(modeloTbx.Text) && string.IsNullOrEmpty(anoFabricacaoTbx.Text) && string.IsNullOrEmpty(anoModeloTbx.Text) && string.IsNullOrEmpty(quilometragemTbx.Text))
            {
                label19.Show();
                erroMarcaLbl.Show();
                erroModeloLbl.Show();
                erroAnoFabricacaoLbl.Show();
                erroAnoModeloLbl.Show();
                erroQuilometragemLbl.Show();
            }
            else
            {
                label19.Hide();
                erroMarcaLbl.Hide();
                erroModeloLbl.Hide();
                erroAnoFabricacaoLbl.Hide();
                erroAnoModeloLbl.Hide();
                erroQuilometragemLbl.Hide();
            }
        }

        private void cadastroClienteBtn_Click(object sender, EventArgs e)
        {
            ClienteDao cliente = new ClienteDao();
            Cliente c = new Cliente();

            c.nome = nomeClienteTbx.Text;
            c.CPF_CNPJ = cpf_cnpjClienteTbx.Text;
            c.CNH = cnhClienteTbx.Text;
            c.email = emailClienteTbx.Text;
            c.telefone = telefoneclienteTbx.Text;

            cliente.Inserir(c);

            nomeClienteTbx.Text = String.Empty;
            cpf_cnpjClienteTbx.Text = String.Empty;
            cnhClienteTbx.Text = String.Empty;
            emailClienteTbx.Text = String.Empty;
            telefoneclienteTbx.Text = String.Empty;
        }

        // atualiza a edição do cliente
        private void atualizarClienteBtn_Click(object sender, EventArgs e)
        {
            ClienteDao cliente = new ClienteDao();
            Cliente c = new Cliente();

            c.id_cliente = Convert.ToInt32 (idClienteTbx.Text);
            c.nome = edNomeClienteTbx.Text;
            c.CPF_CNPJ = edCpf_cnpjClienteTbx.Text;
            c.CNH = edCnhTbx.Text;
            c.email = edEmailClienteTbx.Text;
            c.telefone = edTelefoneClienteTbx.Text;

            cliente.EditarTudo(c);

            edNomeClienteTbx.Text = String.Empty;
            edCpf_cnpjClienteTbx.Text = String.Empty;
            edCnhTbx.Text = String.Empty;
            edEmailClienteTbx.Text = String.Empty;
            edTelefoneClienteTbx.Text = String.Empty;

            
        }

        // atualiza pagina que exibe os clientes
        private void atualizarpaginaClientesBtn_Click(object sender, EventArgs e)
        {
            // Carrega os clientes
            String strConexao = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(strConexao);
                con.Open();
                String sql = ("select id_cliente, nome_cliente, CPF_CNPJ, CNH, email_cliente, telefone_cliente from tb_clientes where fg_ativo = 1;");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader dados = cmd.ExecuteReader();
                if (dados.HasRows)
                {
                    DataTable dtCliente = new DataTable();
                    dtCliente.Load(dados);
                    clientesDgv.DataSource = dtCliente;
                }
                else
                {

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro" + erro);

            }
            finally
            {
                con.Close();
            }
        }

        private void orcamentoBtn_Click(object sender, EventArgs e)
        {
            Orcamento orcamento = new Orcamento();
            orcamento.ShowDialog();
        }

        private void alugarBtn_Click(object sender, EventArgs e)
        {
            AluguelDao aluguel = new AluguelDao();
            Aluguel a = new Aluguel();

            a.id_veiculo = Convert.ToInt32(idVeiculoAluguelTbx.Text);
            a.nome = nomeClienteAluguelTbx.Text;
            a.dataSaida = Convert.ToString(dataSaidaAluguelTbx.Value.ToShortDateString());
            a.dataChegada = Convert.ToString(dataChegadaAluguelTbx.Value.ToShortDateString());
            a.preco = Convert.ToDecimal(taxaTbx.Text);
           

            aluguel.Inserir(a);

            gerenciarVeiculosTbc.Show();

            // muda a cor da barra principal
            button1.BackColor = (Color.LightGray);
            aluguelBtn.BackColor = (Color.Gray);

            gerenciarVeiculosTbc.SelectedIndex = 4;
            gerenciarVeiculosTbc.SelectedTab = tabPage4;

            
            aluguelTbc.Hide();

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void cadstrarViagemBtn_Click(object sender, EventArgs e)
        {

            ViagemDao Viagem = new ViagemDao();
            viagem vj = new viagem();

            vj.id_veiculo = Convert.ToInt32(id_veiculoTbx.Text);
            vj.destino = destinoTbx.Text;
            vj.data_saida = Convert.ToString(dataSaidaViagemDtp.Value.ToShortDateString());
            vj.data_chegada = Convert.ToString(dataChegadaViagemDtp.Value.ToShortDateString());


            //veiculo.Inserir(v);
            Viagem.InserirViagem(vj);



            VeiculoDao veiculo = new VeiculoDao();
            Veiculo v = new Veiculo();


            v.idVeiculo = Convert.ToInt32(PegarIdVeiculoTbx.Text);



            veiculo.EditarStatusVeiculo(v);

            id_veiculoTbx.Text = String.Empty;
            destinoTbx.Text = String.Empty;
            

        }

        private void viagensDgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn colunav in viagensDgv.Columns)
            {
                switch (colunav.Name)
                {
                    case "id_viagem": // id da viagem
                        colunav.Width = 200;
                        //altera o titulo da coluna
                        colunav.HeaderText = "Numero do protocolo";
                        break;
                    case "id_veiculo": // id do veiculo
                        colunav.Width = 150;
                        //altera o titulo da coluna
                        colunav.HeaderText = "Id do veiculo";
                        break;
                    case "destino": // destino da viagem
                        colunav.Width = 100;
                        //altera o titulo da coluna
                        colunav.HeaderText = "Destino";
                        break;
                    case "data_saida": // data de saida
                        colunav.Width = 150;
                        //altera o titulo da coluna
                        colunav.HeaderText = "Data da Saida";
                        break;
                    case "data_chegada": // data da chegada
                        colunav.Width = 150;
                        //altera o titulo da coluna
                        colunav.HeaderText = "Data de chegada";
                        break;
                    case "status_viagem": // status viagem
                        colunav.Width = 80;
                        //altera o titulo da coluna
                        colunav.HeaderText = "Status";
                        break;
                    case "editarviagem":
                        // alterar a ordem/posição
                        colunav.DisplayIndex = 6;
                        colunav.Width = 30;
                        break;
                    case "excluirviagem":
                        // alterar a ordem/posição
                        colunav.DisplayIndex = 7;
                        colunav.Width = 30;
                        break;
                    default:
                        //ocultar a coluna
                        //coluna.Visible = false;
                        break;
                }
            }

        }

        private void viagensDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // pegar o id da viagem
            int idVeiculo = Convert.ToInt32(viagensDgv.Rows[e.RowIndex].Cells["id_viagem"].Value.ToString());

            // verifica qual coluna foi clicada
            if (viagensDgv.Columns[e.ColumnIndex] == viagensDgv.Columns["editarviagem"])
            {
                idViagemTbx.Text = viagensDgv.Rows[e.RowIndex].Cells["id_viagem"].Value.ToString();
                edId_veiculoTbx.Text = viagensDgv.Rows[e.RowIndex].Cells["id_veiculo"].Value.ToString();
                edDestinoTbx.Text = viagensDgv.Rows[e.RowIndex].Cells["destino"].Value.ToString();
                edDataSaidaTbx.Text = viagensDgv.Rows[e.RowIndex].Cells["data_saida"].Value.ToString();
                edDataChegadaTbx.Text = viagensDgv.Rows[e.RowIndex].Cells["data_chegada"].Value.ToString();


                // coloca o foco na tab page ediçao
                gerenciarVeiculosTbc.SelectedIndex = 1;
                gerenciarVeiculosTbc.SelectedTab = tabPage1;
            }

            else if (viagensDgv.Columns[e.ColumnIndex] == viagensDgv.Columns["excluirviagem"])
            {


                // confirmação de exclusão
                if (MessageBox.Show("Voce realmente deseja excluir ?", "Viagens", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {


                    idViagemTbx.Text = viagensDgv.Rows[e.RowIndex].Cells["id_viagem"].Value.ToString();
                    edId_veiculoTbx.Text = viagensDgv.Rows[e.RowIndex].Cells["id_veiculo"].Value.ToString();
                    edDestinoTbx.Text = viagensDgv.Rows[e.RowIndex].Cells["destino"].Value.ToString();
                    edDataSaidaTbx.Text = viagensDgv.Rows[e.RowIndex].Cells["data_saida"].Value.ToString();
                    edDataChegadaTbx.Text = viagensDgv.Rows[e.RowIndex].Cells["data_chegada"].Value.ToString();

                    // coloca o foco na tab page ediçao
                    gerenciarVeiculosTbc.SelectedTab = tabPage1;


                    ViagemDao Viagem = new ViagemDao();
                    viagem vj = new viagem();

                    vj.idViagem = Convert.ToInt32(idViagemTbx.Text);
                    vj.id_veiculo = Convert.ToInt32(edId_veiculoTbx.Text);
                    vj.destino = edDestinoTbx.Text;
                    vj.data_saida = edDataSaidaTbx.Text;
                    vj.data_chegada = edDataChegadaTbx.Text;

                    Viagem.ExcluirViagens(vj);
                }
                else
                {

                }
            }
        }

        private void SalvarBtn_Click(object sender, EventArgs e)
        {
            ViagemDao Viagem = new ViagemDao();
            viagem vj = new viagem();

            vj.idViagem = Convert.ToInt32(idViagemTbx.Text);
            vj.id_veiculo = Convert.ToInt32(edId_veiculoTbx.Text);
            vj.destino = edDestinoTbx.Text;
            vj.data_saida = edDataSaidaTbx.Text;
            vj.data_chegada = edDataChegadaTbx.Text;

            Viagem.EditarViagem(vj);

            idViagemTbx.Text = String.Empty;
            edId_veiculoTbx.Text = String.Empty;
            edDestinoTbx.Text = String.Empty;
            edDataSaidaTbx.Text = String.Empty;
            edDataChegadaTbx.Text = String.Empty;
        }

        private void id_veiculoTbx_TextChanged(object sender, EventArgs e)
        {
            PegarIdVeiculoTbx.Text = id_veiculoTbx.Text;
        }

        // botão para atualizar / carregar as viagens
        private void atualizarViagemBtn_Click(object sender, EventArgs e)
        {
            //exibe as viagens
            String strConexaoViagem = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            MySqlConnection conViagem = null;
            try
            {
                conViagem = new MySqlConnection(strConexaoViagem);
                conViagem.Open();
                String sqlViagem = ("select id_viagem, id_veiculo, destino, data_saida, data_chegada, status_viagem from tb_viagens;");
                MySqlCommand cmd = new MySqlCommand(sqlViagem, conViagem);
                MySqlDataReader dados = cmd.ExecuteReader();
                if (dados.HasRows)
                {
                    DataTable dtv = new DataTable();
                    dtv.Load(dados);
                    viagensDgv.DataSource = dtv;
                }
                else
                {

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro" + erro);

            }
            finally
            {
                conViagem.Close();
            }

            gerenciarVeiculosTbc.SelectedTab = tabPage1;
        }

        private void confirmarChegadaBtn_Click(object sender, EventArgs e)
        {
            VeiculoDao veiculo = new VeiculoDao();
            Veiculo v = new Veiculo();

            v.idVeiculo = Convert.ToInt32(nCadastroVeiculoTbx.Text);
            v.quilometragem = Convert.ToDecimal(quilometragematualTbx.Text);

            veiculo.EditarStatusVeiculo2(v);

            ViagemDao Viagem = new ViagemDao();
            viagem vj = new viagem();

            vj.idViagem = Convert.ToInt32(protocoloViagemTbx.Text);

            Viagem.EditarStatusViagem(vj);

            AluguelDao aluguel = new AluguelDao();
            Aluguel a = new Aluguel();

            a.id_veiculo = Convert.ToInt32(nCadastroVeiculoTbx.Text);
            aluguel.EditarStatustus(a);

            nCadastroVeiculoTbx.Text = String.Empty;
            quilometragematualTbx.Text = String.Empty;
            protocoloViagemTbx.Text = String.Empty;

            gerenciarVeiculosTbc.SelectedTab = tabPage1;
        }

        private void edMarcaTbx_TextChanged(object sender, EventArgs e)
        {

        }

        // formatando a datagridview que exibe os funcionarios
        private void funcionariosDgv_DataBindingComplete_1(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn colunaf in funcionariosDgv.Columns)
            {
                switch (colunaf.Name)
                {
                    case "id_funcionario": // id do funcionario
                        colunaf.Width = 150;
                        //altera o titulo da coluna
                        colunaf.HeaderText = "N° de cadastro";
                        break;
                    case "nome_funcionario": // nome do funcionario
                        colunaf.Width = 200;
                        //altera o titulo da coluna
                        colunaf.HeaderText = "Nome";
                        break;
                    case "CPF_funcionario": // CPF do funcionario
                        colunaf.Width = 100;
                        //altera o titulo da coluna
                        colunaf.HeaderText = "CPF";
                        break;
                    case "email_funcionario": // email do funcionario
                        colunaf.Width = 180;
                        //altera o titulo da coluna
                        colunaf.HeaderText = "E-mail";
                        break;
                    case "telefone_funcionario": // telefone do funcionario
                        colunaf.Width = 100;
                        //altera o titulo da coluna
                        colunaf.HeaderText = "Telefone";
                        break;
                    case "cargo": // cargo do funcionario
                        colunaf.Width = 100;
                        //altera o titulo da coluna
                        colunaf.HeaderText = "Cargo";
                        break;
                    case "Salario": // salario do funcionario
                        colunaf.Width = 80;
                        //altera o titulo da coluna
                        colunaf.HeaderText = "Salario";
                        break;
                    case "editarFuncionario":
                        // alterar a ordem/posição
                        colunaf.DisplayIndex = 7;
                        colunaf.Width = 30;
                        break;
                    case "excluirFuncionario":
                        // alterar a ordem/posição
                        colunaf.DisplayIndex = 8;
                        colunaf.Width = 30;
                        break;
                    default:
                        //ocultar a coluna
                        //coluna.Visible = false;
                        break;
                }
            }
        }

        private void funcionariosDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // pegar o id do funcionario
            int idFuncionario = Convert.ToInt32(funcionariosDgv.Rows[e.RowIndex].Cells["id_funcionario"].Value.ToString());

            // verifica qual coluna foi clicada
            if (funcionariosDgv.Columns[e.ColumnIndex] == funcionariosDgv.Columns["editarFuncionario"])
            {
                edIdFuncionarioTbx.Text = funcionariosDgv.Rows[e.RowIndex].Cells["id_funcionario"].Value.ToString();
                edNomeFuncionarioTbx.Text = funcionariosDgv.Rows[e.RowIndex].Cells["nome_funcionario"].Value.ToString();
                edCpfFuncionarioTbx.Text = funcionariosDgv.Rows[e.RowIndex].Cells["CPF_funcionario"].Value.ToString();
                edEmailFuncionarioTbx.Text = funcionariosDgv.Rows[e.RowIndex].Cells["email_funcionario"].Value.ToString();
                edTelefoneFuncionarioTbx.Text = funcionariosDgv.Rows[e.RowIndex].Cells["telefone_funcionario"].Value.ToString();
                edCargoFuncionarioTbx.Text = funcionariosDgv.Rows[e.RowIndex].Cells["cargo"].Value.ToString();
                edSalarioFuncionarioTbx.Text = funcionariosDgv.Rows[e.RowIndex].Cells["salario"].Value.ToString();


                // coloca o foco na tab page ediçao

                gerenciaFuncionarioTbc.SelectedTab = tabPage6;
            }

            else if (funcionariosDgv.Columns[e.ColumnIndex] == funcionariosDgv.Columns["excluirFuncionario"])
            {


                // confirmação de exclusão
                if (MessageBox.Show("Voce realmente deseja excluir ?", "Funcionarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {


                    edIdFuncionarioTbx.Text = funcionariosDgv.Rows[e.RowIndex].Cells["id_funcionario"].Value.ToString();
                    

                    // coloca o foco na tab page ediçao
                    gerenciaFuncionarioTbc.SelectedTab = funcionarios;


                    FuncionarioDao funcionario = new FuncionarioDao();
                    Funcionario f = new Funcionario();

                    f.idFuncionario = Convert.ToInt32(edIdFuncionarioTbx.Text);


                    funcionario.Excluir(f);
                }
                else
                {

                }
            }
        }

        // formatando a datagridview que exibe os clientes
        private void clientesDgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn colunac in clientesDgv.Columns)
            {
                switch (colunac.Name)
                {
                    case "id_cliente": // id do cliente
                        colunac.Width = 150;
                        //altera o titulo da coluna
                        colunac.HeaderText = "N° de cadastro";
                        break;
                    case "nome_cliente": // nome do cliente
                        colunac.Width = 200;
                        //altera o titulo da coluna
                        colunac.HeaderText = "Nome";
                        break;
                    case "CPF_CNPJ": // CPF/CNPJ do cliente
                        colunac.Width = 100;
                        //altera o titulo da coluna
                        colunac.HeaderText = "CPF/CNPJ";
                        break;
                    case "email_cliente": // email do cliente
                        colunac.Width = 180;
                        //altera o titulo da coluna
                        colunac.HeaderText = "E-mail";
                        break;
                    case "telefone_cliente": // telefone do cliente
                        colunac.Width = 100;
                        //altera o titulo da coluna
                        colunac.HeaderText = "Telefone";
                        break;
                    case "editarCliente":
                        // alterar a ordem/posição
                        colunac.DisplayIndex = 6;
                        colunac.Width = 30;
                        break;
                    case "excluirCliente":
                        // alterar a ordem/posição
                        colunac.DisplayIndex = 7;
                        colunac.Width = 30;
                        break;
                    default:
                        
                        break;
                }
            }
        }

        private void clientesDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // pegar o id do cliente
            int idCliente = Convert.ToInt32(clientesDgv.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString());

            // verifica qual coluna foi clicada
            if (clientesDgv.Columns[e.ColumnIndex] == clientesDgv.Columns["editarCliente"])
            {
                idClienteTbx.Text = clientesDgv.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString();
                edNomeClienteTbx.Text = clientesDgv.Rows[e.RowIndex].Cells["nome_cliente"].Value.ToString();
                edCpf_cnpjClienteTbx.Text = clientesDgv.Rows[e.RowIndex].Cells["CPF_CNPJ"].Value.ToString();
                edCnhTbx.Text = clientesDgv.Rows[e.RowIndex].Cells["CNH"].Value.ToString();
                edEmailClienteTbx.Text = clientesDgv.Rows[e.RowIndex].Cells["email_cliente"].Value.ToString();
                edTelefoneClienteTbx.Text = clientesDgv.Rows[e.RowIndex].Cells["telefone_cliente"].Value.ToString();


                // coloca o foco na tab page ediçao

                gerenciarclientesTbc.SelectedTab = tabPage7;
            }

            else if (clientesDgv.Columns[e.ColumnIndex] == clientesDgv.Columns["excluirCliente"])
            {


                // confirmação de exclusão
                if (MessageBox.Show("Voce realmente deseja excluir ?", "Clintes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {


                    idClienteTbx.Text = clientesDgv.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString();

                    ClienteDao cliente = new ClienteDao();
                    Cliente c = new Cliente();

                    c.id_cliente = Convert.ToInt32(idClienteTbx.Text);


                    cliente.Excluir(c);
                }
                else
                {

                }
            }
        }

        private void nomeClienteAluguelTbx_TextChanged(object sender, EventArgs e)
        {

        }

        private void idVeiculoAluguelTbx_TextChanged(object sender, EventArgs e)
        {
            id_veiculoTbx.Text = idVeiculoAluguelTbx.Text;
        }

        private void dataSaidaAluguelTbx_ValueChanged(object sender, EventArgs e)
        {
            dataSaidaViagemDtp.Value = dataSaidaAluguelTbx.Value;
        }

        private void dataChegadaAluguelTbx_ValueChanged(object sender, EventArgs e)
        {
            dataChegadaViagemDtp.Value = dataChegadaAluguelTbx.Value;
        }

        // atualiza os alugueis
        private void button8_Click(object sender, EventArgs e)
        {
            // Carrega os alugueis
            String strConexao = @"server=localhost;port=3306;database=hwsystemsData;userid=root;";
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(strConexao);
                con.Open();
                String sql = ("select id_aluguel, id_veiculo, nome_cliente, data_saida, data_chegada, preco, status_aluguel from tb_alugueis where fg_ativo = 1;");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader dados = cmd.ExecuteReader();
                if (dados.HasRows)
                {
                    DataTable dtAluguel = new DataTable();
                    dtAluguel.Load(dados);
                    alugueisDgv.DataSource = dtAluguel;
                }
                else
                {

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro" + erro);

            }
            finally
            {
                con.Close();
            }
        }

        private void alugueisDgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn colunaa in alugueisDgv.Columns)
            {
                switch (colunaa.Name)
                {
                    case "id_aluguel": // id do aluguel
                        colunaa.Width = 150;
                        //altera o titulo da coluna
                        colunaa.HeaderText = "N° de protocolo";
                        break;
                    case "id_veiculo": // id do veiculo
                        colunaa.Width = 200;
                        //altera o titulo da coluna
                        colunaa.HeaderText = "N° do veiculo";
                        break;
                    case "nome_cliente": // nome do cliente
                        colunaa.Width = 200;
                        //altera o titulo da coluna
                        colunaa.HeaderText = "Nome do cliente";
                        break;
                    case "data_saida": // data de saida do aluguel
                        colunaa.Width = 200;
                        //altera o titulo da coluna
                        colunaa.HeaderText = "Saida";
                        break;
                    case "data_chegada": // data de chegado do aluguel
                        colunaa.Width = 200;
                        //altera o titulo da coluna
                        colunaa.HeaderText = "Entrada";
                        break;
                    case "preco": // preco do aluguel
                        colunaa.Width = 100;
                        //altera o titulo da coluna
                        colunaa.HeaderText = "Preco";
                        break;
                    case "status_aluguel": // preco do aluguel
                        colunaa.Width = 100;
                        //altera o titulo da coluna
                        colunaa.HeaderText = "Status";
                        break;
                    case "editarAluguel":
                        // alterar a ordem/posição
                        colunaa.DisplayIndex = 7;
                        colunaa.Width = 30;
                        break;
                    case "excluirAluguel":
                        // alterar a ordem/posição
                        colunaa.DisplayIndex = 8;
                        colunaa.Width = 30;
                        break;
                    default:

                        break;
                }
            }
        }

        private void alugueisDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // pegar o id do aluguel
            int idAluguel = Convert.ToInt32(alugueisDgv.Rows[e.RowIndex].Cells["id_aluguel"].Value.ToString());

            // verifica qual coluna foi clicada
            if (alugueisDgv.Columns[e.ColumnIndex] == alugueisDgv.Columns["editarAluguel"])
            {
                idAluguelTbx.Text = alugueisDgv.Rows[e.RowIndex].Cells["id_aluguel"].Value.ToString();
                edIdVeiculoAluguelTbx.Text = alugueisDgv.Rows[e.RowIndex].Cells["id_veiculo"].Value.ToString();
                edIdFuncionarioAluguelTbx.Text = alugueisDgv.Rows[e.RowIndex].Cells["nome_cliente"].Value.ToString();
  
                edTaxaTbx.Text = alugueisDgv.Rows[e.RowIndex].Cells["preco"].Value.ToString();


                // coloca o foco na tab page ediçao

                aluguelTbc.SelectedTab = tabPage12;
            }

            else if (alugueisDgv.Columns[e.ColumnIndex] == alugueisDgv.Columns["excluirAluguel"])
            {


                // confirmação de exclusão
                if (MessageBox.Show("Voce realmente deseja excluir ?", "Alugueis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {


                    idAluguelTbx.Text = alugueisDgv.Rows[e.RowIndex].Cells["id_aluguel"].Value.ToString();

                    AluguelDao aluguel = new AluguelDao();
                    Aluguel a = new Aluguel();

                    a.idAluguel = Convert.ToInt32(idAluguelTbx.Text);


                    aluguel.Excluir(a);
                }
                else
                {

                }
            }
        }

        private void salvarAluguelBtn_Click(object sender, EventArgs e)
        {
            AluguelDao aluguel = new AluguelDao();
            Aluguel a = new Aluguel();

            a.id_veiculo = Convert.ToInt32(idAluguelTbx.Text);
            a.nome = edIdFuncionarioAluguelTbx.Text;
            
            a.preco = Convert.ToDecimal(edTaxaTbx.Text);

            aluguel.EditarTudo(a);

            edIdFuncionarioAluguelTbx.Text = String.Empty;
            edTaxaTbx.Text = String.Empty;
        }
    }
}

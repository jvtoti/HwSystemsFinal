# HwSystems

1 passo - Criar uma conexão no mysql com o hostname: localhost port:3306 username: root sem senha
2 passo - Execute os comando a seguir para criar o banco: 

create database hwsystemsData;
use hwsystemsData;

create table tb_veiculos(
id_veiculo int(11) auto_increment not null, 
placa varchar(20) not null,
modelo varchar(20) not null,
marca varchar(20) not null,
cor varchar(10) not null,
ano_fabricacao int not null,
ano_modelo int not null, 
quilometragem decimal(10,2) not null, 
status_veiculo varchar(10),
fg_ativo int not null default 1,

primary Key(id_veiculo, placa)
);

create table tb_viagens(
id_viagem int auto_increment not null,
id_veiculo int not null,
destino varchar(50) not null,
data_saida varchar(10) not null,
data_chegada varchar(10) not null,
status_viagem varchar(10) not null,

primary key (id_viagem),
foreign key (id_veiculo) references tb_veiculos (id_veiculo)
);

create table tb_funcionarios(
id_funcionario int auto_increment not null,
nome_funcionario varchar(50) not null,
CPF_funcionario varchar(11) not null,
email_funcionario varchar(50) not null,
telefone_funcionario varchar(12) not null,
cargo varchar(50) not null,
salario decimal(10,2) not null,
fg_ativo int not null default 1,

primary key (id_funcionario)
);

create table tb_clientes(
id_cliente int auto_increment not null,
nome_cliente varchar(50) not null,
CPF_CNPJ varchar(11) not null,
CNH varchar(20) not null,
email_cliente varchar(50) not null,
telefone_cliente varchar(12) not null,
fg_ativo int not null default 1,

primary key (id_cliente)
);

create table tb_alugueis(
id_aluguel int auto_increment not null,
id_veiculo int not null,
nome_cliente varchar(150),
data_saida varchar(100) not null,
data_chegada varchar(100) not null,
preco decimal(10,2) not null,
status_aluguel varchar(50),
fg_ativo int not null default 1,

primary key (id_aluguel),
foreign key (id_veiculo) references tb_veiculos(id_veiculo)
);

3 passo - abra a pasta HwSystemsFinal-master
4 passo(mais facil) - para executar o programa pelo aqrquivo executavel, entre em LoginForm\bin\debug e execute o arquivo executavel LoginForm

4.1 passo (opcional) - para executar o programa pelo visual studio execute o arquivo HWSystems
4.2 Defina como projeto padrão o LoginForm.
4.3 passo - ao executar o programa vai dar um erro, para resolver esse erro, adicione referencia na bliblioteca de classe HWSystem, na aba de referencias
vá na aba procurar e selecione o primeiro aqrquivo "mysql.data.dll", e pronto erro resolvido.
4.4 execute normalmente.







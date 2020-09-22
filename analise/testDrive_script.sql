drop database testDrive;

create database testDrive;

use testDrive;

create table tb_login(
	id_login 	int primary key auto_increment,
    ds_username	varchar(255)	not null,
    ds_senha	varchar(255)	not null,
    ds_perfil	varchar(255)	not null
);

create table tb_cliente(
	id_cliente 					int primary key auto_increment,
    nm_cliente					varchar(255),
    nm_cliente_sobrenome		varchar(255),
    ds_cpf						varchar(255),
    ds_rg						varchar(255),
    ds_carteira_motorista		varchar(255),
    dt_nascimento				datetime,
    ds_sexo						varchar(50),
    ds_email					varchar(255),
    ds_celular					varchar(30),
    ds_endereco					varchar(255),
    ds_cep						varchar(15),
    ds_numero_endereco			varchar(25),
    ds_estado					varchar(100),
    ds_cidade					varchar(255),
    id_login				int,
    foreign key (id_login) references tb_login(id_login) on delete cascade
);

create table tb_funcionario(
	id_funcionario 			int primary key auto_increment,
    nm_funcionario			varchar(255),
    ds_carteira_trabalho	varchar(50),
    ds_email				varchar(255),
    dt_nascimento			datetime,
    id_login				int,
    foreign key (id_login) references tb_login(id_login) on delete cascade
);

create table tb_carro(
	id_carro 				int primary key auto_increment,
    ds_marca				varchar(255),
    ds_modelo				varchar(255),
    nr_ano_fab				int,
    nr_ano_model			int,
    ds_placa				varchar(255)
);

create table tb_agendamento(
	id_agendamento 			int primary key auto_increment,
    dt_agendamento			datetime,
    ds_situacao				varchar(255),
    vl_feedback				decimal(5,2),
    id_cliente				int,
    id_funcionario			int,
    id_carro				int,
    foreign key (id_cliente) references tb_cliente(id_cliente),
    foreign key (id_funcionario) references tb_funcionario(id_funcionario),
    foreign key (id_carro) references tb_carro(id_carro)
);

insert into tb_login(ds_username, ds_senha, ds_perfil)
			  values('admin','12345','Gerente');
insert into tb_login(ds_username, ds_senha, ds_perfil)
			  values('Brunex','12345ninja','Cliente');
insert into tb_login(ds_username, ds_senha, ds_perfil)
			  values('Lamorte','12345La','Tester');
insert into tb_login(ds_username, ds_senha, ds_perfil)
			  values('DeanW','12345super','Cliente');
              
insert into tb_cliente(nm_cliente,nm_cliente_sobrenome,ds_cpf,ds_rg,ds_carteira_motorista,dt_nascimento,ds_sexo,ds_email,ds_celular,ds_endereco,ds_cep,ds_numero_endereco,ds_estado,ds_cidade,id_login)
				values('Bruno', 'de Oliveira', '954.470.240-72', '32.783.278-2', '11122233344', '1987-08-30', 'M', 'souninja@gmail.com', '(85) 99189-5151', 'Avenida A1', '60191-530', '240', 'CE', 'Fortaleza', 2);
insert into tb_cliente(nm_cliente,nm_cliente_sobrenome,ds_cpf,ds_rg,ds_carteira_motorista,dt_nascimento,ds_sexo,ds_email,ds_celular,ds_endereco,ds_cep,ds_numero_endereco,ds_estado,ds_cidade,id_login)
				values('Jensei' ,'de Souza', '008.799.038-56', '31.438.338-4', '11122233344' ,'1971-10-25', 'M', 'jeinsei@gmail.com', '(84) 98242-2525', 'Avenida A2', '59060-520', '279', 'RN', 'Natal', 4);
                
insert into tb_funcionario(ds_carteira_trabalho, nm_funcionario, ds_email, dt_nascimento, id_login)
					values('1234567', 'Lucas', 'admin@gmail.com', '1978-02-01', 1);
insert into tb_funcionario(ds_carteira_trabalho, nm_funcionario, ds_email, dt_nascimento, id_login)
					values('1234567', 'Sérgio', 'lamorte@gmail.com', '1988-05-10', 3);
                    
insert into tb_carro(ds_marca, ds_modelo, nr_ano_fab, nr_ano_model, ds_placa)
					values('Toyota', 'Corolla', 2019, 2020, 'EEE-1111');
insert into tb_carro(ds_marca, ds_modelo, nr_ano_fab, nr_ano_model, ds_placa)
					values('Volkswagen', 'Jetta', 2020, 2020, 'FFF-2222');     
                    
insert into tb_agendamento(dt_agendamento, ds_situacao, vl_feedback, id_cliente, id_funcionario, id_carro)
					values('2020-09-15 10:00:00', 'Aprovado', 2.8, 1, 1, 1);
insert into tb_agendamento(dt_agendamento, ds_situacao, vl_feedback, id_cliente, id_funcionario, id_carro)
					values('2020-09-15 11:30:00', 'Aguardando', 11.0, 2, 2, 2);                                

select * from tb_login;
select * from tb_cliente;
select * from tb_funcionario;
select * from tb_agendamento;
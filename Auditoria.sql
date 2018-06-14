#fazer o log
create table perfil(
    id int auto_increment primary key,
    login varchar(32) not null unique,
    senha varchar(32) not null,
    nome varchar(64) not null
);
create table permicao(
    id int auto_increment primary key,
	criar_perfil tinyint(1) not null,
    alterar_permicao tinyint(1) not null,
    criar_categoria tinyint(1) not null,
	receita_r tinyint(1) not null,
	receita_w tinyint(1) not null,
	dispesa_r tinyint(1) not null,
	dispesa_w tinyint(1) not null,
    ler_log tinyint(1) not null,
	id_perfil int not null,
	foreign key (id_perfil) references perfil(id)
);
create table categoria(
    id int auto_increment primary key,
	nome varchar(32) not null,
	descricao varchar(128)
);
create table receita(
    id int auto_increment primary key,
	valor decimal(10,2) not null,
	`data` datetime not null,
	descricao varchar(128),
	id_categoria int,
	foreign key (id_categoria) references categoria(id)
);
create table dispesa_fixa(
    id int auto_increment primary key,
	valor decimal(10,2) not null,
	descricao varchar(128),
	id_categoria int,
	foreign key (id_categoria) references categoria(id)
);
create table dispesa_variavel(
    id int auto_increment primary key,
	valor decimal(10,2) not null,
	`data` datetime not null,
	descricao varchar(128),
	id_categoria int,
	foreign key (id_categoria) references categoria(id)
);
#logs
create table log
(
	id int auto_increment primary key,
    tabela char(1) not null, #Perfil perMicao Categoria Receita dispesa_Fixa dispesa_Variavel
    comando varchar(256) not null,
    usuario varchar(128) not null,
    transac char(1) not null #i insert u update d delete
);
#triggers
#PERFIL
delimiter |
drop trigger if exists log_p_i|
create trigger log_p_i after insert
on perfil
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'p',original_query,user(),'i');
end;
|
delimiter ;
delimiter |
drop trigger if exists log_p_u|
create trigger log_p_u after update
on perfil
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'p',original_query,user(),'u');
end;
|
delimiter ;
delimiter |
drop trigger if exists log_p_d|
create trigger log_p_d after delete
on perfil
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'p',original_query,user(),'d');
end;
|
delimiter ;
#PERMICAO
delimiter |
drop trigger if exists log_m_i|
create trigger log_m_i after insert
on permicao
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'m',original_query,user(),'i');
end;
|
delimiter ;
delimiter |
drop trigger if exists log_m_u|
create trigger log_m_u after update
on permicao
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'m',original_query,user(),'u');
end;
|
delimiter ;
delimiter |
drop trigger if exists log_m_d|
create trigger log_m_d after delete
on permicao
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'m',original_query,user(),'d');
end;
|
delimiter ;
#CATEGORIA
delimiter |
drop trigger if exists log_c_i|
create trigger log_c_i after insert
on categoria
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'c',original_query,user(),'i');
end;
|
delimiter ;
delimiter |
drop trigger if exists log_c_u|
create trigger log_c_u after update
on categoria
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'c',original_query,user(),'u');
end;
|
delimiter ;
delimiter |
drop trigger if exists log_c_d|
create trigger log_c_d after delete
on categoria
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'c',original_query,user(),'d');
end;
|
delimiter ;
#RECEITA
delimiter |
drop trigger if exists log_r_i|
create trigger log_r_i after insert
on receita
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'r',original_query,user(),'i');
end;
|
delimiter ;
delimiter |
drop trigger if exists log_r_u|
create trigger log_r_u after update
on receita
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'r',original_query,user(),'u');
end;
|
delimiter ;
delimiter |
drop trigger if exists log_r_d|
create trigger log_r_d after delete
on receita
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'r',original_query,user(),'d');
end;
|
delimiter ;
#FIXA
delimiter |
drop trigger if exists log_f_i|
create trigger log_f_i after insert
on dispesa_fixa
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'f',original_query,user(),'i');
end;
|
delimiter ;
delimiter |
drop trigger if exists log_f_u|
create trigger log_f_u after update
on dispesa_fixa
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'f',original_query,user(),'u');
end;
|
delimiter ;
delimiter |
drop trigger if exists log_f_d|
create trigger log_f_d after delete
on dispesa_fixa
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'f',original_query,user(),'d');
end;
|
delimiter ;
#VARIAVEL
delimiter |
drop trigger if exists log_v_i|
create trigger log_v_i after insert
on dispesa_variavel
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'v',original_query,user(),'i');
end;
|
delimiter ;
delimiter |
drop trigger if exists log_v_u|
create trigger log_v_u after update
on dispesa_variavel
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'v',original_query,user(),'u');
end;
|
delimiter ;
delimiter |
drop trigger if exists log_v_d|
create trigger log_v_d after delete
on dispesa_variavel
for each row
begin
	DECLARE original_query VARCHAR(1024);
    SET original_query = (SELECT info FROM INFORMATION_SCHEMA.PROCESSLIST WHERE id = CONNECTION_ID());
	insert into log values(null,'v',original_query,user(),'d');
end;
|
delimiter ;
#TESTES
insert into perfil values(null,'adm','adm','adm');
insert into permicao values(null,1,1,1,1,1,1,1,1,1);
insert into categoria values(null,'padrao','padrao');

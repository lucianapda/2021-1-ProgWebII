CREATE SEQUENCE propietario_idpropietario_seq
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 8500001
    START WITH 1
    NO CYCLE
    CACHE 1;
    
CREATE SEQUENCE pessoa_idpessoa_seq
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 8500001
    START WITH 1
    NO CYCLE
    CACHE 1;

CREATE SEQUENCE compra_idcompra_seq
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 8500001
    START WITH 1
    NO CYCLE
    CACHE 1;
	
create domain sit_registro as varchar(1)
default 'A'
not null
check(value in ('A','B','I'));

create domain tipo_pessoa as varchar(1)
default 'F'
not null
check (value in ('F','J'));

create domain sit_compra as varchar(1)
default 'P'
not null
check (value in ('A','P','C','F'));

create table propietario(
	idpropietario integer not null default nextval('propietario_idpropietario_seq'),
    tipoInscricao tipo_pessoa,
    cpf varchar(11),
    cnpj varchar(15),
    nome varchar(100) not null,
    email varchar(100) not null,
    situacao sit_registro,
    dataInicio date not null,
    primary key (idpropietario),
    constraint cpf_unico unique (tipoInscricao, cpf),
    constraint cnpj_unico unique (tipoInscricao, cnpj),
    constraint cpf_notnull check (tipoInscricao <> 'F' OR cpf is not null),
    constraint cnpj_notnull check (tipoInscricao <> 'J' OR cnpj is not null)    
);

alter table propietario alter column idPropietario set default nextval('propietario_idpropietario_seq');

create table loja(
	idLoja integer not null,
	idPropietario integer not null,
	nome varchar(100) not null,
	situacao sit_registro,
	primary key (idLoja, idPropietario),
	foreign key (idPropietario) references propietario (idPropietario)
);

create table categoria(
	idcategoria integer not null,
	idloja integer not null,
	idpropietario integer not null,
	nome varchar(100) not null,
	descricao varchar(500),
	situacao sit_registro,
	primary key(idcategoria,idloja,idpropietario),
	foreign key (idloja,idpropietario) references loja (idloja,idpropietario)
);

create table produto(
	idproduto integer not null,
	idloja integer not null,
	idpropietario integer not null,
	idcategoria integer,
	nome varchar(100) not null,
	descricao varchar(500),
	precoUnitario decimal(17,2) not null,
	datacadastro date not null,
	situacao sit_registro,
	marca varchar(25),
	primary key (idproduto,idloja,idpropietario),
	foreign key (idloja,idpropietario) references loja(idloja,idpropietario),
	foreign key (idloja,idpropietario,idcategoria) references categoria(idloja,idpropietario,idcategoria)
);

create table produto_imagem(
	idproduto integer not null,
	idloja integer not null,
	idpropietario integer not null,
	idimagem integer not null,
	nome varchar(100) not null,
	caminhoDiretorio varchar(500) not null,
	situacao sit_registro,
	primary key (idimagem,idproduto,idloja,idpropietario),
	foreign key (idproduto,idloja,idpropietario) references produto(idproduto,idloja,idpropietario)
);

create table promocao(
	idloja integer not null,
	idpropietario integer not null,
	idpromocao integer not null,
	nome varchar(100) not null,
	percentual_desconto decimal(5,2) not null,
	dataCadastro date not null,
	situacao sit_registro,
	primary key (idpromocao,idloja,idpropietario),
	foreign key (idloja,idpropietario) references loja(idloja,idpropietario)
);

create table produto_promocao(
	idloja integer not null,
	idpropietario integer not null,
	idproduto integer not null,
	idpromocao integer not null,
	primary key	(idloja,idpropietario,idproduto,idpromocao),
	foreign key (idloja,idpropietario,idproduto) references produto(idloja,idpropietario,idproduto),
	foreign key (idloja,idpropietario,idpromocao) references promocao(idloja,idpropietario,idpromocao)
);

create table pessoa(
	idpessoa integer not null default nextval('pessoa_idpessoa_seq'),
	tipoInscricao tipo_pessoa,
	cpf varchar(11),
    cnpj varchar(15),
	nome varchar(100) not null,
	email varchar(50) not null,
	senha varchar(50),
	primary key (idpessoa),
	constraint cpfpessoa_unico unique (tipoInscricao, cpf),
    constraint cnpjpessoa_unico unique (tipoInscricao, cnpj),
    constraint cpfpessoa_notnull check (tipoInscricao <> 'F' OR cpf is not null),
    constraint cnpjpessoa_notnull check (tipoInscricao <> 'J' OR cnpj is not null)    
);

create table pessoa_endereco(
	idpessoa integer not null,
	id integer not null,
	rua varchar(100) not null,
    bairro varchar(50) not null,
	cidade varchar(50) not null,
    uf varchar(2) not null,
    cep varchar(8) not null,
    numero varchar(6),
    complemento varchar(50),
    telefone varchar(9) not null,
    ddd varchar(2) not null,    
	primary key (idpessoa, id),
	foreign key (idpessoa) references pessoa(idpessoa)  
);

create table compra(
	idcompra integer not null default nextval('compra_idcompra_seq'),
	idloja integer not null,
	idpropietario integer not null,
	idpessoa integer not null,
	situacao sit_compra,
	dataCompra date not null,
	idendereco integer not null,
	primary key (idcompra),
	foreign key (idpessoa) references pessoa(idpessoa),
	foreign key (idloja,idpropietario) references loja(idloja,idpropietario),
	foreign key (idendereco, idpessoa) references pessoa_endereco(id,idpessoa)
);

create table compra_item(
	id integer not null,
	idcompra integer not null,
	idproduto integer not null,
	idloja integer not null,
	idpropietario integer not null,
	quantidade integer not null,
	valorunitario decimal(17,2) not null,
	primary key (id,idcompra),
	foreign key (idcompra) references compra(idcompra),
	foreign key (idloja,idpropietario,idproduto) references produto(idloja,idpropietario,idproduto),
);


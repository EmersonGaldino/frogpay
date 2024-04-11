create table tb_user
(
    id          uuid         not null
        primary key,
    email       varchar(100) not null,
    name        varchar(100) not null,
    password    varchar(100),
    login       varchar(50)  not null,
    criado_em   date,
    alterado_em date
);

alter table tb_user
    owner to frogpay;

create table tb_store
(
    id            uuid               not null
        primary key,
    id_user       uuid
        references tb_user,
    razao_social  varchar(100)       not null,
    nome_fantasia varchar(100)       not null,
    cnpj          varchar(50),
    data_abertura date default now() not null,
    criado_em     date default now(),
    alterado_em   date
);

alter table tb_store
    owner to frogpay;

create table tb_dados_bancarios
(
    id           uuid                    not null
        primary key,
    id_usuario   uuid
        references tb_user,
    codigo_banco integer                 not null,
    agencia      integer                 not null,
    conta        integer                 not null,
    digito_conta integer                 not null,
    criado_em    timestamp default now() not null,
    alterado_em  timestamp               not null
);

alter table tb_dados_bancarios
    owner to frogpay;

create table tb_endereco
(
    id          uuid               not null
        primary key,
    id_user     uuid
        references tb_user,
    uf_estado   varchar(2)         not null,
    cidade      varchar(50)        not null,
    bairro      varchar(50),
    logradouro  varchar(50),
    numero      integer,
    complemento varchar(100),
    criado_em   date default now() not null,
    alterado_em date
);

alter table tb_endereco
    owner to frogpay;

---- Inserts ---

INSERT INTO frogpay.tb_dados_bancarios (id, id_usuario, codigo_banco, agencia, conta, digito_conta, criado_em, alterado_em) VALUES ('e95bcb4b-1c8c-4e17-a02c-f2a99f24086e', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 123, 4567, 890123, 4, '2024-04-10 15:54:25.887071', '2024-04-10 15:54:25.887071');
INSERT INTO frogpay.tb_dados_bancarios (id, id_usuario, codigo_banco, agencia, conta, digito_conta, criado_em, alterado_em) VALUES ('26c7a4a0-28eb-4c16-87b0-529b374e3ac8', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 456, 3747, 776755, 0, '2024-04-11 12:06:27.000000', '2024-04-11 12:06:29.000000');
INSERT INTO frogpay.tb_dados_bancarios (id, id_usuario, codigo_banco, agencia, conta, digito_conta, criado_em, alterado_em) VALUES ('0d9ce48f-7252-46cb-91cb-ed1cd59d0689', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 789, 9090, 622342, 5, '2024-04-11 12:06:57.000000', '2024-04-11 12:06:59.000000');
INSERT INTO frogpay.tb_dados_bancarios (id, id_usuario, codigo_banco, agencia, conta, digito_conta, criado_em, alterado_em) VALUES ('04b04c31-aa5d-42ea-9519-f4f517356fff', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 112, 2324, 42412, 2, '2024-04-11 12:07:25.000000', '2024-04-11 12:07:27.000000');


INSERT INTO frogpay.tb_endereco (id, id_user, uf_estado, cidade, bairro, logradouro, numero, complemento, criado_em, alterado_em) VALUES ('32b66a58-6f0c-43c6-b08f-2e645a3a4948', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 'SP', 'Bauru', 'Centro', 'Estrada das Rosas', 123, 'Ao lado do bar do seu zé', '2024-04-10', '2024-04-10');
INSERT INTO frogpay.tb_endereco (id, id_user, uf_estado, cidade, bairro, logradouro, numero, complemento, criado_em, alterado_em) VALUES ('3e5a1a27-80f2-4ae8-b321-8fdd90360b02', 'bdb4ae5e-09b2-4036-94a0-3b7396f57101', 'SP', 'Sorocaba', 'Moro Doce', 'Estrada das Pitaias', 99, 'Frente ao girador', '2024-04-10', '0001-01-01');

INSERT INTO frogpay.tb_store (id, id_user, razao_social, nome_fantasia, cnpj, data_abertura, criado_em, alterado_em) VALUES ('4fd6d5b4-5114-4e15-8a9f-8eaf8c794c2d', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 'Razao Social 4', 'Nome Fantasia 4', '12345678901237', '2024-04-13', '2024-04-11', '2024-04-11');
INSERT INTO frogpay.tb_store (id, id_user, razao_social, nome_fantasia, cnpj, data_abertura, criado_em, alterado_em) VALUES ('2fd8d5b4-5114-4e15-8a9f-8eaf8c794c2d', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 'Razao Social 2', 'Nome Fantasia 2', '12345678901235', '2024-04-11', '2024-04-11', '2024-04-11');
INSERT INTO frogpay.tb_store (id, id_user, razao_social, nome_fantasia, cnpj, data_abertura, criado_em, alterado_em) VALUES ('3fd7d5b4-5114-4e15-8a9f-8eaf8c794c2d', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 'Razao Social 3', 'Nome Fantasia 3', '12345678901236', '2024-04-12', '2024-04-11', '2024-04-11');
INSERT INTO frogpay.tb_store (id, id_user, razao_social, nome_fantasia, cnpj, data_abertura, criado_em, alterado_em) VALUES ('1fd0d5b4-5114-4e15-8a9f-8eaf8c794c2d', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 'Razao Social 1', 'Nome Fantasia 1', '12345678901234', '2024-04-10', '2024-04-11', '2024-04-11');
INSERT INTO frogpay.tb_store (id, id_user, razao_social, nome_fantasia, cnpj, data_abertura, criado_em, alterado_em) VALUES ('6fd4d5b4-5114-4e15-8a9f-8eaf8c794c2d', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 'Razao Social 6', 'Nome Fantasia 6', '12345678901239', '2024-04-15', '2024-04-11', '2024-04-11');
INSERT INTO frogpay.tb_store (id, id_user, razao_social, nome_fantasia, cnpj, data_abertura, criado_em, alterado_em) VALUES ('7fd3d5b4-5114-4e15-8a9f-8eaf8c794c2d', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 'Razao Social 7', 'Nome Fantasia 7', '12345678901240', '2024-04-16', '2024-04-11', '2024-04-11');
INSERT INTO frogpay.tb_store (id, id_user, razao_social, nome_fantasia, cnpj, data_abertura, criado_em, alterado_em) VALUES ('5fd5d5b4-5114-4e15-8a9f-8eaf8c794c2d', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 'Razao Social 5', 'Nome Fantasia 5', '12345678901238', '2024-04-14', '2024-04-11', '2024-04-11');
INSERT INTO frogpay.tb_store (id, id_user, razao_social, nome_fantasia, cnpj, data_abertura, criado_em, alterado_em) VALUES ('8fd2d5b4-5114-4e15-8a9f-8eaf8c794c2d', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 'Razao Social 8', 'Nome Fantasia 8', '12345678901241', '2024-04-17', '2024-04-11', '2024-04-11');
INSERT INTO frogpay.tb_store (id, id_user, razao_social, nome_fantasia, cnpj, data_abertura, criado_em, alterado_em) VALUES ('0fd0d5b4-5114-4e15-8a9f-8eaf8c794c2d', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 'Razao Social 10', 'Nome Fantasia 10', '12345678901243', '2024-04-19', '2024-04-11', '2024-04-11');
INSERT INTO frogpay.tb_store (id, id_user, razao_social, nome_fantasia, cnpj, data_abertura, criado_em, alterado_em) VALUES ('ec05a824-2bf2-4bf0-bcef-4b0b371d6dfa', 'b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 'Razao Social 11', 'Nome Fantasia 11', '12345678901222', '2024-04-19', '2024-04-11', '0001-01-01');


INSERT INTO frogpay.tb_user (id, email, name, password, login, criado_em, alterado_em) VALUES ('b85e8298-776e-4d1c-b4c9-0cf08cc73aea', 'emersongaldino@hotmail.com', 'Emerson Galdino', '123456', 'Galdino', '2024-04-10', '2024-04-10');
INSERT INTO frogpay.tb_user (id, email, name, password, login, criado_em, alterado_em) VALUES ('bdb4ae5e-09b2-4036-94a0-3b7396f57101', 'bb@a.com', 'ze das coves', '888675', 'Das neves', '2024-04-10', '0001-01-01');

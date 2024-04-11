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

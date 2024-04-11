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

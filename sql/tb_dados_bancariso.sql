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

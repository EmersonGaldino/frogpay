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

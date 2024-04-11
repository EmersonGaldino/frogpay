
USE FROGPAY
GO

create table [User]
(
    id       uuid default gen_random_uuid() not null
        primary key,
    email    varchar(100)                   not null,
    name     varchar(100)                   not null,
    password varchar(100),
    login varchar(50) not null
)
GO

insert into tb_user ( email, name, password, login) 
values ('emersongaldino@hotmail.com', 'Emerson Galdino', '123456', 'Galdino');
GO
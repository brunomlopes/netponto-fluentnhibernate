
    drop table if exists Tipologia

    drop table if exists Casa

    drop table if exists Oferta

    create table Tipologia (
        Id  integer,
       Nome TEXT,
       primary key (Id)
    )

    create table Casa (
        Id  integer,
       Descricao TEXT,
       Preco NUMERIC,
       Tipologia_id INTEGER,
       primary key (Id)
    )

    create table Oferta (
        Id  integer,
       Comprador TEXT,
       Valor NUMERIC,
       Casa_id INTEGER,
       primary key (Id)
    )

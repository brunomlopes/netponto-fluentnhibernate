
    drop table if exists Tipologia

    drop table if exists Casa

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

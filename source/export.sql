
    drop table if exists "Casa"

    drop table if exists "Tipologia"

    create table "Casa" (
        Id  integer,
       Descricao TEXT,
       Preco NUMERIC,
       Tipologia_id INTEGER,
       primary key (Id)
    )

    create table "Tipologia" (
        Id  integer,
       Nome TEXT,
       primary key (Id)
    )

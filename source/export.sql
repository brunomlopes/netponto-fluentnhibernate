
    drop table if exists "Tipologia"

    drop table if exists "Foto"

    drop table if exists "Casa"

    create table "Tipologia" (
        Id  integer,
       Nome TEXT,
       primary key (Id)
    )

    create table "Foto" (
        Id  integer,
       Casa_Id INTEGER,
       primary key (Id)
    )

    create table "Casa" (
        Id  integer,
       Descricao TEXT,
       Tipologia_id INTEGER,
       primary key (Id)
    )

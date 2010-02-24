# -*- coding: latin-1 -*-
from common_database import config,c
from NHibernate.Tool import hbm2ddl
from System.IO import Path
from System import Random
from Model.Entities import Casa, Tipologia, Foto

r = Random()
def choice(list):
    return list[r.Next(len(list))]

def randint(a,b):
    return r.Next(a,b)

hbm2ddl.SchemaExport(config).SetOutputFile(Path.GetFullPath("export.sql")).Execute(False, True, False)

sessionFactory = c.CreateSessionFactory()
session = sessionFactory.OpenSession()
transaction = session.BeginTransaction()

t1 = Tipologia("T1")
t2 = Tipologia("T2")
t3 = Tipologia("T3")
for tipologia in [t1,t2,t3]:
    session.Save(tipologia)

def getDescricao():
    tipo = ["Nova","Usada","Em construção"]
    caracteristicas = ["vista para mar", "vista para rio", "vista de cidade", "vista desafogada", "garagem com box", "ar condicionado", "piscina", "situada a 10 minutos de estação de comboio", "bom acesso a transportes", "comercio local", "zona sossegada", "boa orientação solar", "pavimento em madeira", "tecto falso", "arrecadação", "vidros duplos", "zona nobre", "quarto com suite", "wc com cabine de hidromassagem", "cozinha de linha italiana", "remodelada recentemente",]
    return choice(tipo) + ", " + ", ".join(set(choice(caracteristicas) for i in range(randint(2,9))))

def priceFor(t):
    if t == t1:
        return randint(550, 1300)*100
    if t == t2:
        return randint(750, 2000)*100
    if t == t3:
        return randint(1500, 4000)*100

for i in range(50):
    t = choice([t1,t2,t3])
    session.Save(Casa(getDescricao(), t, priceFor(t)))

transaction.Commit()
session.Close()

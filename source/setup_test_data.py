# -*- coding: latin-1 -*-
from common_database import config, c, flush_nhprof
from NHibernate.Tool import hbm2ddl
from System.IO import Path
from System import Random
from Model.Entities import Casa, Tipologia, Oferta

t1 = Tipologia("T1")
t2 = Tipologia("T2")
t3 = Tipologia("T3")
t4 = Tipologia("T4")
tipologias = [t1,t2,t3,t4]


def setup_test_data():
    sessionFactory = c.CreateSessionFactory()
    session = sessionFactory.OpenSession()
    transaction = session.BeginTransaction()
    

    for tipologia in tipologias:
        session.Save(tipologia)

    for i in range(50):
        t = choice(tipologias)
        casa = Casa(getDescricao(), t, priceFor(t))
        for i in range(randint(0,4)):
            casa.AdicionarOferta(Oferta(getNome(), priceFor(t)))
        session.Save(casa)

    transaction.Commit()
    session.Close()

def getDescricao():
    tipo = ["Nova","Usada","Em constru��o"]
    caracteristicas = ["vista para mar", "vista para rio", "vista de cidade", "vista desafogada", "garagem com box", "ar condicionado", "piscina", "situada a 10 minutos de esta��o de comboio", "bom acesso a transportes", "comercio local", "zona sossegada", "boa orienta��o solar", "pavimento em madeira", "tecto falso", "arrecada��o", "vidros duplos", "zona nobre", "quarto com suite", "wc com cabine de hidromassagem", "cozinha de linha italiana", "remodelada recentemente",]
    return choice(tipo) + ", " + ", ".join(set(choice(caracteristicas) for i in range(randint(2,9))))

def getNome():
    proprio = ["Ant�nio","M�rio","Cl�udia","J�lia","Fl�vio","Diana","Marcelo","Caio","Oct�vio","Beatriz","Vit�ria","Cec�lia","T�rcio","Dinis","Alexandre","Filipe","Andr�","Filomena","Irene","Catarina","Sofia","Margarida","Jorge","Viriato","Artur","Br�gida","Fiona","Viviana","F�tima","Soraia","Aida","Zuleica","Leila","Isabel","Maria","Jo�o","Manuel","Susana","Elias","Miguel","Gabriel","Mateus","Matias","Alberto","Ivone","Matilde","Rodrigo","Alice","Ema","Leopoldo","Ricardo","Afonso","Fernando","Frederico","Carlos","Lu�s","Xavier","Estanislau","Olga","Vera","�tila","Ciro","Zita","Rita"]
    apelido = ["Aboim","Abreu","Aguiar","Almeida","Alves","Amaral","Barbosa","Barreto","Basto","Batalha","Batista","Cabral","Caiado", "Carmo","Carvalho","Castanheira","Cavaleiro","Chaves","Coelho","Concei��o","Cordeiro","Costa","Coutinho","Crespo","Cruz","Cunha","Dias","Domingos","Domingues","Faria","Ferreira","Fonseca","Freitas","Godinho","Gomes","Gon�alves","Guedes","Guerra","Jesus","Lacerda","Lage","Lemos","Lencastre","Lopes","Loureiro","Maia","Martins","Melo","Mendes","Meneses","Monteiro","Nascimento","Neto","Neves","Nobre","Pereira","Pombo","Saldanha","Sampaio","Torres","Varela","Vaz","Velho"]
    return choice(proprio) + " " + choice(apelido)

def priceFor(t):
    if t == t1:
        return randint(550, 1300)*100
    if t == t2:
        return randint(750, 2000)*100
    if t == t3:
        return randint(1500, 4000)*100
    if t == t4:
        return randint(3000, 10000)*100


r = Random()
def choice(list):
    return list[r.Next(len(list))]

def randint(a,b):
    return r.Next(a,b)

setup_test_data()
flush_nhprof()

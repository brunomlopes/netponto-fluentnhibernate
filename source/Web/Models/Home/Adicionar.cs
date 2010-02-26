using System;
using System.Collections.Generic;
using Model;
using Model.Entities;

namespace Web.Models.Home
{
    public class Adicionar
    {
        public Adicionar(string titulo)
        {
            Titulo = titulo;
        }

        public Adicionar(string titulo, Casa casa)
            : this(titulo)
        {
            Id = casa.Id;
            Descricao = casa.Descricao;
            Tipologia = casa.Tipologia;
            Preco = casa.Preco;
            Localizacao = casa.Localizacao;
        }

        public string Titulo { get; set; }

        public int? Id { get; set; }
        public string Descricao { get; set; }
        public Tipologia Tipologia { get; set; }
        public decimal Preco { get; set; }
        public Localizacao Localizacao { get; set; }

        public IEnumerable<Tipologia> Tipologias { get; set; }
    }
}
using System.Collections.Generic;
using Model.Entities;

namespace Web.Models.Home
{
    public class Adicionar
    {
        public string Descricao { get; set; }
        public Tipologia Tipologia { get; set; }
        public decimal Preco { get; set; }

        public IEnumerable<Tipologia> Tipologias { get; set; }
    }
}
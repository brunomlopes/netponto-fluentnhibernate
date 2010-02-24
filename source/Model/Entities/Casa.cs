using System;
using System.Collections.Generic;

namespace Model.Entities
{
    public class Casa
    {
        public virtual int Id { get; private set; }
        public virtual string Descricao { get; set; }
        public virtual Tipologia Tipologia { get; set; }
        public virtual decimal Preco { get; set; }
        public virtual IList<Foto> Fotos { get; private set; }

        protected Casa()
        {
            Fotos = new List<Foto>();
        }

        public Casa(string descricao, Tipologia tipologia, decimal preco)
        {
            Descricao = descricao;
            Tipologia = tipologia;
            Preco = preco;
        }
    }
}
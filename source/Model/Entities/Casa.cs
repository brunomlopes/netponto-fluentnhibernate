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
        public virtual IList<Oferta> Ofertas { get; private set; }
        public virtual Localizacao Localizacao { get; set; }
        protected Casa()
        {
        }

        public Casa(string descricao, Tipologia tipologia, decimal preco)
        {
            Descricao = descricao;
            Tipologia = tipologia;
            Preco = preco;
            Ofertas = new List<Oferta>();
            Localizacao = new Localizacao();
        }

        public virtual void AdicionarOferta(Oferta oferta)
        {
            Ofertas.Add(oferta);
            oferta.Casa = this;
        }
    }
}
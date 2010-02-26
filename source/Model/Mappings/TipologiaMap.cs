using FluentNHibernate.Mapping;
using Model.Entities;

namespace Model.Mappings
{
    public class TipologiaMap : ClassMap<Tipologia>
    {
        public TipologiaMap()
        {
            Id(t => t.Id);
            Map(t => t.Nome);
        }
    }
}
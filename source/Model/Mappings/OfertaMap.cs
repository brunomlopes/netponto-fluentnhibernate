using FluentNHibernate.Mapping;
using Model.Entities;

namespace Model.Mappings
{
    public class OfertaMap : ClassMap<Oferta>
    {
        public OfertaMap()
        {
            Id(o => o.Id);
            Map(o => o.Comprador);
            Map(o => o.Valor);
            References(o => o.Casa);
        }
    }
}
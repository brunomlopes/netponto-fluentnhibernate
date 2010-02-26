using FluentNHibernate.Mapping;
using Model.Entities;

namespace Model.Mappings
{
    public class CasaMap : ClassMap<Casa>
    {
        public CasaMap()
        {
            Id(c => c.Id);
            Map(c => c.Descricao);
            Map(c => c.Preco);
            References(c => c.Tipologia);
            HasMany(c => c.Ofertas)
                .Inverse()
                .Cascade.All();
        }
    }
}
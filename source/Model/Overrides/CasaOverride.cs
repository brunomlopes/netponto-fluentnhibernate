using System;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Model.Entities;

namespace Model.Overrides
{
    public class CasaOverride : IAutoMappingOverride<Casa>
    {
        public void Override(AutoMapping<Casa> mapping)
        {
            mapping.Component(c => c.Localizacao,
                              part =>
                                  {
                                      part.Map(c => c.Cidade);
                                      part.Map(c => c.Zona);
                                  });
        }
    }
}
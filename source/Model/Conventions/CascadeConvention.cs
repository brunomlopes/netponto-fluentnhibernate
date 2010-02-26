using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace Model.Conventions
{
    public class CascadeConvention : ICollectionConvention
    {
        public void Apply(ICollectionInstance instance)
        {
            instance.Cascade.SaveUpdate();
        }
    }
}
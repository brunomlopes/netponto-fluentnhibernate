using System;
using System.Collections.Generic;
using Model.Entities;

namespace Web.Models.Home
{
    public class Index
    {
        public IEnumerable<Casa> Casas { get; private set; }
        public int? Highlight { get; set; }

        public Index(IEnumerable<Casa> casas, int? highlight)
        {
            Casas = casas;
            Highlight = highlight;
        }
    }
}
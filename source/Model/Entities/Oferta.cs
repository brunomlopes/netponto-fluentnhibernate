namespace Model.Entities
{
    public class Oferta
    {
        public virtual int Id { get; private set; }
        public virtual string Comprador { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual Casa Casa { get; set; }

        protected Oferta()
        {
        }

        public Oferta(string comprador, decimal valor)
        {
            Comprador = comprador;
            Valor = valor;
        }
    }
}
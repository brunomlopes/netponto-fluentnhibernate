namespace Model.Entities
{
    public class Tipologia
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }

        public Tipologia(string nome)
        {
            Nome = nome;
        }
        protected Tipologia(){}
    }
}
namespace Program
{
    public class Pechera : Item
    {
        public override int DEF {get; protected set;}
        
        public Pechera (string nombre, int def)
        {
            this.Name = nombre;
            this.DEF = def;
        }
    }
}

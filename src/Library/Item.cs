namespace Program
{
    public abstract class Item
    //util para objetos comunes, por defecto los atributos DMG y DEF son 0, para cada item usamos override si queremos alterar esto,
    //dependiendo de si es para atacar, defender o ambos.
    {
        public string Name {get; set;}
        public virtual int DMG 
        {
            get
            {
                return 0;
            } 
            protected set{}
        }
        public virtual int DEF {
            get
            {
                return 0;
            } 
            protected set{}
        }
        }
    }
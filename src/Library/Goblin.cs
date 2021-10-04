namespace Program
{
    public class Goblin : Personaje
    {
        public Goblin()
        {
            this.Nombre  = "Goblin";
            this.XP = 3;
        }

        public override int K_maxHP
        {
            get
            {
                return 60;
            }
        }

        public override int K_AtaqueBase
        {
            get
            {
                return 15;
            }
        }
    }
}
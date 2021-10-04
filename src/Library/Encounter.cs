using System.Collections.Generic;

namespace Program
{
    public class Encounter
    //lo trabajo como singleton, ya que solo va a haber un encuentro a la vez, y permitiría a futuro
    //darle atributos y modificadores especiales a los escenarios a futuro.
    {
        private static Encounter instance{get; set;}

        public static Encounter Arena
        {
            get
            {
                if (instance==null)
                {
                    instance = new Encounter();
                    return instance;
                }
                return instance;
            }
        }
        private Encounter(){}

        public void ClearArena()
        {
            this.Heroes.Clear();
            this.Goblins.Clear();
        }

        private void ClearDead()
        {
            List<Personaje> bucket = new List<Personaje>();
            foreach (Personaje hero in this.Heroes)
            {
                if (hero.isDead)
                {
                    bucket.Add(hero);
                }
            }
            foreach (Personaje dead in bucket)
            {
                Heroes.Remove(dead);
            }

            bucket.Clear();

            foreach (Personaje goblin in this.Goblins)
            {
                if (goblin.isDead)
                {
                    bucket.Add(goblin);
                }
            }
            foreach (Personaje dead in bucket)
            {
                Goblins.Remove(dead);
            }
        }

        public List<Personaje> Heroes {get; set;} = new List<Personaje>();
        public List<Personaje> Goblins {get; set;} = new List<Personaje>();

        public void AddHero (Personaje Heroe) 
        {
            Heroes.Add(Heroe);
        }


        public void AddGoblins(Personaje Goblin) 
        {
            Goblins.Add(Goblin);
        }
        public void AddGoblins(int cantidad) 
        {
            for (int i =0; i<cantidad; i++)
            {
            Goblins.Add(new Goblin());
            }
        }
        //inicialmente dejo un metodo para añadir x cantidad de goblins como enemigos genericos y otro por sobrecarga si se quiere dar un enemigo personalizado
        
        
        public void doEncounter()
        {
            bool isDone = false;
            
            List<Personaje> alreadyAttacked = new List<Personaje>();
            //con esta lista puedo controlar que personajes ya atacaron, en caso de que hayan mas goblins que heroes
            
            
            while (isDone == false)
            {
                int remainingHeroes = this.Heroes.Count;
                int remainingEnemies = this.Goblins.Count;
                alreadyAttacked.Clear();

                //turno de los enemigos(goblins)
                while (alreadyAttacked.Count != remainingEnemies)
                //los goblins siguen atacando hasta que todos hayan atacado, controlar el while por fuera de los foreach me deja loopear los heroes para
                //el caso que sean menos que los enemigos
                {
                    foreach (Personaje hero in this.Heroes)
                    {
                        foreach (Personaje goblin in this.Goblins)
                        {
                            if (!alreadyAttacked.Contains(goblin))
                            {
                                Interacciones.Ataque(goblin, hero);
                                alreadyAttacked.Add(goblin);
                                break; //sale del foreach, pasa al siguiente heroe
                            }
                        }
                    }
                }
                ClearDead();
                //turno de los heroes
                foreach (Personaje hero in this.Heroes)
                {
                    foreach (Personaje goblin in this.Goblins)
                    {
                        if (!goblin.isDead)
                        {
                            Interacciones.Ataque(hero, goblin);
                        }
                    }
                    //cada heroe ataca a todos los goblins (un poco OP pero son los protagonistas asi que pasa)
                }
                ClearDead();
                //sacar las instancias de las listas debo hacerlo fuera de los foreach sino me manda error

                if (this.Heroes.Count == 0) 
                //si cualquiera de ambos bandos se termina, finaliza el encuentro
                {
                    ConsoleLogger.PrintFail();
                    isDone = true;
                }
                else if(this.Goblins.Count == 0)
                {
                    ConsoleLogger.PrintWin();
                    isDone = true;
                }
            }
            ClearArena();
            //una vez terminado el conflicto se limpia la arena
        }
    }
}
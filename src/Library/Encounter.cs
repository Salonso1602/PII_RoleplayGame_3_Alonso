using System.Collections.Generic;

namespace Program
{
    public class Encounter
    //lo trabajo como singleton, ya que solo va a haber un encuentro a la vez, y permitiría a futuro
    //darle atributos y modificadores especiales a los escenarios a futuro.
    {
        private Encounter instance{get; set;}

        public Encounter Arena
        {
            get
            {
                if (this.instance==null)
                {
                    this.instance = new Encounter();
                    return this.instance;
                }
                return this.instance;
            }
        }
        private Encounter(){}

        public List<Personaje> Heroes {get; set;} = new List<Personaje>();
        public List<Personaje> Goblins {get; set;} = new List<Personaje>();

        public void añadirHeroe(Personaje Heroe) 
        {
            Heroes.Add(Heroe);
        }


        public void añadirGoblins(Personaje Goblin) 
        {
            Goblins.Add(Goblin);
        }
        public void añadirGoblins(int cantidad) 
        {
            for (int i =0; i<=cantidad; i++)
            Goblins.Add(new Goblin());
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

                //turno de los enemigos(goblins)
                int AttackCounter = 0;
                while (AttackCounter != remainingEnemies)
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
                                AttackCounter += 1;
                                break; //sale del foreach, pasa al siguiente heroe
                            }
                        }

                        if (hero.isDead)
                        {
                            this.Heroes.Remove(hero);
                        }
                    }
                }
                //turno de los heroes
                foreach (Personaje hero in this.Heroes)
                {
                    foreach (Personaje goblin in this.Goblins)
                    {
                        Interacciones.Ataque(hero, goblin);

                        if (goblin.isDead)
                        {
                            this.Goblins.Remove(goblin);
                        }
                    }
                    //cada heroe ataca a todos los goblins (un poco OP pero son los protagonistas asi que pasa)
                }

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
        }
    }
}
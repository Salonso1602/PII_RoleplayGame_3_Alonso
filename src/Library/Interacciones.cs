using System;

namespace Program
{
    public static class Interacciones
    {
        //esta clase se responsabiliza de manejar los diferentes tipos de interacciones a nivel matematico, ya que puede facilmente acceder a los datos de los
        //personajes implicados y realizar las operaciones y controles necesarios. Es aplicación de EXPERT y SRP, al delegar la impresión a ConsoleLogger
        public static void Ataque(Personaje atacante, Personaje atacado)
        {
            if (atacante.Ataque > atacado.Defensa) {
                atacado.HP -= atacante.Ataque - atacado.Defensa;
                if(atacado.HP < 0)
                {
                    atacado.HP = 0;
                    atacante.XP += atacado.XP;
                }
            }

            //se le envía los datos de los personajes implicados en ataque para que se imprima en pantalla
            ConsoleLogger.ImprimirAtaque(atacante, atacado);
        }
        public static void LanzamientoHechizo(Mago lanzador, Hechizo hechizo, Personaje objetivo)
        {
            if(hechizo.TipoEfecto == "Daño" && lanzador.LibroEquipado.Contains(hechizo))
            {
                objetivo.HP -= hechizo.Poder;
                if(objetivo.HP < 0)
                {
                    objetivo.HP = 0;
                    lanzador.XP += objetivo.XP;
                }

                //se le envía los datos de los personajes implicados lanzamiento de hechizo de ataque para que se imprima en pantalla
                ConsoleLogger.ImprimirLanzamientoHechizo(lanzador, hechizo, objetivo);
            }
            if(hechizo.TipoEfecto == "Curación" && lanzador.LibroEquipado.Contains(hechizo))
            {
                objetivo.HP += hechizo.Poder;
                if(objetivo.HP > Personaje.K_maxHP)
                {
                    objetivo.HP = Personaje.K_maxHP;
                }


                //se le envía los datos de los personajes implicados lanzamiento de hechizo de curación para que se imprima en pantalla
                ConsoleLogger.ImprimirLanzamientoHechizo(lanzador, hechizo, objetivo);
            }
        }
    }
}
using System;
using System.Text;

namespace Program {
    public static class ConsoleLogger 
    {
        public static void ImprimirAtaque(Personaje atacante, Personaje atacado) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{atacante.Nombre} atacó a {atacado.Nombre} con {atacante.Arma.Name}.");
            if (atacado.isDead == false) {
                sb.Append($" {atacado.Nombre} quedó con {atacado.HP} HP.");
            }
            else {
                sb.Append($" {atacado.Nombre} ha muerto. \n {atacante.Nombre} gana {atacado.XP} puntos de Experiencia");
            }
            Console.WriteLine(sb.ToString());
        }
        public static void ImprimirCuracion(Personaje curador, Personaje curado) {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{curador.Nombre} curó a {curado.Nombre}.");
            sb.Append($" {curado.Nombre} quedó con {curado.HP} HP.");
            Console.WriteLine(sb.ToString());
        }

        public static void ImprimirLanzamientoHechizo(Personaje lanzador, Hechizo hechizo, Personaje objetivo) {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{lanzador.Nombre} lanzó el hechizo {hechizo.Nombre} a {objetivo.Nombre}, ");
            switch (hechizo.TipoEfecto) 
            {
                case "Daño":
                    sb.Append($"causándole {hechizo.Poder} puntos de daño.");
                    break;
                case "Curación":
                    sb.Append($"curándole {hechizo.Poder} puntos de vida.");
                    break;
            }
            sb.Append($" {objetivo.Nombre} quedó con {objetivo.HP} HP.");
            if (objetivo.isDead) 
            {
                sb.Append($" {objetivo.Nombre} ha muerto.\n {lanzador.Nombre} gana {objetivo.XP} puntos de Experiencia");
            }
            Console.WriteLine(sb.ToString());
        }
        public static void VerAtaqueYDefensa(Personaje personaje)
        //El metodo para "ver" (o como interpreteamos, "ver en consola") es delegada a la clase ConsoleLogger, ya que la responsabilidad de esta es devolver feedback al usuario
        //a través de la consola, por lo que va de la mano con esta tarea. Es una aplicación de patrón SRP.
        {
            Console.WriteLine($"{personaje.Nombre} tiene {personaje.Ataque} puntos de Ataque y {personaje.Defensa} puntos de Armadura");
        }

        public static void LevelUp(Personaje Leveleado)
        {
            Console.WriteLine($"{Leveleado.Nombre} sube de nivel y recupera todos sus puntos de vida!");
        }
        //para dar mas feedback al usuario de si se recupera un personaje por levelear

        public static void PrintWin()
        {
            Console.WriteLine($"¡Nuestros heroes ganan!");
        }
        public static void PrintFail()
        {
            Console.WriteLine($"Nuestro heroes han caido");
        }
    }
}
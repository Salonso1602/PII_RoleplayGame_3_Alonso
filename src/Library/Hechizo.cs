using System.Linq;

namespace Program {
    public class Hechizo {
        private static string[] tiposHechizos = {"Daño", "Curación"};
        public string Nombre { get; set; }
        private string tipoEfecto;
        public string TipoEfecto {
            get {
                return tipoEfecto;
            }
            set {
                if (tiposHechizos.Contains(value)) {
                    this.tipoEfecto = value;
                }
            }
        }
        public int Poder { get; set; }

        public Hechizo(string nombre, string tipoEfecto, int poder) 
        {
            this.Nombre = nombre;
            this.TipoEfecto = tipoEfecto;
            this.Poder = poder;
        }
    }
}
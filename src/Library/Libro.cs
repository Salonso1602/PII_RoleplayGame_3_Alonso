using System.Collections.Generic;
using System.Text;

namespace Program
{
    public class Libro : IItem
    {

        private List<Hechizo> hechizosGuardados = new List<Hechizo>();

        public List<Hechizo> HechizosGuardados 
        {
            get
            {
                return this.hechizosGuardados;
            }
        }

        public string Name {get;set;}
       
        public Libro (string nombre)
        {
            this.Name = nombre;
        }

        public void AñadirHechizo(Hechizo hechizo)
        {
            this.HechizosGuardados.Add(hechizo);
        }

        public string VerHechizosGuardados()
        {
            StringBuilder result = new StringBuilder();
            
            foreach (Hechizo spell in this.HechizosGuardados)
            {
                result.Append($" * {spell.Nombre} \n");
            }
            return result.ToString();
        }
    }
}
using System.Collections.Generic;

namespace Program
{
  public class Mago : Personaje , IPersonaje
  {
    public Mago(string nombre)
    {
      this.Nombre = nombre;
      this.HP = IPersonaje.K_maxHP;
    }

    public List<Hechizo> LibroEquipado
    {
      get
      {
        foreach (IItem item in Inventario)
        {
          if (item is Libro)
          {
          return (item as Libro).HechizosGuardados;
          }
        }
        return new Libro ("Libro vacío").HechizosGuardados;
      }
    }
  }
}
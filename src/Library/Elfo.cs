namespace Program
{
  public class Elfo : Personaje , IPersonaje
  {
    public Elfo(string nombre)
    {
      this.Nombre = nombre;
      this.HP = IPersonaje.K_maxHP;
    }
  }
}
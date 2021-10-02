namespace Program
{
  public class Enano : Personaje , IPersonaje
  {
    public Enano(string nombre)
    {
      this.Nombre = nombre;
      this.HP = IPersonaje.K_maxHP;
    }
  }
}
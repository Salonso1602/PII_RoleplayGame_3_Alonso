namespace Program
{
  public class Espada : Item
  {
    public override int DMG{get; protected set;}

    public Espada(string name, int dmg)
    {
      this.Name = name;
      this.DMG = dmg;
    }

  }
}

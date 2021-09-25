namespace Program
{
  public class Escudo : IItem, IDefense, IAttack
  {
    public string Name{get; set;}

    public int DEF{get; set;}

    public int DMG{get; set;}

    public Escudo(string name, int def, int dmg)
    {
      this.Name = name;
      this.DEF = def;
      this.DMG = dmg;
    }
  }
}

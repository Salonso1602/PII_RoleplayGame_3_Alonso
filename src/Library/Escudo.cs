namespace Program
{
  public class Escudo : Item, IItem, IDefense, IAttack
  {
    public override int DEF{get; protected set;}

    public override int DMG{get; protected set;}

    public Escudo(string name, int def, int dmg)
    {
      this.Name = name;
      this.DEF = def;
      this.DMG = dmg;
    }
  }
}

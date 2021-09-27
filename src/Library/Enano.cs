using System.Collections.Generic;

namespace Program
{
  public class Enano : IPersonaje
  {
    public string Nombre{get; set;}

    public int HP{get;set;}

    public List<IItem> Inventario{get;}

    public void AddItem(IItem item)
    {
      this.Inventario.Add(item);
    }
    public void RemoveItem(IItem item)
    {
      this.Inventario.Remove(item);
    }

    public IAttack Arma
    {
      get
      {
        IAttack mejorArma = new Espada ("Manos", 0);
        foreach (IItem item in Inventario)
        {
          if(item is IAttack && ((IAttack) item).DMG > mejorArma.DMG)
          {
            mejorArma = (IAttack) item;
          }
        }
        return mejorArma;
      }
    }
    public int Ataque 
    {
      get
      {
        return this.Arma.DMG + IPersonaje.K_AtaqueBase;
      }
    }
    public IDefense Armadura
    {
      get
      {
        IDefense mejorArmadura = new Pechera ("Desnudo", 0);
        foreach (IItem item in Inventario)
        {
          if(item is IDefense && ((IDefense) item).DEF > mejorArmadura.DEF)
          {
            mejorArmadura = (IDefense) item;
          }
        }
        return mejorArmadura;
      }
    }
    public int Defensa 
    {
      get
      {
        return Armadura.DEF + IPersonaje.K_DefensaBase;
      }
    }

    public Enano(string nombre)
    {
      this.Nombre = nombre;
      this.HP = IPersonaje.K_maxHP;
      this.Inventario = new List<IItem>{};
    }
  }
}
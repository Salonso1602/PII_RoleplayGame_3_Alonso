using System.Collections.Generic;

namespace Program
{
  public class Personaje
  //me ahorro definir todos estos atributos y metodos genericos para todo tipo de personaje, y facilita el desarrollo de nuevas clases solo definiendo sus particularidades
  {
    public string Nombre{get; set;}

    public int HP{get;set;}
    //va a representar los puntos de vide del personaje en el momento dado

    public int XP {get;set;}
    //uso el nombre xp como termino mas generico de los "Puntos de victoria" que pide el ejercicio. Significan Experience Points, o sea, puntos de Experiencia

    public virtual int K_AtaqueBase
    {
      get
      {
        return 5;
      }
    }

    public virtual int K_DefensaBase
    {
      get
      {
        return 5;
      }
    }
    public virtual int K_maxHP 
    {
      get
      {
        return 100;
      }
    }
    //hago estos stats virtuales para poder modificarlos de ser necesario, pero dejando un valor por defecto.

    public List<Item> Inventario{get;} = new List<Item>();

    public void AddItem(Item item)
    {
      this.Inventario.Add(item);
    }
    public void RemoveItem(Item item)
    {
      this.Inventario.Remove(item);
    }

    public Item Arma
    {
      get
      {
        Item mejorArma = new Espada ("Manos", 0);
        foreach (Item item in Inventario)
        {
          if(item.DMG>0 && item.DMG>mejorArma.DMG)
          {
            mejorArma = item;
          }
        }
        return mejorArma;
      }
    }
    public int Ataque 
    {
      get
      {
        return this.Arma.DMG + K_AtaqueBase;
      }
    }
    public Item Armadura
    {
      get
      {
        Item mejorArmadura = new Pechera ("Desnudo", 0);
        foreach (Item item in Inventario)
        {
          if(item.DEF > 0 && item.DEF > mejorArmadura.DEF)
          {
            mejorArmadura = item;
          }
        }
        return mejorArmadura;
      }
    }
    public int Defensa 
    {
      get
      {
        return this.Armadura.DEF + K_DefensaBase;
      }
    }
  }
}
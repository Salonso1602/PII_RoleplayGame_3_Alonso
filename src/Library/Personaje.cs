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

    public const int K_AtaqueBase = 5;

    public const int K_DefensaBase = 2;

    public const int K_maxHP = 100;

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
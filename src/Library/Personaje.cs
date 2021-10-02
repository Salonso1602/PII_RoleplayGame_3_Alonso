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

    public List<IItem> Inventario{get;} = new List<IItem>();

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
        return this.Arma.DMG + K_AtaqueBase;
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
        return this.Armadura.DEF + K_DefensaBase;
      }
    }
  }
}
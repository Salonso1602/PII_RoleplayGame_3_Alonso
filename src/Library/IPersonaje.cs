using System.Collections.Generic;

namespace Program
{
    public interface IPersonaje
    {
        public const int K_AtaqueBase = 5;

        public const int K_DefensaBase = 2;

        public const int K_maxHP = 100;

        public string Nombre{get; set;}

        public int HP{get; set;}

        public List<IItem> Inventario{get;}

        public void AddItem(IItem item);

        public void RemoveItem(IItem item);

        public IAttack Arma{get;}

        public IDefense Armadura{get;}
    }
}


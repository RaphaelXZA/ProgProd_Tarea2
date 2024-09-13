using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgYProduc_Tarea2
{
    internal abstract class Character
    {
        public int health;
        public int damage;

        public Character(int health, int damage)
        {
            this.health = health;
            this.damage = damage;
        }

        public abstract void GetHurt(int damageReceived);
        public abstract int CauseDamage();

        public abstract bool IsDead();
    }

}

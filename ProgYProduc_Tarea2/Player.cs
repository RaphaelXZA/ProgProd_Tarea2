using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgYProduc_Tarea2
{
    internal class Player : Character
    {
        public Player(int health, int damage) : base(health, damage)
        {
        }

        public override void GetHurt(int damageReceived)
        {
            health = Math.Max(0, health - damageReceived); 
        }

        public override int CauseDamage()
        {
            return damage;
        }

        public override bool IsDead()
        {
            return health <= 0;
        }
    }
}

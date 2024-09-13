using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgYProduc_Tarea2
{
    internal class EnemyRange : EnemyMelee
    {
        private int ammo; 

        public EnemyRange(int health, int damage, int ammo) : base(health, damage)
        {
            this.ammo = ammo;
        }

        public override int CauseDamage()
        {
            if (ammo > 0)
            {
                ammo--;
                return damage;
            }
            else
            {
                Console.WriteLine("No hay balas disponibles para atacar.");
                return 0;
            }
        }
    }
}

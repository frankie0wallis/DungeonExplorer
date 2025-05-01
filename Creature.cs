using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Creature : IDamageable
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public abstract void Attack(Creature target); // Abstract method for attacking another creature

        public abstract void TakeDamage(int damage); // Abstract method for taking damage
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Testing
    {
        public static void RunAllTests()
        {
            TestPlayerTakesDamage();
            TestPlayerAttacksMonster();
            TestGoblinAttack();
            TestOrcAttack();
            TestDragonAttack();
            TestMageAttack();

            Console.WriteLine("All tests passed.");
        }

        static void TestPlayerTakesDamage()
        {
            var player = new Player { Name = "Hero", Health = 100 };
            player.TakeDamage(25);
            Debug.Assert(player.Health == 75, "Player health should be reduced by 25.");
        }

        static void TestPlayerAttacksMonster()
        {
            var player = new Player { Name = "Hero", Health = 100 };
            var monster = new Goblin { Health = 50 };
            player.Attack(monster);
            Debug.Assert(monster.Health < 50, "Monster should have taken damage from attack.");
        }

        static void TestGoblinAttack()
        {
            var goblin = new Goblin();
            var player = new Player { Name = "Hero", Health = 100 };
            goblin.Attack(player);
            Debug.Assert(player.Health == 95, "Goblin should reduce player's health by 5.");
        }

        static void TestOrcAttack()
        {
            var orc = new Orc();
            var player = new Player { Name = "Hero", Health = 100 };
            orc.Attack(player);
            Debug.Assert(player.Health == 85, "Orc should reduce player's health by 15.");
        }

        static void TestDragonAttack()
        {
            var dragon = new Dragon();
            var player = new Player { Name = "Hero", Health = 100 };
            dragon.Attack(player);
            Debug.Assert(player.Health == 60, "Dragon should reduce player's health by 40.");
        }

        static void TestMageAttack()
        {
            var mage = new Mage();
            var player = new Player { Name = "Hero", Health = 100 };
            mage.Attack(player);
            Debug.Assert(player.Health == 85, "Mage should reduce player's health by 15 (10 + 5 magic).");
        }
    }
}

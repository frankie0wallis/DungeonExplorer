﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        private static Random random = new Random(); // Random generator for selecting random monsters
        private static List<Monster> possibleMonsters = new List<Monster> // List of possible monsters with different health and attack values
        {
            new Monster("Goblin", 10, 5),
            new Monster("Orc", 20, 10),
            new Monster("Troll", 30, 15),
            new Monster("Dragon", 50, 20),
            new Monster("Beholder", 40, 25),
            new Monster("Lich", 60, 30),
            new Monster("Balrog", 70, 35),
            new Monster("Chimera", 80, 40),
            new Monster("Hydra", 90, 45),
            new Monster("Kraken", 100, 50),
        };
        public Monster(string name, int health, int attack) // Constructor to initialize a monster with a name, health, and attack power
        {
            Name = name;
            Health = health;
            Attack = attack;
        }
        public static Monster GetRandomMonster() // Returns a random monster from the list of possible monsters
        {
            return possibleMonsters[random.Next(possibleMonsters.Count)];
        }
    }
}

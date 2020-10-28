using System;

namespace TextAdventure
{
    class Program
    {

        static void Main(string[] args)
        {         
            string name = "Archibald Douglas";
            Hero hero = new Hero(name);
            Console.WriteLine($"{hero}");
            Enemy enemy = new Enemy("test");
            Fight fight = new Fight(hero, enemy);
            //Console.WriteLine($"{enemy.getHealth()}");
            /*hero.takeDamage(35);
            Console.WriteLine($"{hero.getCurrentHealth()}/{hero.getMaxHealth()}");
            hero.healDamage(10);
            Console.WriteLine($"{hero.getCurrentHealth()}/{hero.getMaxHealth()}");
            hero.healDamage(200);
            Console.WriteLine($"{hero.getCurrentHealth()}/{hero.getMaxHealth()}");*/
            Story s = new Story(hero);
            //s.start();
            
        }

         

        public static int roll(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
        
    }
}

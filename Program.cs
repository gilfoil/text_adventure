using System;

namespace TextAdventure
{
    class Program
    {

        static void Main(string[] args)
        {
            // string name = "Archibald Douglas";
            // Hero hero = new Hero(name);
            // Console.WriteLine($"{hero}");
            // /*hero.takeDamage(35);
            // Console.WriteLine($"{hero.getCurrentHealth()}/{hero.getMaxHealth()}");
            // hero.healDamage(10);
            // Console.WriteLine($"{hero.getCurrentHealth()}/{hero.getMaxHealth()}");
            // hero.healDamage(200);
            // Console.WriteLine($"{hero.getCurrentHealth()}/{hero.getMaxHealth()}");*/          
        }

         

        public static int roll(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}

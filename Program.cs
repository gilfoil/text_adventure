using System;

namespace TextAdventure
{
    class Program
    {

        static void Main(string[] args)
        {         
            string name = "Archibald Douglas";
            string startTextAlpha = $@"Welcome, {name} ! You 
            arrive in a small little Town. Upon entering  
            the gates you are met with bewildered stares.
            You inspect yourself to find anything out of 
            the ordinary and notice that your clothes are
            old and rugged, hence the stares.";
            string startTextBeta = $@"Good Morning, {name.ToUpper()} !!!
            Since you are awake now you have to pay for the damages 
            you caused last night !";
            Hero hero = new Hero(name);
            int debt = hero.getCoins() + roll(10, 20);
            Console.WriteLine($"{hero}");
            Enemy enemy = new Enemy("test");
            //Fight fight = new Fight(hero, enemy);
            //Console.WriteLine($"{enemy.getHealth()}");
            /*hero.takeDamage(35);
            Console.WriteLine($"{hero.getCurrentHealth()}/{hero.getMaxHealth()}");
            hero.healDamage(10);
            Console.WriteLine($"{hero.getCurrentHealth()}/{hero.getMaxHealth()}");
            hero.healDamage(200);
            Console.WriteLine($"{hero.getCurrentHealth()}/{hero.getMaxHealth()}");*/
            Story s = new Story(hero);
            s.start();
            Console.WriteLine($"{hero}");
        }

         

        public static int roll(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }
        
    }
}

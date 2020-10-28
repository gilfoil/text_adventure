using System;
namespace TextAdventure
{

    public class Fight
    {
        private bool fighting = true;
        public Fight(Hero hero, Enemy enemy)
        {
            while (fighting)
            {
                string option = "";
                Console.WriteLine("Angriff Flucht Item");
                while ((option != "a") && (option != "f") && (option != "i"))
                {
                    option = Console.ReadLine().ToLower();
                }
                switch (option)
                {
                    case "a":
                        heroAttack(hero, enemy);
                        Console.WriteLine($"LPE: {enemy.getHealth()}");
                        if(enemy.getHealth() == 0) fighting = false;
                        enemyAttack(enemy, hero);
                        if(hero.getCurrentHealth() == 0) fighting = false;
                        Console.WriteLine($"LPH: {hero.getCurrentHealth()}");
                        break;

                    case "f":

                        break;

                    case "i":

                        break;
                    default:
                        Console.WriteLine($"Fehler bei Kampfoptionen: {option}");
                        break;

                }
            }


        }

        private void heroAttack(Hero hero, Enemy enemy)
        {
            int damage = hero.getStrenght() - enemy.getDefence();
            enemy.monsterDamage(damage);
        }

        private void enemyAttack(Enemy enemy, Hero hero)
        {
            int damage = enemy.getAttack();
            hero.takeDamage(damage);
        }

        private int escape(Hero hero, Enemy enemy)
        {
            if(hero.getDexterity() < enemy.getIntelligence()) return 1;
            else return 0;
        
        }
    }

}





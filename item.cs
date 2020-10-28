namespace TextAdventure
{
    
    public class Item
    {
        private const int BASE_UPGRADE_COST = 100;
        private int coins;
        private int[] upgrades;
    
    // Upgrade von Waffen 

    public class Weapon: Item
        {
            private int offense = 10;
            private int hit_chance = 2;
        }
    public class Armor: Item
    {
            private int defense = 20;
            private int dodge_chance = 5;
    }
    public class Wand: Item 
    {
            private int spell_damage = 5; 
    }

      public class Shield: Item
      { 
      private int shield_defense = 5;
      private int block_chance = 3;
      }

    }
}
// Kettenhemd, Lederrüstung, Mithriel, Stahlpanzer, 
// Großschwert, Streitaxt, Degen, Dolch
// Werte werden zufällig gerollt und bei bestimmten Werten kommt der Name vom Item raus

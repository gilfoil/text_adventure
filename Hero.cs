using static System.Random;

namespace TextAdventure
{
    public class Hero
    {
        private const int HEALTH_BASE = 50;

        private const int MIN_ROLL = 10;
        private const int MAX_ROLL = 20;

        private const int BASE_UPGRADE_COST = 100;
        private string name;
        private int currentHealth;
        private int maxHealth;
        private int strength;
        private int dexterity;
        private int intelligence;
        private int charisma;
        private Item.Weapon weapon;
        private Item.Armor armor;
        private Item.Wand wand;
        private Item.Shield shield;
        private int coins;

        private int[] upgrades;
        private int[] upgradesItems;

        public Hero(string heroName)
        {
            this.name = heroName;
            rollStats();
            setMaxHealth();
            this.currentHealth = this.maxHealth;
            this.upgrades = new int[] {1,1,1,1};
            this.upgradesItems = new int[] {1,1,1,1};
       }

        public void rollStats()
        {
            this.strength = Program.roll(MIN_ROLL, MAX_ROLL);
            this.dexterity = Program.roll(MIN_ROLL, MAX_ROLL);
            this.intelligence = Program.roll(MIN_ROLL, MAX_ROLL);
            this.charisma = Program.roll(MIN_ROLL, MAX_ROLL);
            this.coins = ((this.intelligence + this.charisma) / 2);
        }

        public void setMaxHealth()
        {
            this.maxHealth = HEALTH_BASE + (3 * strength) + (2 * dexterity);
        }

        public int getMaxHealth()
        {
            return this.maxHealth;
        }

        public override string ToString()
        {
            return $"|Name: {this.name}|\n|HP: {this.currentHealth}/{this.maxHealth}|\n|$$$: {this.coins}|\n|Strength: {this.strength}|\n|Dexterity: {this.dexterity}|\n|Intelligence: {this.intelligence}|\n|Charisma: {this.charisma}|\n";
        }

        public int getCurrentHealth() => this.currentHealth;
        public int getStrenght() => this.strength;
        public int getDexterity() => this.dexterity;
        public int getIntelligence() => this.intelligence;
        public int getCharisma() => this.charisma;

        public void takeDamage(int damage)
        {
            if(this.currentHealth <= damage)
            {
                this.currentHealth = 0;
                //game over
                // implement me :)
            }
            else
            {
                this.currentHealth -= damage;
            }
        }

        public void healDamage(int heal)
        {
            if((currentHealth + heal) > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += heal;
            }
        }

        public int getCoins() => this.coins;

        public bool changeBank(int coins)
        {

            if((this.coins + coins) < 0)
            {
                return false;
            }
            else
            {
                this.coins += coins;
                return true;
            }
        }

        public void changeStat(string stat)
        {
            switch (stat)
            {
                case "str":
                    if(changeBank(upgrades[0] * BASE_UPGRADE_COST))
                    {
                        this.strength += 1;
                        setMaxHealth();
                        upgrades[0] += 1;
                    }
                    else
                    {
                        //Error Message
                        //Implement me :)
                    }
                    break;
                case "dex":
                    if(changeBank(upgrades[1] * BASE_UPGRADE_COST))
                    {
                        this.dexterity += 1;
                        setMaxHealth();
                        upgrades[1] += 1;
                    }
                    else
                    {
                        //Error Message
                        //Implement me :)
                    }
                    break;
                case "int":
                    if(changeBank(upgrades[2] * BASE_UPGRADE_COST))
                    {
                        this.intelligence += 1;
                        upgrades[2] += 1;
                    }
                    else
                    {
                        //Error Message
                        //Implement me :)
                    }
                    break;
                case "cha":
                    if(changeBank(upgrades[3] * BASE_UPGRADE_COST))
                    {
                        this.charisma += 1;
                        upgrades[3] += 1;
                    }
                    else
                    {
                        //Error Message
                        //Implement me :)
                    }
                    break;
                default:
                    // Error Message
                    // Implement me :)
                    break;
            }
            
        }
      
        public void changeItem(string stat)
        {
                switch (stat)
                {
                case "Weapon":
                    if(changeBank(upgradesItems[0] * BASE_UPGRADE_COST))
                    {
                        weapon.offense += 20;
                        weapon.hit_chance +=5;
                        upgradesItems[0] += 1;
                    }
                    else
                    {
                        // Error Message
                        
                    }
                    break;
                case "Armor":
                    if(changeBank(upgradesItems[1] * BASE_UPGRADE_COST))
                    {
                         armor.defense += 20;
                         armor.dodge_chance += 5;
                        upgradesItems[1] += 1;
                    }
                    else
                    {
                        // Error Message
                    
                    }
                    break;
                case "Wand":
                    if(changeBank(upgradesItems[2] * BASE_UPGRADE_COST))
                    {
                        wand.spell_damage += 20;
                        upgradesItems[2] += 1;
                    }
                    else
                    {
                        // Error Message
                    }
                    break;
                case "Shield":
                    if(changeBank(upgradesItems[3] * BASE_UPGRADE_COST))
                    {
                        shield.shield_defense += 5;
                        shield.block_chance += 2;
                        upgradesItems[3] += 1;
                    }
                    else
                    {
                        // Error Message 
                    }
                    break;
                default:
                    // Error Message
                    // Implement me :)
                    break;
                }
        
        }
    }
}

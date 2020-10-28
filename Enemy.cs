namespace TextAdventure

{
    public class Enemy
    {
        // name, HP , Schaden, ausweichen
        private string type;
        private string name;
        private int health;
        private int attack;
        private int defence;
        private int dexterity;
        private int intelligence;
        private int coins;
        
        public Enemy(string mtype)
        {
            this.type = type;
            this.health = 30;
            this.attack = 5;
            this.defence = 5;
            this.dexterity = 5;
            this.intelligence = 5;
            this.coins = 5;
        }

       /*public void rollStats()
        {
            this.strength = Program.roll(MIN_ROLL, MAX_ROLL);
            this.dexterity = Program.roll(MIN_ROLL, MAX_ROLL);
            this.intelligence = Program.roll(MIN_ROLL, MAX_ROLL);
            this.charisma = Program.roll(MIN_ROLL, MAX_ROLL);
            this.coins = ((this.intelligence + this.charisma) / 2);
        }*/

        public void monsterDamage(int damage)
        {
            if(this.health < damage) this.health = 0;
            else this.health -= damage;
        }

        public int getHealth() => this.health;
        public int getAttack() => this.attack;
        public int getDefence() => this.defence;
        public int getDexterity() => this.dexterity;
        public int getIntelligence() => this.intelligence;
        public int getCoins() => this.coins;
        
    }
}

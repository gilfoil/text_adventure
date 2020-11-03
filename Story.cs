using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace TextAdventure
{
    class Story
    {
        public const char QUEST_ID_DELIM = '/';

        public const char OPTION_DELIM = '&';

        public const char CONSEQUENCE_DELIM = '#';
        public const int QID_HUB = 1;
        private int currentDay;

        private int currentQuest = 1;

        private bool isComplete;

        private string area = "Hub";

        private Hero hero;

        private Dictionary<int, Quest> quests;

        internal class Quest
        {
            private string text;
            List<Option> options;
            public Quest(string text, List<Option> options)
            {
                this.text = text;
                this.options = options;
            }

            public Quest(string text)
            {
                this.text = text;
                this.options = new List<Option>();
            }

            public void addOption(Option option)
            {
                this.options.Add(option);
            }

            public override string ToString()
            {
                string s = this.text;
                foreach (Option opt in this.options)
                {
                    s += $"\n|?|{opt}";
                }
                return s;
            }

            public Option getChoosen(int choice) => this.options[choice];
            
        }
        internal class Option
            {
                private string text;
                private string consequence;

                private int param = 0;

                private int nextQuest = 0;

                public Option(string text, string consequence)
                {
                    this.text = text;
                    this.consequence = consequence;
                }

                public Option(string text, string consequence, 
                                int param, int nextQuest)
                {
                    this.text = text;
                    this.consequence = consequence;
                    this.param = param;
                    this.nextQuest = nextQuest;
                }

                public override string ToString()
                {
                    return $"{this.text} -> {this.consequence} ({this.param})";
                }

                public void setParam(int param)
                {
                    this.param = param;
                }

                public int getParam() => this.param;

                public void setNextQuest(int nextQuest)
                {
                    this.nextQuest = nextQuest;
                }
                public int getNextQuest() => this.nextQuest;

                public string getConsequence() => this.consequence;
            }
        public Story(Hero hero)
        {
            this.hero = hero;
            this.quests = new Dictionary<int, Quest>();
            //setupHubQuest();
            //setupItemShop();
            loadFromFile("town.txt");
            this.quests[QID_HUB].addOption(
                new Option("Go Back!", "Goto", currentQuest, 0));
            loadFromFile("test.txt");
            Console.WriteLine($"Loaded Quests: {this.quests.Count}");
        }

        /*private void setupHubQuest()
        {
            string hubText = @"You arrive in the 
            center of the small town. At every corner there 
            is something to see or someone trying to sell you 
            something. Where do you want to go?";
            Option tavern = new Option("To the tavern!", 
            "Goto", QID_TAVERN, 0);
            Option itemShop = new Option("To the Item Shop!", 
            "Goto", QID_ITEM_SHOP, 0);
            Option enchantShop = new Option("To the Enchantment Shop!", 
            "Goto", QID_ENCHANT_SHOP, 0);
            Option attrShop = new Option("To the Skill Trainer!", 
            "Goto", QID_ATTR_SHOP, 0);
            Option backToQuest = new Option("Go Back!", "Goto", this.currentQuest, 0);
            List<Option> hubOptions = new List<Option>() {tavern, itemShop, enchantShop, attrShop};
            Quest hubQuest = new Quest(hubText, hubOptions);
            this.quests.Add(QID_HUB, hubQuest);
        }

        private void setupItemShop()
        {
            //Buy
            //Upgrade
            string itemShopText = @"You arrive in a worn 
            down storage room, as your eyes are getting 
            used to the light you notice a small figure 
            in the corner gesturing in your direction to 
            come closer and look at the goods.";
            Option buySword = new Option("Buy Sword", "Buy", 125, QID_ITEM_SHOP);
            Option buyArmor = new Option("Buy Armor", "Buy", 500, QID_ITEM_SHOP);
            Option buyWand = new Option("Buy Magic Wand", "Buy", 1500, QID_ITEM_SHOP);
            Option buyShield = new Option("Buy Shield", "Buy", 200, QID_ITEM_SHOP);
            Option back = new Option("Back to the Hub", "Hub", 0, 0);
            this.quests.Add(QID_ITEM_SHOP, 
            new Quest(itemShopText, new List<Option>()
            {buySword, buyArmor, buyWand, buyShield}));
        }*/

        private void setupSkillTrainer()
        {

        }
        private void addQuestAt(Quest quest, int id)
        {
            this.quests[id] = quest;
        }

        private bool loadFromFile(string fPath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fPath))
                {
                    string line;
                    string questText = "";
                    int questId = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //Console.WriteLine(line);

                        if(!line.StartsWith(OPTION_DELIM))
                        {
                            
                            string[] questInfo = line.Split(QUEST_ID_DELIM);
                            if(questInfo.Length > 1)
                            {
                                questId = Convert.ToInt32(questInfo[0]);
                                questText = questInfo[1];
                            }
                            else
                            {
                                questText += questInfo[0];
                            }
                        }
                        else if(string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line))
                        {
                            // Do nothing
                        }
                        else
                        {
                            //Console.WriteLine($"Quest: {questText}");
                            try
                            {
                                // just used to trigger KeyNotFoundException for first quest
                                Quest bla = this.quests[questId];
                            }
                            catch(System.Collections.Generic.KeyNotFoundException keyNotFound)
                            {
                                //Console.WriteLine(keyNotFound);
                                this.quests[questId] = new Quest(questText);
                            }
                            string[] optionInfo = line.Split(CONSEQUENCE_DELIM);
                            string optionText = "";
                            if(optionInfo.Length > 1)
                                {
                                    optionText = optionInfo[0];
                                    string consequence = optionInfo[1];
                                    string[] param = consequence.Split(" ");
                                    Option parsedOption = null;
                                    if(param.Length > 1)
                                    {
                                        consequence = param[0];
                                        parsedOption = new Option(optionText, consequence);
                                        int val = Convert.ToInt32(param[1]);
                                        parsedOption.setParam(val);
                                        if(param.Length == 3)
                                        {
                                            int next = Convert.ToInt32(param[2]);
                                            parsedOption.setNextQuest(next);
                                        }
                                    }
                                    else
                                    {
                                        parsedOption = new Option(optionText, consequence);
                                    }
                                    
                                    //Console.WriteLine($"Option: {optionText} -> {consequence}");
                                    this.quests[questId].addOption(parsedOption);

                                }
                                else
                                {
                                    optionText += optionInfo[0];
                                }
                            
                            

                        }
                         
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
                return false;
            }
        }

        private void runQuest(Quest q)
        {
            /*foreach(var quest in this.quests)
            {
                Console.WriteLine(quest);
                var input = Console.ReadKey();

            }*/
            Console.WriteLine(q);
            var input = Console.ReadLine();
            resolveChoice(q.getChoosen(Convert.ToInt32(input.ToString())));
        }

        private void resolveChoice(Option option)
        {
            switch(option.getConsequence())
            {
                case "Goto":
                    currentQuest = option.getParam();
                    runQuest(this.quests[currentQuest]);
                    break;
                case "Encounter":
                    Enemy enemy = new Enemy("test");
                    Fight fight = new Fight(this.hero, enemy);
                    runQuest(this.quests[option.getParam()]);
                    break;
                case "Hub":
                    //player can go back to hub for stuff
                    //player can resume quest after using hub
                    runQuest(this.quests[QID_HUB]);
                    break;
                case "Coins":
                    this.hero.changeBank(option.getParam());
                    runQuest(this.quests[option.getNextQuest()]);
                    break;
                case "Buy":
                    if(this.hero.changeBank(option.getParam()))
                    {
                        switch(option.getParam())
                        {
                            case 125:
                                this.hero.setWeapon(new Item.Weapon());
                                break;
                            case 200:
                                this.hero.setShield(new Item.Shield());
                                break;
                            case 500:
                                this.hero.setArmor(new Item.Armor());
                                break;
                            case 1500:
                                this.hero.setWand(new Item.Wand());
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You're broke, dude...");
                    }
                    runQuest(this.quests[option.getNextQuest()]);
                    break;
                default:
                    //NYI
                    break;
            }
        }

        public void start()
        {
            runQuest(this.quests[this.currentQuest]);
        }

    }
}
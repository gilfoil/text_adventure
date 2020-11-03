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
        private int currentDay;

        private int currentQuest = 1;

        private bool isComplete;


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
            loadFromFile("test.txt");
            Console.WriteLine($"Loaded Quests: {this.quests.Count}");
            /*if(this.quests.Count > 0)
            {
                runQuest(this.quests[0]);
            }
            else
            {
                Console.WriteLine("Failed to load quests :(");
            }*/
            //runQuest(this.quests[this.currentQuest]);
            /*foreach (var quest in this.quests)
            {
                Console.WriteLine(quest);
            }*/
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
                    runQuest(this.quests[option.getParam()]);
                    break;
                case "Encounter":
                    //NYI
                    break;
                case "Hub":
                    //NYI
                    break;
                case "Coins":
                    this.hero.changeBank(option.getParam());
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
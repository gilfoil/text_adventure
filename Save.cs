using System;
using System.IO;
using System.Text;

namespace SaveLoadAdventure
{
    public class Save
    {
        /*
        string currentHealth1 = currentHealth.ToString();
        string maxHealth1 = maxHealth.ToString();
        string strength1 = strength.ToString();
        string dexterity1 = dexterity.ToString();
        string intelligence1 = intelligence.ToString();
        string charisma1 = charisma.ToString();
        */

        string currentHealth1 = "200";
        string maxHealth1 = "300";
        string strength1 = "400";
        string dexterity1 = "500";
        string intelligence1 = "600";
        string charisma1 = "700";

        string value_all_saved;
        string values;
        string Saveadress = @"C:\Users\Administrator\Desktop\Jan\SpielA\text_adventure\mySaveFile.txt";

        public Save()
        {
            value_all_saved = string.Join( "\u001F", currentHealth1, maxHealth1, strength1, dexterity1, intelligence1, charisma1);
            values =  value_all_saved;
            File.WriteAllText(Saveadress, values, Encoding.UTF8);
        }
    }
    public class Load
    {
        string[] lines = File.ReadAllLines(@"C:\Users\Administrator\Desktop\Jan\SpielA\text_adventure\mySaveFile.txt");
        
    }
}
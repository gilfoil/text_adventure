using System;

namespace TextAdventure
{
    public class ench
    {
        public int Chance { get; set; }
        public string Name { get; set; }
        public int Req { get; set; }

        public ench(string name, int chance, int req)
        {
            Name = name;
            Chance = chance;
            Req = req;
        }

        public bool requirements(int intelligence)
        {
            if (intelligence > this.Req)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CritEffect()
        {
            var dice = Program.roll(1, 100);
            if (dice < this.Chance)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
        public int BlockBlindEffect()
        {
            var dice = Program.roll(1, 100);
            if (dice < this.Chance)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }


    }
}
//         Weapons Schwert = new Weapons("Schwert",50,40);            
//             Console.WriteLine($"Name = {Schwert.Name} Attack = {Schwert.Attack}",Schwert.Defence);

//             ench Blind = new ench("Blind", 10, 1);
//             ench Crit = new ench("Crit", 25, 1);
//             ench Block = new ench("Block", 20, 10);
           

//             if(Block.requirements(19)==true){
//                var d = Schwert.Attack*Crit.CritEffect();
//                Console.WriteLine(d);
//             }   
//             else{
//                 Console.WriteLine(Schwert.Attack);
//             }
// // // var c = Block.requirements(9);
            // // Console.WriteLine(c);
            // int a = Crit.CritEffect();
            // // Console.WriteLine(a);
            // int b = Block.BlockBlindEffect();
            // // Console.WriteLine(b);      
// // -> Verzauberungen
// // 	15% Chance 200% Schaden zu machen
// // 	15% Chance Schaden Gegner zu blocken
// // 	5% Chance auf Erblinden (Gegner)

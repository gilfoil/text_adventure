// using System;

// namespace TextAdventure
// {
//     public class Weapons
//     {
//         public string Name { get; set; }
//         public int Attack { get; set; }
//         public int Defence { get; set; }
//         public Weapons(string name, int attack, int defence)
//         {
//             Name = name;
//             Attack = attack;
//             Defence = defence;
//         }
  
//     }

//     public class ench{
//         public int Chance { get; set; }
//         public string Name { get; set; }
//         public int Req { get; set; }

//         public ench(string name, int chance,  int req)
//         {
//             Name = name;
//             Chance = chance;
//             Req = req;
//         }

//        public bool requirements(int intelligence){
//         if (intelligence > this.Req){          
//            return true;
//         }
//         else{
//            return false;
//         }
//        }

//        public int CritEffect(){
//            var dice = Program.roll(1, 100);
//            if(dice < this.Chance){
//             return 2;
//            }
//            else{
//                return 1;
//            }
//        }
//        public int BlockBlindEffect(){
//            var dice = Program.roll(1, 100);
//            if(dice < this.Chance){
//             return 0;
//            }
//            else{
//                return 1;
//            }
//        }

//     }
// }

using System;
using System.Collections.Generic;
using System.Linq;

namespace CardProject
{
    public class Deck
    {
        private List<Card> Cards = new List<Card>();
        
        public Deck(){
            this.Cards = _generateStandard();
        }
        
        public void _printCards(){
            foreach (var v in Cards){
                Console.WriteLine(v._value + " of " + v._type);
            }
        }

        public Card _draw(){
            Card returnCard = Cards[0];
            Cards.RemoveAt(0);
            return returnCard;
        }

        public void _shuffleDeck(int iterations){
            Random rnd = new Random();
            List<Card> Shuffled = new List<Card>();
            int listLength = Cards.Count;
            
            for (int j = 0; j < iterations; j++){
                for (int i = 0; i < listLength; i++){
                    int rndx = rnd.Next(0,listLength);
                    Shuffled.Add(Cards[rndx]);
                    Cards.RemoveAt(rndx);
                    listLength -= 1;
                    i -= 1;
                    listLength = Cards.Count;
                }
            }
            Cards = Shuffled;
        }

        public void _cutDeck(int cutPos){
            List<Card> Cut_A = new List<Card>();
            List<Card> Cut_B = new List<Card>();
            int listLength_0 = Cards.Count;
            
            for (int i = 0; i < cutPos; i++){
                Cut_A.Add(Cards[i]);
            }
            for (int i = cutPos; i < listLength_0; i++){
                Cut_B.Add(Cards[i]);
            }
            Cut_B.AddRange(Cut_A);
            Cards.Clear();
            this.Cards = Cut_B;
        }

        public void _trimDeck(string trimType){
            int listLength = Cards.Count;
            for (int i = 0; i < listLength; i++){
                if (Cards[i]._type != trimType){
                    Cards.RemoveAt(i);
                    listLength -= 1;
                    i -= 1;
                } 
            }
        }
        
        private List<Card> _generateStandard(){
            List<Card> newCards = new List<Card>();
            Card   _obj;
            string type_  = "";
            string value_ = "";
            
            for (int type = 1; type <= 4; type ++){
                for (int ca = 2; ca <= 14; ca++){
                    switch(type){
                        case 1: type_ = "Hearts";   break;
                        case 2: type_ = "Diamonds"; break;
                        case 3: type_ = "Clubs";    break;
                        case 4: type_ = "Spades";   break;
                    }
                    value_ = ca == 11 ? "(J)" : 
                            (ca == 12 ? "(Q)" : 
                            (ca == 13 ? "(K)" : 
                            (ca == 14 ? "(A)" : Convert.ToString(ca))));
                        
                    _obj = new Card(type_, value_);
                    newCards.Add(_obj);
                }
            }
            return newCards;
        }
    }
}

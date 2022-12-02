using System;
using System.Threading;
using System.Collections.Generic;

namespace CardProject
{
    static class Dialogue
    {
        public static void _EntryDLG(){
            Box StartBox = new Box(40,6,2,1);
            
            StartBox._write("This is BLACKJACK!          Do you want to play a round? YES(y) / NO(n)");
            _MenuStartEnd(StartBox);
        }
        
        private static void _MenuStartEnd(Box StartBox){ 
            string reply = Convert.ToString(Console.ReadLine());
            if (reply == "y"){
                StartBox._clear();
                StartBox._write("Great! Prepare to die!!!");
                Thread.Sleep(500);
                Console.Clear();
                _GameBegin();
            }
            else if (reply == "n"){
                StartBox._clear();
                StartBox._write("Aight, maybe next time! See ya, bud.");
                Thread.Sleep(500);
                Console.Clear();
                Console.SetCursorPosition(0,0);
            }
            else{
                StartBox._clear();
                StartBox._write("Huh. I didn't get that. Repeat?"); 
                _MenuStartEnd(StartBox);
            }
        }

        private static void _GameBegin(){
            CardSlot DealerSlot_0 = new CardSlot(5,8);  CardSlot HandSlot_0 = new CardSlot(5,15);
            CardSlot DealerSlot_1 = new CardSlot(11,8); CardSlot HandSlot_1 = new CardSlot(11,15);
            CardSlot DealerSlot_2 = new CardSlot(17,8); CardSlot HandSlot_2 = new CardSlot(17,15);
            CardSlot DealerSlot_3 = new CardSlot(23,8); CardSlot HandSlot_3 = new CardSlot(23,15);
            CardSlot DealerSlot_4 = new CardSlot(29,8); CardSlot HandSlot_4 = new CardSlot(29,15);
            
            List<CardSlot> DealerSlots = new List<CardSlot>();
            List<CardSlot> HandSlots = new List<CardSlot>();
            
            DealerSlots.Add(DealerSlot_0); DealerSlots.Add(DealerSlot_1); DealerSlots.Add(DealerSlot_2); DealerSlots.Add(DealerSlot_3); DealerSlots.Add(DealerSlot_4);
            HandSlots.Add(HandSlot_0); HandSlots.Add(HandSlot_1); HandSlots.Add(HandSlot_2); HandSlots.Add(HandSlot_3); HandSlots.Add(HandSlot_4);
            
            int handActiveSloteSlot = 2; // player active slot
            int dealerActiveSlot = 2; // dealer active slot
            
            int pStrength = 0;
            int dStrength = 0;
            
            Box DealerBox  = new Box(40,6,2,1);
            Deck _Deck = new Deck();
            Hand _Hand = new Hand();
            Dealer _Dealer = new Dealer();
            
            _Deck._shuffleDeck(200);
            
            _Dialogue("Let's begin. I'll shuffle the deck and distribute.", DealerBox);
            _Dialogue("One for me.", DealerBox);
            _Dealer._Cards.Add(_Deck._draw());
            dlgtx._drwcrd(DealerSlot_0.x,DealerSlot_0.y,"DOWN", _Dealer._Cards[0]);
            
            _Dialogue("...one for you.", DealerBox);
            _Hand._Cards.Add(_Deck._draw()); 
            dlgtx._drwcrd(HandSlot_0.x,HandSlot_0.y,"UP", _Hand._Cards[0]);
          
            _Dialogue("Me again. Face up.", DealerBox);
            _Dealer._Cards.Add(_Deck._draw());
            dlgtx._drwcrd(DealerSlot_1.x,DealerSlot_1.y,"UP",_Dealer._Cards[1]);
          
            _Dialogue("Last one goes to you. Now what?", DealerBox);
            _Hand._Cards.Add(_Deck._draw());
            dlgtx._drwcrd(HandSlot_1.x,HandSlot_1.y,"UP",_Hand._Cards[1]);
            
            Box PlrBx = new Box(40,6,2,20);
            PlrBx._write("Hit(h) || Stand(s)");
            _resetCursorPosition();
           
            while (true){
                string input = Convert.ToString(Console.ReadLine());
                string dlrInput = "";
                pStrength = 0;
                dStrength = 0;

                if (input == "h"){
                    _Hand._Cards.Add(_Deck._draw());
                    dlgtx._drwcrd(HandSlots[handActiveSloteSlot].x,HandSlots[handActiveSloteSlot].y,"UP",_Hand._Cards[handActiveSloteSlot]);
                    handActiveSloteSlot += 1;
                    _resetCursorPosition();
                    Thread.Sleep(400);
                }
                
                pStrength = _Hand._getStrengthCheck();
                
                if (pStrength > 21){
                    _resetCursorPosition();
                    dlgtx._dlyout("! ! ! BUSTED ! ! !");
                    _Dialogue("HA! Played yourself, BOY.", DealerBox);
                    Thread.Sleep(800);
                    Console.Clear();
                    break;
                }
                
                dStrength = _Dealer._getStrengthCheck();
                
                if (dStrength < 16){
                    _Dealer._Cards.Add(_Deck._draw());
                    dlgtx._drwcrd(DealerSlots[dealerActiveSlot].x, DealerSlots[dealerActiveSlot].y,"UP",_Dealer._Cards[dealerActiveSlot]);
                    dealerActiveSlot += 1;
                    dlrInput = "DRAW";
                }
                else if (dStrength >= 16 && dlrInput != "HOLD"){
                    _Dialogue("I'll hold.",DealerBox);
                    dlrInput = "HOLD";
                }
                
                if (input == "s" && dlrInput == "HOLD"){
                    _Dialogue("Aight. I'll reveal my cards.",DealerBox);
                    dlgtx._drwcrd(DealerSlots[0].x,DealerSlots[0].y,"UP",_Dealer._Cards[0]);
                    
                    if (pStrength == dStrength){
                        _Dialogue("Damn. It's a tie... maybe we try again.",DealerBox);
                    }
                    else if (pStrength > dStrength){
                        _Dialogue("GODDAMN. YOU WON.",DealerBox);
                    }
                    else if (pStrength < dStrength){
                        _Dialogue("HA! I WON. EASY AS PIE YOU FOOL.",DealerBox);
                    }
                    else{}
                    Thread.Sleep(1000);
                    break;
                }
                _resetCursorPosition();
            }
        }
        
        private struct CardSlot{
            public int x, y; 
            public CardSlot(int x, int y){
                this.x = x; this.y = y;
            }
        }
        
        private static void _resetCursorPosition(){
            Console.SetCursorPosition(3,23);
        }
        
        private static void _Dialogue(string text, Box DealerBox){
            Thread.Sleep(400);
            DealerBox._clear();
            DealerBox._write(text);
            Thread.Sleep(300); 
        }
    }
}

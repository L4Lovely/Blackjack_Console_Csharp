using System;
using System.Threading;
using System.Collections.Generic;

namespace CardProject
{
    static class Dialogue
    {
        static int pInpPos_x = 41;
        static int pInpPos_y = 20;

        public static void _EntryDLG(){
            Box StartBx = new Box(40,6,2,1);
            
            StartBx._write("This is BLACKJACK!          Do you want to play a round? YES(y) / NO(n)");
            _MenuStartEnd(StartBx);
        }
        
        private static void _MenuStartEnd(Box StartBx){ 
            string reply = Convert.ToString(Console.ReadLine());
            if (reply == "y"){
                StartBx._clear();
                StartBx._write("Great! Prepare to die!!!");
                Thread.Sleep(500);
                Console.Clear();
                _GameBegin();
            }
            else if (reply == "n"){
                StartBx._clear();
                StartBx._write("Aight, maybe next time! See ya, bud.");
                Thread.Sleep(500);
                Console.Clear();
                Console.SetCursorPosition(0,0);
            }
            else{
                StartBx._clear();
                StartBx._write("Huh. I didn't get that. Repeat?"); 
                _MenuStartEnd(StartBx);
            }
        }

        private static void _GameBegin(){
            CardSlot DlrSlt_0 = new CardSlot(5,8);  CardSlot PlrSlt_0 = new CardSlot(5,15);
            CardSlot DlrSlt_1 = new CardSlot(11,8); CardSlot PlrSlt_1 = new CardSlot(11,15);
            CardSlot DlrSlt_2 = new CardSlot(17,8); CardSlot PlrSlt_2 = new CardSlot(17,15);
            CardSlot DlrSlt_3 = new CardSlot(23,8); CardSlot PlrSlt_3 = new CardSlot(23,15);
            CardSlot DlrSlt_4 = new CardSlot(29,8); CardSlot PlrSlt_4 = new CardSlot(29,15);
            
            List<CardSlot> Dslts = new List<CardSlot>();
            List<CardSlot> Pslts = new List<CardSlot>();
            
            Dslts.Add(DlrSlt_0); Dslts.Add(DlrSlt_1); Dslts.Add(DlrSlt_2); Dslts.Add(DlrSlt_3); Dslts.Add(DlrSlt_4);
            Pslts.Add(PlrSlt_0); Pslts.Add(PlrSlt_1); Pslts.Add(PlrSlt_2); Pslts.Add(PlrSlt_3); Pslts.Add(PlrSlt_4);
            
            int pactiv = 2; // player active slot
            int dactiv = 2; // dealer active slot
            
            int pStrength = 0;
            int dStrength = 0;
            
            Box DlrBx  = new Box(40,6,2,1);
            Deck _Deck = new Deck();
            Hand _Hand = new Hand();
            Dealer _Dealer = new Dealer();
            
            _Deck._shuffleDeck(200);
            
            _Dialogue("Let's begin. I'll shuffle the deck and distribute.", DlrBx);
            _Dialogue("One for me.", DlrBx);
            _Dealer._Cards.Add(_Deck._draw());
            dlgtx._drwcrd(DlrSlt_0.x,DlrSlt_0.y,"DOWN", _Dealer._Cards[0]);
            
            _Dialogue("...one for you.", DlrBx);
            _Hand._Cards.Add(_Deck._draw()); 
            dlgtx._drwcrd(PlrSlt_0.x,PlrSlt_0.y,"UP", _Hand._Cards[0]);
          
            _Dialogue("Me again. Face up.", DlrBx);
            _Dealer._Cards.Add(_Deck._draw());
            dlgtx._drwcrd(DlrSlt_1.x,DlrSlt_1.y,"UP",_Dealer._Cards[1]);
          
            _Dialogue("Last one goes to you. Now what?", DlrBx);
            _Hand._Cards.Add(_Deck._draw());
            dlgtx._drwcrd(PlrSlt_1.x,PlrSlt_1.y,"UP",_Hand._Cards[1]);
            
            Box PlrBx = new Box(40,6,2,20);
            PlrBx._write("Hit(h) || Stand(s)");
            _rstplrcrsr();
           
            while (true){
                string input = Convert.ToString(Console.ReadLine());
                string dlrInput = "";
                pStrength = 0;
                dStrength = 0;

                if (input == "h"){
                    _Hand._Cards.Add(_Deck._draw());
                    dlgtx._drwcrd(Pslts[pactiv].x,Pslts[pactiv].y,"UP",_Hand._Cards[pactiv]);
                    pactiv += 1;
                    _rstplrcrsr();
                    Thread.Sleep(400);
                }
                
                pStrength = _Hand._getStrengthCheck();
                
                if (pStrength > 21){
                    _rstplrcrsr();
                    dlgtx._dlyout("! ! ! BUSTED ! ! !");
                    _Dialogue("HA! Played yourself, fool.", DlrBx);
                    Thread.Sleep(800);
                    Console.Clear();
                    break;
                }
                
                dStrength = _Dealer._getStrengthCheck();
                
                if (dStrength < 16){
                    _Dealer._Cards.Add(_Deck._draw());
                    dlgtx._drwcrd(Dslts[dactiv].x, Dslts[dactiv].y,"UP",_Dealer._Cards[dactiv]);
                    dactiv += 1;
                    dlrInput = "DRAW";
                }
                else if (dStrength >= 16 && dlrInput != "HOLD"){
                    _Dialogue("I'll hold.",DlrBx);
                    dlrInput = "HOLD";
                }
                
                if (input == "s" && dlrInput == "HOLD"){
                    _Dialogue("Aight. I'll reveal my cards.",DlrBx);
                    dlgtx._drwcrd(Dslts[0].x,Dslts[0].y,"UP",_Dealer._Cards[0]);
                    
                    if (pStrength == dStrength){
                        _Dialogue("Damn. It's a tie... maybe we try again.",DlrBx);
                    }
                    else if (pStrength > dStrength){
                        _Dialogue("GODDAMN. YOU WON.",DlrBx);
                    }
                    else if (pStrength < dStrength){
                        _Dialogue("HA! I WON. EASY AS PIE YOU FOOL.",DlrBx);
                    }
                    else{}
                    Thread.Sleep(1000);
                    break;
                }
                _rstplrcrsr();
            }
        }
        
        private struct CardSlot{
            public int x, y; 
            public CardSlot(int x, int y){
                this.x = x; this.y = y;
            }
        }
        
        private static void _rstplrcrsr(){
            Console.SetCursorPosition(3,23);
        }
        
        private static void _Dialogue(string text, Box DlrBx){
            Thread.Sleep(400);
            DlrBx._clear();
            DlrBx._write(text);
            Thread.Sleep(300); 
        }
    }
}

using System;
using System.Collections.Generic;

namespace CardProject
{
    public class Dealer
    {
        public List<Card> _Cards = new List<Card>();
        public int _Strength;
        
        public int _getStrengthCheck(){
            int strval = _getStrVal();
            
            foreach (var card in _Cards){
                if (card._value == "(A)" && strval > 21){
                    card._strength = 1;
                }
            }
            return _getStrVal();
        }
        
        private int _getStrVal(){
            int strval = 0;
            for (int i = 0; i < this._Cards.Count; i++){
                strval += _Cards[i]._strength;
            }
            return strval;
        }
    }
}

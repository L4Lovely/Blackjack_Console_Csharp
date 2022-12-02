using System;

namespace CardProject
{
    public class Card
    {  
        public string _type;  // spades, hearts ..
        public string _value; // 1..10..Queen..Ace
        public string _symbol;
        public int    _strength;

        public Card(string typeval, string valueval){
        this._type     = typeval;
        this._value    = valueval;
        this._strength = _calculateStrength();
        _setSymbol(typeval);
        }

        public int _getStrength(){
            return this._strength;
        }
        
        private int _calculateStrength(){
            int _strVal;
            if      (this._value == "(J)") { _strVal = 10; }
            else if (this._value == "(Q)") { _strVal = 10; }
            else if (this._value == "(K)") { _strVal = 10; }
            else if (this._value == "(A)") { _strVal = 11; }
            else  { _strVal = Convert.ToInt32(this._value);}
            return _strVal;
        }

        private void _setSymbol(string symbol){
            if      (symbol == "Hearts")   { this._symbol = "♥"; }
            else if (symbol == "Clubs")    { this._symbol = "♣"; }
            else if (symbol == "Spades")   { this._symbol = "♠"; }
            else if (symbol == "Diamonds") { this._symbol = "♦"; }
        }
    }
}
//╭───╮
//│10 │
//│ ♥ │
//╰───╯

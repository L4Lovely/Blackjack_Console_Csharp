using System;
using System.Collections.Generic;
namespace CardProject
{
    public class Box
    {
        private int _width;
        private int _height;
        private int _xpos;
        private int _ypos;

        private int _max_Cw;
        private int _max_Ch;
        private int _crsbgn_x;
        private int _crsbgn_y;


        public Box(int width, int height, int xpos, int ypos){
            this._width    = width;
            this._height   = height;
            this._xpos     = xpos;
            this._ypos     = ypos;
            this._max_Cw   = width - 2;
            this._max_Ch   = height - 2;
            this._crsbgn_x = _xpos + 1;
            this._crsbgn_y = _ypos + 1;
            _draw();
        }

        public void _write(string _text){
            List<string> textRows = new List<string>();
            string text = _text;
            string parseString = "";
            int textIndex = 0;
           
            int rowsRequired = text.Length / _max_Ch;
            for (int currentRow = 0; currentRow < rowsRequired; currentRow++){ 
                if (text.Length > _max_Cw){
                    for (textIndex = 0; textIndex < _max_Cw; textIndex++){
                        parseString += text[textIndex];
                    }
                }
                else if (text.Length < _max_Cw){
                    for (textIndex = 0; textIndex < text.Length; textIndex++){
                        parseString += text[textIndex];
                    }
                }
                textRows.Add(parseString);
                parseString = "";
                text = text.Remove(0,textIndex);
                textIndex = 0;
            }
            
            for (int x = 0; x < rowsRequired; x++){
                Console.SetCursorPosition(_crsbgn_x, _crsbgn_y + x);
                dlgtx._dlyout(textRows[x]);
            }
        }
            
        public void _draw(){
            dlgtx._drwbx(_width,_height,_xpos,_ypos,"N");
        }

        public void _clear(){
            dlgtx._clrsqr(_width,_height,_xpos,_ypos); 
        }
    }
}

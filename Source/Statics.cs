using System;
using System.Threading;

namespace CardProject
{
    static class dlgtx // dlgtx = dialogue text outputs
    {
        // delayed text output
        public static void _dlyout(string input){
            for (int i = 0; i < input.Length; i++){
                Console.Write(input[i]);
                Thread.Sleep(25);
            }
        }

        public static void _clrsqr(int width, int height, int xpos, int ypos){
            for (int y = ypos; y < height + ypos; y++){
                for (int x = xpos; x < width + xpos; x++){
                    if ((y > ypos && y < (height - 1) + ypos) && (x > xpos && x < (width - 1) + xpos)){
                        Console.SetCursorPosition(x,y);
                        Console.Write(" ");
                    }
                }
            }
        }

        public static void _drwbx(int width, int height, int xpos, int ypos, string bkgd){
            for (int y = ypos; y < height + ypos; y++){
                for (int x = xpos; x < width + xpos; x++ ){
                    if (y == ypos || y == (height - 1) + ypos){
                        Console.SetCursorPosition(x,y);
                        Console.Write("─");
                    }
                    if (x == xpos || x == (width - 1) + xpos){
                        Console.SetCursorPosition(x,y);
                        Console.Write("│");
                    }
                    if (bkgd == "Y") {
                        if (x != xpos && y != ypos && x != xpos + (width - 1) && y != ypos + (height - 1)){
                            Console.SetCursorPosition(x,y);
                            Console.Write("░");
                        }
                    }
                }
            }
            Console.SetCursorPosition(xpos, ypos);         Console.Write("┌");
            Console.SetCursorPosition(xpos + (width - 1), ypos);     Console.Write("┐");
            Console.SetCursorPosition(xpos, ypos + (height - 1));     Console.Write("└");
            Console.SetCursorPosition(xpos + (width - 1), ypos + (height - 1)); Console.Write("┘");
        }

        public static void _drwcrd(int xpos, int ypos, string face, Card card){
            int height = 4;
            int width  = 5;
            
            if (face =="DOWN"){ 
                _drwbx(width, height, xpos, ypos, "Y");
            }
            else if (face == "UP"){
                _drwbx(width, height, xpos, ypos, "N");
                Console.SetCursorPosition(xpos + 1, ypos + 1); Console.Write(card._value);
                Console.SetCursorPosition(xpos + 3, ypos + 2); Console.Write(card._symbol);
            }

            Console.SetCursorPosition(xpos, ypos);         Console.Write("╭");
            Console.SetCursorPosition(xpos + 4, ypos);     Console.Write("╮");
            Console.SetCursorPosition(xpos, ypos + 3);     Console.Write("╰");
            Console.SetCursorPosition(xpos + 4, ypos + 3); Console.Write("╯");
        }
    }
}

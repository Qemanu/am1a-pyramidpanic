using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public static class Input
    {
        //fields 
        private static KeyboardState ks, oks;
        
        //mousestate voor edgedetector
        private static MouseState ms, oms;
       
        //dit is een rectangle die aan de muiscursor zit vastgeplakt
        private static Rectangle mouseRect;

        //constructor
        static Input()
        {
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            oks = ks;
            oms = ms;
            mouseRect = new Rectangle(ms.X, ms.Y, 1, 1);
        }

        //update
        public static void Update()
        {
            oks = ks;
            oms = ms;
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
        }

        //Dit is een edgedetector voor het signaleren of een knop nu ingedrukt is en
        //de vorige update niet ingedrukt was
        public static bool EdgeDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }

        //Dit is een edgedetector voor het signaleren of een knop niet ingedrukt is
        //en de vorige update wel ingedrukt was
        public static bool EdgeDetectKeyUp(Keys key)
        {
            return (ks.IsKeyUp(key) && oks.IsKeyDown(key));
        }

        //dit is een edgedetector voor het indrukken van de linker muis knop
        public static bool EdgeDetectMousePressLeft()
        {
            return ((ms.LeftButton == ButtonState.Pressed) && 
                    (oms.LeftButton == ButtonState.Released));
        }

        //dit is een edgedetector voor het indrukken van de rechter muis knop
        public static bool EdgeDetectMousePressRight()
        {
            return ((ms.RightButton == ButtonState.Pressed) &&
                    (oms.RightButton == ButtonState.Released));
        }

        //dit is een level detector voor het detecteren of een keyboardtoets is ingedrukt
        public static bool LevelDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key));
        }

        //dit is een level detector voor het detecteren of een keyboardtoets niet is ingedrukt
        public static bool LevelDetectKeyUp(Keys key)
        {
            return (ks.IsKeyUp(key));
        }

        public static Vector2 MousePosition()
        {
            return new Vector2(ms.X, ms.Y);
        }

        public static Rectangle MouseRect()
        {
            mouseRect.X = ms.X;
            mouseRect.Y = ms.Y;
            return mouseRect;
        }
    }
}

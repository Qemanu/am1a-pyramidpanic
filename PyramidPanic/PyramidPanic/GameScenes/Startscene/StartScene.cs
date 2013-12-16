//Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
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
    public class StartScene : IState //de class startscene implementeert de interface IState
    {
        //Fields van de class StartScene
        private PyramidPanic game;
        private Image background;
        private Image title;
        private Menu menu;

        

        //Constructor van de StartScene-class krijgt een object game mee van het type pyramidpanic
        public StartScene(PyramidPanic game)
        {
            this.game = game;
            //roep de initialize method aan
            this.Initialize();
        }

        //intialize method. Deze methode initialiseert (geeft startwaarden aan variabelen)
        //Void wil zeggen dat er niets teruggegeven wordt
        public void Initialize()
        {
            //roep de loadcontent method aan
            this.LoadContent();
        }

        //Loadcontent methode. deze methode maakt nieuwe objecten aan van de verschillende
        //classes
        public void LoadContent()
        {
            //nu maken we een object of instantie aan van de class image
            this.background = new Image(this.game, @"StartScene\Background", new Vector2(0f, 0f));
            this.title = new Image(this.game, @"StartScene\Title", new Vector2(100f, 50f));
            this.menu = new Menu(this.game);
        }

        //Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        // en update ale variabelen methods enz.....
        public void Update(GameTime gameTime)
        {
            this.menu.Update(gameTime);
        }

        //Drar methode deze methode wordt normaal 60 maal par seconde aangeroepen en
        // tekent de textures op het canvas
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Aquamarine);
            this.background.Draw(gameTime);
            this.menu.Draw(gameTime);
        }
    }
}

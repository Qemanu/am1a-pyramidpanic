﻿//Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
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

        //Constructor van de StartScene-class krijgt een object game mee van het type pyramidpanic
        public StartScene(PyramidPanic game)
        {
            this.game = game;
        }

        //intialize method. Deze methode initialiseert (geeft startwaarden aan variabelen)
        //Void wil zeggen dat er niets teruggegeven wordt
        public void Initialize()
        {

        }

        //Loadcontent methode. deze methode maakt nieuwe objecten aan van de verschillende
        //classes
        public void LoadContent()
        {

        }

        //Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        // en update ale variabelen methods enz.....
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Right) || Input.EdgeDetectMousePressLeft())
            {
                this.game.IState = this.game.PlayScene;
            }
            
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                this.game.IState = this.game.GameOverScene;
            }
        }

        //Drar methode deze methode wordt normaal 60 maal par seconde aangeroepen en
        // tekent de textures op het canvas
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Aquamarine);
        }
    }
}

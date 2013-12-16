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
    public class ScoreScene : IState
    {
        // Fields van de Start-class
        private PyramidPanic game;

        // Constructor van de Start-class krijgt een object game van het type pyramid panic
        public ScoreScene(PyramidPanic game)
        {
            this.game = game;
        }

        // Initialize methode, deze methode initialiseert (geeft startwaarden aan variabelen), Void wil zeggen dat er niks teruggegeven wordt.
        public void Initialize()
        {

        }

        // LoadContent methode, deze methode maakt nieuwe objecten aan van de verschillende klassen.
        public void LoadContent()
        {

        }

        // Update methode, wordt normaal 60 maal per seconden aangeroepen.
        public void Update(GameTime gametime)
        {
            if (Input.EdgeDetectKeyDown(Keys.NumPad6))
            {
                this.game.IState = this.game.StartScene;
            }

            if (Input.EdgeDetectKeyDown(Keys.NumPad4))
            {
                this.game.IState = this.game.HelpScene;
            }

            if (Input.EdgeDetectKeyDown(Keys.NumPad0))
            {
                this.game.IState = this.game.StartScene;
            }
        }

        // Draw methode, deze methode wordt normaal 60 maal per seconden aangeroepen en tekent de textures op het canvas.
        public void Draw(GameTime gameTime)
        {
            // Achtergrondkleur van de gamescene
            this.game.GraphicsDevice.Clear(Color.Aqua);
        }
    }
}

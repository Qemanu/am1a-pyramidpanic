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
  
    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        //Fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
       
        //variable van startscene, playscene, helpscene en gameoverscene
        private StartScene startscene;
        
        //variable playscene
        private PlayScene playscene;
        
        //variable helpscene
        private HelpScene helpscene;

        //variable gameoverscene
        private GameOverScene gameoverscene;

        //maak een variable aan van het type interface istate
        private IState iState;

        #region Properties
        //properties, 
        //maak de interface variabele iState beschikbaar buiten de class d.m.v
        //een property IState
        public IState IState
        {
            get { return this.iState; }
            set { this.iState = value; }
        }

        public StartScene StartScene
        {
            get { return this.startscene; }
        }

        public HelpScene HelpScene
        {
            get { return this.helpscene; }
        }

        public PlayScene PlayScene
        {
            get { return this.playscene; }
        }

        public GameOverScene GameOverScene
        {
            get { return this.gameoverscene; }
        } 
        #endregion
        
        //dit is de constructor, Heeft alijd dezelfde naam als de class
        public PyramidPanic()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            //Verander de titel van het canvas
            Window.Title = "Pyramid Panic Beta 00.00.00.01";
            //Maakt de muis zichtbaa'r
            IsMouseVisible = true;

            //Verandert de breedte van het canvas
            this.graphics.PreferredBackBufferWidth = 640;

            //Verandert de hoogte van het canvas
            this.graphics.PreferredBackBufferHeight = 480;

            //Past de nieuwe hoogte en breedte toe
            this.graphics.ApplyChanges();

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            //Een spritebatch is nodih voor het tekenen van textures op het canvas
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //we maken nu het object/instantie aan van het type startscene dit doe je door
            // de consturctor aan te roepen van de startscene 
            this.startscene = new StartScene(this);
           
            this.playscene = new PlayScene(this);
            this.helpscene = new HelpScene(this);
            this.gameoverscene = new GameOverScene(this);

            this.iState = this.gameoverscene;
           
            
            
        }

       
        protected override void UnloadContent()
        {
            
        }

       
       
        protected override void Update(GameTime gameTime)
        {
            //Zorgt dat het spel stopt wanneer je op de gamepad button Back indrukt
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) || 
                (Keyboard.GetState().IsKeyDown(Keys.Escape)))
                this.Exit();
            Input.Update();
            
            //de update methode van het object dat toegewezen is aan het interface object
            this.iState.Update(gameTime);
              
            base.Update(gameTime);
            
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //voor een spriteBatch instantie iets kan tekenen moet de begin() methode aangeroepen worden
            this.spriteBatch.Begin();

           
            //de draw methode van het ovject dat toegewezen is aan het interface-object
            // this.iState wordt aangeroepen
            this.iState.Draw(gameTime);
            
           
            //Nadar de spriteBatch.draw() is aangeroepen moet de end() methode van de
            //SpriteBatch class worden aangeroepen
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

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

namespace MyGame
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ManagerScreens managerScreens;
        

        public Game1()
        {
            GC.Collect(0, GCCollectionMode.Optimized);

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();

            this.Window.AllowUserResizing = true;
            graphics.SynchronizeWithVerticalRetrace = false;
            graphics.PreferMultiSampling = false;
            IsFixedTimeStep = true;

            Content.RootDirectory = "Content";
            

            
        }

  
        protected override void Initialize()
        {

            Helper.SpriteBatch = new SpriteBatch(this.GraphicsDevice);
            Helper.Game = this;
            Helper.ContentManager = this.Content;
            Helper.RenderTarget = new RenderTarget2D(this.GraphicsDevice, 1024, 768);

            Helper.IsShowCollisionBounds = true;

            Helper.EarthHealth = 100;

            managerScreens = new ManagerScreens();



            base.Initialize();
        }

  
        protected override void LoadContent()
        {
          
            spriteBatch = new SpriteBatch(GraphicsDevice);

         
     
        }

    
      
        //
        // !!!
        //

        int timer = 0;
   
        protected override void Update(GameTime gameTime)
        {
            // 
            // !!!
            //

            if (timer <= 10) timer++;

            



            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed && timer >= 10)
            {
                timer = 0;
                Helper.IsShowCollisionBounds = !Helper.IsShowCollisionBounds;
            }



            managerScreens.Update(gameTime);

            base.Update(gameTime);
        }

      
        protected override void Draw(GameTime gameTime)
        {

            Helper.SpriteBatch.Begin();

            graphics.GraphicsDevice.SetRenderTarget(Helper.RenderTarget);

            managerScreens.Draw(gameTime);
            graphics.GraphicsDevice.Clear(Color.Black);
            Helper.SpriteBatch.End();


            Helper.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);


            graphics.GraphicsDevice.SetRenderTarget(null);

            Helper.SpriteBatch.Draw(Helper.RenderTarget, Helper.RenderTarget.Bounds, Color.White);
            Helper.SpriteBatch.End();


            

            

            

          
        }
    }
}

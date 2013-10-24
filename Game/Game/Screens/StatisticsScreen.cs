using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FPSCounter;

namespace MyGame
{
    class StatisticsScreen : IScreen
    {
        private Rectangle bounds = new Rectangle(0, 0, 300, 110);
        private Vector2 location, vCounter, vGC,
                        vTotalMemory, vGameTime,
                        vElapsedTime, vShowCollisionBounds;

        private bool active = false;

        private Texture2D backgound;


        private FPS counter = new FPS();
        private SpriteFont font;

        public StatisticsScreen()
        {
            location = Vector2.Zero;

            vShowCollisionBounds = new Vector2(5, 5);
            vTotalMemory = new Vector2(5, 22);
            vElapsedTime = new Vector2(5, 39);
            vGameTime = new Vector2(5, 56);
            vCounter = new Vector2(5, 73);
            vGC = new Vector2(5, 93);
            
            this.LoadContent();
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public void LoadContent()
        {
            backgound = Helper.ContentManager.Load<Texture2D>("Fone");
            font = Helper.ContentManager.Load<SpriteFont>("Fonts/PanelInfoFont");
        }

        public void Update(GameTime gameTime)
        {
            counter.Update(gameTime);
        }
        public void Draw(GameTime gameTime)
        {
            Helper.SpriteBatch.Draw(backgound, location, bounds, Color.White);
            Helper.SpriteBatch.DrawString(font, "IsShowCollisionBounds : " + Helper.IsShowCollisionBounds, vShowCollisionBounds, Color.White);
            Helper.SpriteBatch.DrawString(font, "TotalMemory           : " + GC.GetTotalMemory(false) / 1024, vTotalMemory, Color.White);
            Helper.SpriteBatch.DrawString(font, "ElapsedTime           : " + gameTime.ElapsedGameTime.TotalSeconds, vElapsedTime, Color.White);
            Helper.SpriteBatch.DrawString(font, "GameTime              : " + gameTime.TotalGameTime, vGameTime, Color.White);
            Helper.SpriteBatch.DrawString(font, "FPS                   : " + counter.Count, vCounter, Color.White);
            Helper.SpriteBatch.DrawString(font, "GC                    : " + GC.CollectionCount(0) + " - " + GC.CollectionCount(1), vGC, Color.White);
            counter.Draw(gameTime);
        }
    }
}

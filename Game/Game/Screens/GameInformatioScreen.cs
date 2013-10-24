using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame
{
    class GameInformatioScreen : IScreen
    {


        private Vector2 location;

        private bool active = false;


        string text = "Earth : 100";


        private SpriteFont font;

        public GameInformatioScreen()
        {
            location = new Vector2((Helper.RenderTarget.Width / 2) - text.Length * 3.5f, Helper.RenderTarget.Height / 2);



            font = Helper.ContentManager.Load<SpriteFont>("Fonts/PanelInfoFont");
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }



        

        public void Update(GameTime gameTime)
        {
            text = "Earth : " + Helper.EarthHealth;

        }

        public void Draw(GameTime gameTime)
        {
            Helper.SpriteBatch.DrawString(font, text, location, Color.White);
        }
    }
}
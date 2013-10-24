using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Animation2D;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MyGame
{
    sealed class Glow : GameObject
    {
        private Color maskColor;

        public Glow()
        {
            base.Enabled = true;

            base.Animation = new Animation(Helper.Game, Helper.SpriteBatch)
            {
                Texture = Helper.ContentManager.Load<Texture2D>("Earth/Glow"),
                Bounds = base.Bounds = new Rectangle(0, 0, 900, 900),
                Location = base.Location = new Vector2((Helper.RenderTarget.Width / 2) - base.Bounds.Width / 2, (Helper.RenderTarget.Height / 2) - base.Bounds.Height / 2),
                MaskColor = maskColor = new Color(255, 255, 255, 255),
                Rows = 1,
                Columns = 1,

            };
        }

        bool flag = true;

        public override void Update(GameTime gameTime)
        {

            maskColor.G = maskColor.B = (byte)(Helper.EarthHealth * 2.55f);

            

          

            Animation.MaskColor = maskColor;
        }

        public override void Draw(GameTime gameTime)
        {
            Animation.Draw(gameTime);

        }

    }
}

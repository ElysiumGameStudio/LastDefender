using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Animation2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame
{
    class Earth : GameObject
    {
        private Color maskColor;

        public Earth()
        {
            base.Enabled = true;
            base.CollisionBounds = new List<Line>();

            this.Health = 100;
  


            base.Animation = new Animation(Helper.Game, Helper.SpriteBatch)
            {
                Texture = Helper.ContentManager.Load<Texture2D>("Earth/Earth"),
                Bounds = base.Bounds = new Rectangle(0, 0, 300, 300),
                Location = base.Location = new Vector2((Helper.RenderTarget.Width / 2) - base.Bounds.Width / 2, (Helper.RenderTarget.Height / 2) - base.Bounds.Height / 2),
                MaskColor = maskColor = new Color(255, 255, 255, 255),
                Rows = 1,
                Columns = 1,

            };

            Texture2D tex = Helper.ContentManager.Load<Texture2D>("SystemCollision/Dot");

            //добавляем отрезки для пересечения
            base.CollisionBounds.Add(new Line(new Vector2(150, 15), new Vector2(180, 19), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(180, 19), new Vector2(205, 27), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(205, 27), new Vector2(230, 42), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(230, 42), new Vector2(250, 61), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(250, 61), new Vector2(265, 82), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(265, 82), new Vector2(278, 110), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(278, 110), new Vector2(284, 140), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(284, 140), new Vector2(283, 170), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(283, 170), new Vector2(274, 200), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(274, 200), new Vector2(256, 230), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(256, 230), new Vector2(231, 255), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(231, 255), new Vector2(205, 273), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(205, 273), new Vector2(175, 282), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(175, 282), new Vector2(150, 285), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(150, 285), new Vector2(120, 281), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(120, 281), new Vector2(90, 270), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(90, 270), new Vector2(60, 250), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(60, 250), new Vector2(38, 225), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(38, 225), new Vector2(21, 190), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(21, 190), new Vector2(14, 150), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(14, 150), new Vector2(20, 115), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(20, 115), new Vector2(32, 85), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(32, 85), new Vector2(50, 60), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(50, 60), new Vector2(75, 38), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(75, 38), new Vector2(110, 22), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(110, 22), new Vector2(150, 15), this, tex));


        }


        public int Health { get; set; }



        public override bool CollidesWith(List<Line> list)
        {
            for (int i = 0; i < this.CollisionBounds.Count; i++)
                for (int j = 0; j < list.Count; j++)
                    if (this.CollisionBounds[i].CollidesWith(list[j])) return true;

            return false;
        }


        public override void Update(GameTime gameTime)
        {
            maskColor.G = maskColor.B = (byte)(Helper.EarthHealth * 2.55f);

            Animation.MaskColor = maskColor;


            if (Helper.IsShowCollisionBounds)
                for (int i = 0; i < base.CollisionBounds.Count; i++)
                    base.CollisionBounds[i].Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Animation.Draw(gameTime);

            if (Helper.IsShowCollisionBounds)
                for (int i = 0; i < base.CollisionBounds.Count; i++)
                    base.CollisionBounds[i].Draw(gameTime);           
        }



    }
}

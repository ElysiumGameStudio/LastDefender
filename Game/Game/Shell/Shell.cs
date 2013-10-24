using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Animation2D;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MyGame
{
    class Shell : GameObject
    {

        private Vector2 possition = new Vector2(0, 0);
        private Vector2 center = new Vector2(8, 8);

        Vector2 Center;
        Vector2 location;


        private int liveTimer = 0;

        public Shell()
        {

            base.Enabled = false;

            base.Animation = new Animation(Helper.Game, Helper.SpriteBatch)
            {
                Texture = Helper.ContentManager.Load<Texture2D>("Shell/Shell"),
                Location = base.Location = Vector2.Zero,
                Bounds = base.Bounds = new Rectangle(0, 0, 16, 16),
                Rows = 1,
                Columns = 1,
            };

            Center = new Vector2(Helper.RenderTarget.Width / 2, Helper.RenderTarget.Height / 2);

         Texture2D tex = Helper.ContentManager.Load<Texture2D>("SystemCollision/Dot");

         base.CollisionBounds = new List<Line>();

   


            base.CollisionBounds.Add(new Line(new Vector2(-5, -4), new Vector2(5, -4), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(5, -4), new Vector2(5, 4), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(5, 4), new Vector2(-5, 4), this, tex));
            base.CollisionBounds.Add(new Line(new Vector2(-5, 4), new Vector2(-5, -4), this, tex));
        }


        

      

        public double AngleX { get; set; }




        public void Vel()
        {
            location.X = (float)(Center.X + 161 * Math.Sin(AngleX));
            location.Y = (float)(Center.Y + 161 * Math.Cos(AngleX));
            base.Location = location;
        }

        float coef = 5f;



        public void RestartState()
        {
            base.Enabled = false;
            liveTimer = 0;
            coef = 5f;
        }




        public override bool CollidesWith(List<Line> list)
        {
            for (int i = 0; i < base.CollisionBounds.Count; i++)
                for (int j = 0; j < list.Count; j++)
                    if (this.CollisionBounds[i].CollidesWith(list[j])) return true;

            return false;
        }



        

        public override void Update(GameTime gameTime)
        {
            if (liveTimer != 210)
            {
                liveTimer++;
                coef -= 0.05f;
            }
            else this.RestartState();
            
            possition.X = coef * (float)Math.Cos(base.Rotation + MathHelper.ToRadians(90));
            possition.Y = coef * (float)Math.Sin(base.Rotation + MathHelper.ToRadians(90));

            base.Location += possition;
           
            
           
            base.Animation.Construct(base.Location);  
        }

        


        public override void Draw(GameTime gameTime)
        {
            Helper.SpriteBatch.Draw(Animation.Texture, base.Location, Animation.Bounds, Color.White, base.Rotation, center, 1f, SpriteEffects.None, 1);

            if (Helper.IsShowCollisionBounds)
                for (int i = 0; i < base.CollisionBounds.Count; i++)
                    base.CollisionBounds[i].Draw(gameTime); 
        }




    }
}

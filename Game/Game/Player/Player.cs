using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Animation2D;

namespace MyGame
{
    class Player : GameObject
    {
        private Vector2 centerTexture = new Vector2(20, 10);


        Vector2 location;

        Vector2 Center;

        private Texture2D texture;






        public Player()
        {
            base.Enabled = true;

           
            texture = Helper.ContentManager.Load<Texture2D>("Player/Player");

            Center = new Vector2(Helper.RenderTarget.Width / 2, Helper.RenderTarget.Height / 2);

            base.Location = new Vector2(500, 500);
            Bounds = base.Bounds = new Rectangle(0, 0, 40, 20);


           
        }

    



        public double AngleX { get; set; }


   

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X >= 0.3f) 
            {
                AngleX += 0.03f;
                base.Rotation -= 0.03f;
            }
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X <= -0.3f)
            {
                AngleX -= 0.03f;
                base.Rotation += 0.03f;
            }

         


         
                
            


        
      
         

            location.X = (float)(Center.X + 150 * Math.Sin(AngleX));
            location.Y = (float)(Center.Y + 150 * Math.Cos(AngleX));



         
            
           

            base.Location = location;


            

           
        }

        public override void Draw(GameTime gameTime)
        {
            Helper.SpriteBatch.Draw(texture, base.Location, base.Bounds, Color.White, base.Rotation, centerTexture, 1, SpriteEffects.None, 0.5f);

      
            
        }
    }
}

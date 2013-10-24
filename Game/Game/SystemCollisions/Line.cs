using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame
{
    class Line
    {
        private Vector2 textureCenter;


        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }



        public Texture2D Texture { get; set; }

        GameObject myobj;

        double ax1, ax2, ay1, ay2, bx1, bx2, by1, by2, v1, v2, v3, v4;


        public Line(Vector2 first, Vector2 second, GameObject obj, Texture2D texture)
        {
            this.Start = first;
            this.End = second;

            this.Texture = texture;

            textureCenter.X = this.Texture.Width / 2;
            textureCenter.Y = this.Texture.Height / 2;

            //ссылка на родительский спрайт
            myobj = obj;
           
        }

        //проверяем на столкновение
        public bool CollidesWith(Line bline)
        {

            ax1 = myobj.Location.X + Start.X;
            ax2 = myobj.Location.X + End.X;
            ay1 = myobj.Location.Y + Start.Y;
            ay2 = myobj.Location.Y + End.Y;

            bx1 = bline.myobj.Location.X + bline.Start.X;
            bx2 = bline.myobj.Location.X + bline.End.X;
            by1 = bline.myobj.Location.Y + bline.Start.Y;
            by2 = bline.myobj.Location.Y + bline.End.Y;

            v1 = (bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1);
            v2 = (bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1);
            v3 = (ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1);
            v4 = (ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1);

            return ((v1 * v2 <= 0) && (v3 * v4 <= 0));

        }


        


        public void Update(GameTime gameTime)
        {
            textureCenter.X = this.Texture.Width / 2;
            textureCenter.Y = this.Texture.Height / 2;
        }


        public void Draw(GameTime gameTime)
        {
            Helper.SpriteBatch.Draw(Texture, Start + myobj.Location - textureCenter, Color.White);
            Helper.SpriteBatch.Draw(Texture, End + myobj.Location - textureCenter, Color.White);
        }
    }
} 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Animation2D;

namespace MyGame
{
    abstract class GameObject
    {

        public Animation Animation 
        {
            get;
            set;
        }
        public Vector2 Location 
        { 
            get; 
            set; 
        }
        public Rectangle Bounds 
        {
            get;
            set;
        }
        public float Rotation 
        {
            get;
            set;
        }
        public bool Enabled 
        {
            get;
            set;
        }
        public List<Line> CollisionBounds
        {
            get;
            set;
        }

        //Определяем, есть ли коллизия
        public virtual bool CollidesWith(List<Line> list)
        {
            return false;
        }


        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gamaTime) { }
    }
}

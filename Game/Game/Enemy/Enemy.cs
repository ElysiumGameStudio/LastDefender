using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Animation2D;

namespace MyGame
{
    class Enemy : GameObject
    {

        public Enemy()
        {
            base.Animation = new Animation(Helper.Game, Helper.SpriteBatch)
            {

            };



        }


        public EnemyType Type
        {
            get;
            set;
        }









        public override bool CollidesWith(List<Line> list)
        {
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gamaTime)
        {
            
        }
    }
}

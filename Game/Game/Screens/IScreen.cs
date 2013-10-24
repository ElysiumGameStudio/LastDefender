using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MyGame
{
    interface IScreen
    {
        bool Active 
        { 
            get; 
            set; 
        } 

        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}

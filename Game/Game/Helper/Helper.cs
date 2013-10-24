using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MyGame
{
    static class Helper
    {
        public static SpriteBatch SpriteBatch { get; set; }
        public static ContentManager ContentManager { get; set; }
        public static RenderTarget2D RenderTarget { get; set; }
        public static Game Game { get; set; }

        public static int EarthHealth { get; set; }




        public static bool IsShowCollisionBounds { get; set; }
     


    }
}

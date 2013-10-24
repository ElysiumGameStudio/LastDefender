using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Wintellect.PowerCollections;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame
{
    
    class GameScreen : IScreen
    {
        // Singolton's object's
        private Player player;
        private Earth earth;
        private Glow glow;
       // private Map map;



        // Manager's
       

        // List's for all game object's
        private BigList<GameObject> closedList;

     



        private BigList<Shell> shells;

       

        // Masters
        private MasterCollisions mCollisions;

      




        private bool controllerConnected = true;

        


        public GameScreen() 
        {
           
            closedList = new BigList<GameObject>();
            shells = new BigList<Shell>();

            
            player = new Player();
            earth = new Earth();
            glow = new Glow();
            //map = new Map();


            mCollisions = new MasterCollisions();



            closedList.Add(glow);
            closedList.Add(player);
            closedList.Add(earth);





            for (int i = 0; i < 100; i++)
            {
                shells.Add(new Shell());

                closedList.Add(shells.Last());

            }

           
            
        }





     


        public bool Active 
        {
            get;
            set;
        }




        












        // ПЕРЕПИСАТЬ
        private void CameraZoom()
        {
            if (player.Location.X <= 600)
            {

                if (Camera2D.Zoom < 1.1f) Camera2D.Zoom += 0.0007f;


            }
            else if (Camera2D.Zoom > 1f) Camera2D.Zoom -= 0.0007f;
           

            //else
            //{
            //    if (location.Y <= 400)
            //    {
            //        if (Camera2D.Zoom < 1.02f)
            //            Camera2D.Zoom += 0.0007f;
            //        else
            //        {
            //            if (Camera2D.Zoom > 0.95f) Camera2D.Zoom -= 0.0007f;
            //        }


            //        if (Camera2D.Zoom > 1f) Camera2D.Zoom -= 0.0007f;
            //    }
            //}
        }









        int timer = 0;

        public void Update(GameTime gameTime)
        {
            timer++;

         //   this.CameraZoom();

            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && timer >= 20)
            {
                timer = 0;

                for (int i = 0; i < shells.Count; i++)
                {
                    if (!shells[i].Enabled)
                    {
                        shells[i].Enabled = true;
                        shells[i].AngleX = player.AngleX;
                        shells[i].Rotation = player.Rotation;
                        shells[i].Vel();
                        break;
                    }
                }



            }


            if (mCollisions.GameWorldCollision(ref shells, earth))
                Helper.EarthHealth--;
            
                
            



            for (int i = 0; i < closedList.Count; i++)
               if (closedList[i].Enabled) closedList[i].Update(gameTime); 
        }

        public void Draw(GameTime gameTime)
        {
          
            // Игровые объекты (если доступны)
            for (int i = 0; i < closedList.Count; i++)
                if (closedList[i].Enabled) closedList[i].Draw(gameTime);
        }
    }
}

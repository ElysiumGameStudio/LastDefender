using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MyGame
{
    class ManagerScreens
    {
        private List<IScreen> screens = new List<IScreen>();



        public ManagerScreens()
        {
            screens.Capacity = 10;

          
            screens.Add(new GameScreen());
            screens.Add(new StatisticsScreen());
            screens.Add(new GameInformatioScreen());

         
         

        

          

            screens[0].Active = true;
            screens[1].Active = true;
            screens[2].Active = true;
        
        }








        public void Add(IScreen screen)
        {
            screens.Add(screen);
        }

        public void Remove(IScreen screen)
        {
            screens.Remove(screen);
        }



        public void Update(GameTime gameTime)
        {
            //screens[0].Active = true;
           // if (Helper.GameState == GameState.CostMenu) screens[6].Active = true;
           // else screens[6].Active = false;

            //if (Helper.GameState == GameState.PowerMenu) screens[7].Active = true;
          // else screens[7].Active = false;

           // if (Helper.GameState == GameState.PauseMenu) screens[5].Active = true;
          //  else screens[5].Active = false;

           


            for (int i = 0; i < screens.Count; i++)
                if (screens[i].Active) screens[i].Update(gameTime);
            
        }

        public void Draw(GameTime gameTime)
        {
            for (int i = 0; i < screens.Count; i++)
                if (screens[i].Active) screens[i].Draw(gameTime);
        }
    }
}

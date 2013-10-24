using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace MyGame
{
    class MasterCollisions
    {
        
        // Столкновение одиночного объекта с множеством снарядов
        public bool GameWorldCollision(ref BigList<Shell> listShells, GameObject gameObject)
        {
            for (int i = 0; i < listShells.Count; i++)
                if (listShells[i].Enabled && listShells[i].CollidesWith(gameObject.CollisionBounds))
                {
                    listShells[i].RestartState();
                    return true;
                }

            return false; 
        }

        // Столкновение одиночного объекта с одиночным
        public bool GameWorldCollision(GameObject first, GameObject second)
        {
            if (first.CollidesWith(second.CollisionBounds)) return true;

            return false;
        }


    }
}

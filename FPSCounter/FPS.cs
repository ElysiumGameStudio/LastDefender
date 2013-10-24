using Microsoft.Xna.Framework;

namespace FPSCounter
{
    public class FPS
    {
        private byte frames; 
        private double seconds;

        public byte Count 
        { 
            get; 
            private set; 
        }
       
        public void Update(GameTime gameTime)
        {
            seconds += gameTime.ElapsedGameTime.TotalSeconds;

            if (seconds >= 1)
            {
                this.Count = frames;
                seconds = frames = 0;
            }
        }

        public void Draw(GameTime gameTime)
        {
            frames++;
        }
    }
}

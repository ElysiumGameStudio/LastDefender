using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Animation2D
{
    public class Animation
    {
        private SpriteBatch spriteBatch;
        private Rectangle bounds = new Rectangle();
        private byte opacity = 255;
        private Color color;

        public Animation(Game game, SpriteBatch sprBatch)
        {
            this.Location = Vector2.Zero;
            this.Columns = this.Rows = 1;
            this.Frequency = 10;
            this.CurrentColumn = this.CurrentRow = 0;
            this.TimeFrame = 1f / this.Frequency;
            this.Bounds = bounds;
            this.MirrorDisplay = false;
            this.Rotation = 0f;
            this.Scale = 1;
            this.MaskColor = color = Color.White;

            spriteBatch = sprBatch;
        }

        public Rectangle Bounds 
        {
            get { return bounds; }
            set { bounds = value; }
        }
        public double TotalElapsed 
        { 
            get; 
            set; 
        }
        public Texture2D Texture 
        { 
            get; 
            set; 
        }
        public float LayerDepth 
        { 
            get; 
            set; 
        }
        public Vector2 Location 
        { 
            get; 
            set; 
        }
        public float TimeFrame 
        { 
            get; 
            set; 
        }
        public byte Frequency 
        { 
            get; 
            set; 
        }
        public bool MirrorDisplay 
        { 
            get; 
            set; 
        }
        public short Scale 
        {
            get;
            set;
        }
        public byte Opacity 
        {
            get { return opacity; }
            set
            {
                opacity = value;
                color.R = color.G = color.B = color.A = opacity;
            }
        }
        public float Rotation 
        {
            get;
            set;
        }
        public bool Rotate
        {
            get;
            set;
        }
        public Vector2 CenterRotate
        {
            get;
            set;
        }
        public Color MaskColor
        {
            get { return color; }
            set { color = value; }
        }

        public short CurrentColumn 
        {
            get;
            set;
        }
        public short CurrentRow 
        {
            get;
            set;
        }


        public short Columns
        {
            get;
            set;
        }
        public short Rows
        {
            get;
            set;
        }



        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="texture">Texture2D</param>
        public void Construct(Texture2D texture) 
        {
            this.Texture = (this.Texture != texture) ? texture : this.Texture;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location">Location</param>
        public void Construct(Vector2 location) 
        {
            this.Location = (this.Location != location) ? location : this.Location;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="texture">Texture2D</param>
        /// <param name="location">Location</param>
        public void Construct(Texture2D texture, Vector2 location) 
        {
            this.Texture = (this.Texture != texture) ? texture : this.Texture;
            this.Location = (this.Location != location) ? location : this.Location;
        }
        /// <summary>
        /// Constructo
        /// </summary>
        /// <param name="location">Location</param>
        /// <param name="layerDepth">Layer Depth</param>
        public void Construct(Vector2 location, float layerDepth) 
        {
            this.Location = (this.Location != location) ? location : this.Location;
            this.LayerDepth = (this.LayerDepth != layerDepth) ? layerDepth : this.LayerDepth;
        }
      


        private void ChangeFrame(double lastTimeFrame) 
        {
            this.TotalElapsed += lastTimeFrame;

            if (this.TotalElapsed > this.TimeFrame)
            {
                if (this.CurrentColumn >= this.Columns - 1) 
                {
                    if (this.CurrentRow >= this.Rows - 1) this.CurrentRow = 0;
                    else this.CurrentRow++;

                    this.CurrentColumn = 0;
                    bounds.Y = bounds.Height * this.CurrentRow;
                } 
                else this.CurrentColumn++;

                bounds.X = bounds.Width * this.CurrentColumn;

                this.Bounds = bounds;
                this.TotalElapsed = 0;
            }
        }


        /// <summary>
        /// Update game logic
        /// </summary>
        /// <param name="gameTime">Game time</param>
        public void Update(GameTime gameTime) 
        {
            this.ChangeFrame(gameTime.ElapsedGameTime.TotalSeconds);
        }
        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="gameTime">Game time</param>
        public void Draw(GameTime gameTime) 
        {
            if (this.MirrorDisplay)
                if (this.Rotate) spriteBatch.Draw(this.Texture, this.Location, this.Bounds, this.MaskColor, this.Rotation, this.CenterRotate, this.Scale, SpriteEffects.FlipHorizontally, 0);
                else spriteBatch.Draw(this.Texture, this.Location, this.Bounds, this.MaskColor, this.Rotation, Vector2.Zero, this.Scale, SpriteEffects.FlipHorizontally, 0);
            else
                if (this.Rotate) spriteBatch.Draw(this.Texture, this.Location, this.Bounds, this.MaskColor, this.Rotation, this.CenterRotate, this.Scale, SpriteEffects.None, 0);
                else spriteBatch.Draw(this.Texture, this.Location, this.Bounds, this.MaskColor, this.Rotation, Vector2.Zero, this.Scale, SpriteEffects.None, 0);
        }
    }
}
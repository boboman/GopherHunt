using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace GopherHunt.Classes
{
    public class Animation
    {
        int index;
        Texture2D texture;
        float timer;
        float delayTimer;
        bool repeating;
        int framesPerRow;
        int fps;

        public int FrameHeight
        {
            get;
            private set;
        }

        public int FrameWidth
        {
            get;
            private set;
        }

        public int NumberOfFrames
        {
            get;
            private set;

        }
        
        public string FpsDisplay
        {
            get;
            private set;
        }
        

        public Animation(ContentManager content, string asset, int frameWidth, int frameHeight, int numberOfFrames, int framesPerSecond)
        {
            texture = content.Load<Texture2D>(asset);
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;
            framesPerRow = texture.Width / frameWidth;
            fps = framesPerSecond;
            FpsDisplay = asset + " FPS:  " + fps.ToString();
            NumberOfFrames = numberOfFrames;
            repeating = true;
        }
        public void setRepeating(bool b)
        {
            repeating = b;
        }

        public void Update(GameTime gameTime)
        {
            if (timer > (1.0f / (float)fps))
            {
                if (index != (NumberOfFrames - 1))
                {
                    index++;
                    timer = 0;
                }
                else
                {
                    if (repeating)
                    {
                        index = 0;
                        timer = 0;
                    }
                }
            }
            else
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int rowNumber = index / framesPerRow;
            spriteBatch.Draw(texture, position, new Rectangle((index - (rowNumber * framesPerRow)) * FrameWidth, rowNumber * FrameHeight, FrameWidth, FrameHeight), Color.White);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, float rotation, float scale)
        {

        }

    }
}

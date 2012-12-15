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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Gopher
    {

        Animation animation;
        Vector2 position;

        public bool isAlive { get; set; }
        public int pointValue { get; set; }


        public Gopher(Animation animation, Vector2 position)
        {
            pointValue = 10;
            isAlive = true;

            this.position = position;
            this.animation = animation;
        }



        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (isAlive)
            {
                animation.Draw(spriteBatch, position);
                this.Update(gameTime);
            }
        }



    }
}

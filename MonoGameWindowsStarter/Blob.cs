using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    public class Blob
    {
        Game1 game;

        Texture2D texture;

        BoundingRectangle bounds;


        public Blob(Game1 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            // position the ball in the center of the screen
            bounds.X = game.GraphicsDevice.Viewport.Width / 2;
            bounds.Y = game.GraphicsDevice.Viewport.Height / 2;

            bounds.Height = 50;
            bounds.Width = 75;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("pixel");
        }

        public void Update(GameTime gameTime)
        {
            // Nothing?
            
        }

        public void Draw(SpriteBatch sb, Color color, BlobState state)
        {

            Matrix matrix;

            // Set the transformation matrix based on the state
            if (state == BlobState.North)
            {
                matrix = Matrix.CreateTranslation(10, 10, 0);
            }

            else if (state == BlobState.South)
            {
                matrix = Matrix.CreateTranslation(70, 10, 0);
            }

            else if (state == BlobState.East)
            {
                matrix = Matrix.CreateTranslation(10, 70, 0);
            }

            else
            {
                matrix = Matrix.CreateTranslation(70, 70, 0);
            }

            sb.Begin(SpriteSortMode.Deferred, null, null, null, null, null, matrix);
            sb.Draw(texture, bounds, color);
            sb.End();
        }


    }
}

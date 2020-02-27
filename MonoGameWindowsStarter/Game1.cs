using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameWindowsStarter
{

    public enum BlobState
    {
        North,
        South,
        East,
        West
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        BlobState state;
        Color[] colors = { Color.Red, Color.Blue, Color.Blue, Color.Green, Color.Brown, Color.Bisque, Color.Tan, Color.Tomato, Color.Teal, Color.MediumTurquoise };
        Color blobColor = Color.White;
        Blob blob;

        public Random Random = new Random();
        
        
        KeyboardState oldKeyboardState;
        KeyboardState newKeyboardState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            state = BlobState.North;
            blob = new Blob(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Set the game screen size
            graphics.PreferredBackBufferWidth = 1042;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
            blob.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            blob.LoadContent(Content);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            newKeyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (newKeyboardState.IsKeyDown(Keys.Escape))
                Exit();

            // TODO: every time you hit any other key (alphas?) do this transform thing
            if (newKeyboardState.IsKeyDown(Keys.Space) && !oldKeyboardState.IsKeyDown(Keys.Space))
            {
                blobColor = colors[Random.Next(colors.Length)];
                switch (state)
                {
                    case BlobState.North:
                        state = BlobState.East;
                        break;

                    case BlobState.South:
                        state = BlobState.West;
                        break;

                    case BlobState.East:
                        state = BlobState.South;
                        break;

                    case BlobState.West:
                        state = BlobState.North;
                        break;

                    default:
                        state = BlobState.North;
                        break;
                }
            }


            oldKeyboardState = newKeyboardState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: set a transformation matrix based on blob state
            // choose random color
           
            blob.Draw(spriteBatch, blobColor, state);

            base.Draw(gameTime);
        }
    }
}

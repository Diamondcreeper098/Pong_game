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

namespace WindowsGame2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle ball, enemypdl, ply;
        Texture2D ballt, pdl;
        SpriteFont fnt;
        int spdy = 2, spdx = 2,x=40,y = 40;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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
            fnt = Content.Load<SpriteFont>("Pongfont");
            ballt = Content.Load<Texture2D>("Ball");
            pdl = Content.Load <Texture2D>("Paddle");
            ball = new Rectangle(x,y, ballt.Width, ballt.Height);
            ply = new Rectangle(10, Mouse.GetState().Y, pdl.Width, pdl.Height);
            enemypdl = new Rectangle(this.Window.ClientBounds.Width - 30, ball.Y, pdl.Width, pdl.Height);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            enemypdl = new Rectangle(this.Window.ClientBounds.Width - 30, Mouse.GetState().Y, pdl.Width, pdl.Height);
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (x == 0)
            {
                System.Windows.Forms.MessageBox.Show("Enemy win");
                x = 40;
                y = 40;
                spdx = 2;
                spdy = 2;
            }
            else if (x == 800)
            {
                System.Windows.Forms.MessageBox.Show("Haha you won");
                x = 40;
                y = 40;
            }
            if (y == 0)
            {
                spdy = 2;
            }
            else if (y == this.Window.ClientBounds.Height)
            {
                spdy = -2;
            }
            if (ball.Intersects(enemypdl))
            {
                spdx = -2;
                spdy = -2;
            }
            if (ball.Intersects(ply))
            {
                spdx = 2;
                spdy = 2;
            }
            x += spdx;
            y += spdy;
            ply = new Rectangle(10, Mouse.GetState().Y, pdl.Width, pdl.Height);//an cheat haha
            ball = new Rectangle(x, y, ballt.Width, ballt.Height);
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            
            spriteBatch.Draw(pdl, ply, new Color(255, 255, 255));
            spriteBatch.Draw(ballt, ball, new Color(255, 255, 255));
            spriteBatch.Draw(pdl, enemypdl, new Color(255, 255, 255));
            spriteBatch.DrawString(fnt, "Hello" + this.Window.ClientBounds.Width, new Vector2((10), (10)), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

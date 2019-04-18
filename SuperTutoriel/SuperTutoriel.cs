using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperTutoriel.Classes.GameObjects;
using SuperTutoriel.Classes.Managers;

namespace SuperTutoriel
{
    /// <summary>
    /// Le super tutoriel ! C'est un casse-brique un peu moisi, mais ça montre plein de choses pour apprendre !
    /// </summary>
    public class SuperTutoriel : Game
    {
        #region Propriétés

        /// <summary>
        /// Manager des matériels graphiques.
        /// </summary>
        public GraphicsDeviceManager graphics;

        /// <summary>
        /// Permet de regrouper l'affichage de texture ou de texte.
        /// </summary>
        public SpriteBatch spriteBatch;

        /// <summary>
        /// Le niveau du jeu.
        /// </summary>
        public Level level;

        #endregion Propriétés

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public SuperTutoriel()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            level = new Level();
        }

        #endregion Constructeurs

        #region Draw & Update
        
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ScreenShakeManager.Update(gameTime);
            level.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            level.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        #endregion Draw & Update

        #region Méthodes

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            RandomManager.Initialize();
            ScreenShakeManager.Initialize();

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

            TextureManager.LoadContent(Content);

            level.Start();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        #endregion Méthodes
    }
}

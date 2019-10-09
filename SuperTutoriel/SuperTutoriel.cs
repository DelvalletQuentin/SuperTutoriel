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
        /// Permet au jeu de mettre à jour la logique du monde.
        /// On vérifie les collisions, on met à jour les positions, on gère les inputs.
        /// </summary>
        /// <param name="gameTime">Correspond aux temps de jeux.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ScreenShakeManager.Update(gameTime);
            level.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// Permet d'afficher tout les éléments du monde.
        /// </summary>
        /// <param name="gameTime">Correspond aux temps de jeux.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(75,75,75));

            level.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        #endregion Draw & Update

        #region Méthodes

        /// <summary>
        /// Permet au jeu d'initialiser tout ses éléments avant de démarrer.
        /// Le chargement de tout les éléments non graphiques vont être chargés.
        /// </summary>
        protected override void Initialize()
        {
            RandomManager.Initialize();
            ScreenShakeManager.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// Permet de charger les éléments graphiques.
        /// </summary>
        protected override void LoadContent()
        {
            // Création d'un nouveau spritebatch pour afficher le monde.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            TextureManager.LoadContent(Content);

            level.Start();
        }

        /// <summary>
        /// Appelé lors de la fin du jeu. Ici on décharge tout les éléments chargés auparavant.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        #endregion Méthodes
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperTutoriel.Classes.Managers;
using System.Collections.Generic;

namespace SuperTutoriel.Classes.GameObjects
{
    /// <summary>
    /// Représente un niveau.
    /// </summary>
    public class Level : IMonogameObject
    {
        #region Propriétés

        /// <summary>
        /// Le joueur.
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// Les balles.
        /// </summary>
        public List<Ball> Balls { get; set; }

        /// <summary>
        /// Les briques.
        /// </summary>
        public List<Brick> Bricks { get; set; }

        #endregion Propriétés

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Level()
        {
            Bricks = new List<Brick>();
            Balls = new List<Ball>();
        }

        #endregion Constructeurs

        #region Draw & Update

        /// <summary>
        /// Met à jour la logique de l'objet.
        /// </summary>
        /// <param name="gameTime">Représente le temps à l'instant T.</param>
        public void Update(GameTime gameTime)
        {
            Player.Update(gameTime);
            Balls.ForEach(x => x.Update(gameTime));
            Bricks.ForEach(x => x.Update(gameTime));

            CheckCollisions();
            ManageObjectToBeDeleted();
        }

        /// <summary>
        /// Affiche l'objet.
        /// </summary>
        /// <param name="spriteBatch">Permet de regrouper l'affichage de texture ou de texte.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Matrix.CreateTranslation(ScreenShakeManager.ScreenShake.X, ScreenShakeManager.ScreenShake.Y, 0));

            Player.Draw(spriteBatch);
            Balls.ForEach(x => x.Draw(spriteBatch));
            Bricks.ForEach(x => x.Draw(spriteBatch));

            spriteBatch.End();
        }

        #endregion Draw & Update

        #region Méthodes

        /// <summary>
        /// Permet de démarrer le niveau.
        /// </summary>
        public void Start()
        {
            AddPlayer();
            AddBall();
            AddBricks();
        }

        /// <summary>
        /// Permet de vérifier les collisions entre les différents éléments du niveau.
        /// </summary>
        public void CheckCollisions()
        {
            foreach (Ball ball in Balls)
            {
                ball.ManageCollision(Player);
                Bricks.ForEach(x => ball.ManageCollision(x));
            }
        }

        /// <summary>
        /// Permet d'ajouter une balle.
        /// </summary>
        public void AddBall()
        {
            Ball ball = new Ball()
            {
                Position = new Vector2(RandomManager.RandomInteger(0, Constantes.WindowWidth), Constantes.WindowHeight/2)
            };

            Balls.Add(ball);
        }

        /// <summary>
        /// Permet d'ajouter le joueur.
        /// </summary>
        public void AddPlayer()
        {
            Player = new Player();
        }

        /// <summary>
        /// Permet d'ajouter les briques du niveau.
        /// </summary>
        public void AddBricks()
        {
            for (int line = 0; line < 4; line++)
            {
                for (int column = 0; column < 10; column++)
                {
                    Brick brick = new Brick()
                    {
                        Position = new Vector2(40 + column * 80, 15 + line * 30)
                    };
                    Bricks.Add(brick);
                }
            }
        }

        /// <summary>
        /// Supprime les éléments à être supprimés.
        /// </summary>
        public void ManageObjectToBeDeleted()
        {
            Bricks.RemoveAll(x => x.HasToBeDeleted);
            Balls.RemoveAll(x => x.HasToBeDeleted);
        }

        #endregion Méthodes
    }
}

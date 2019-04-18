using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperTutoriel.Classes.Managers;

namespace SuperTutoriel.Classes.GameObjects
{
    /// <summary>
    /// Représente un joueur.
    /// </summary>
    public class Player : GameObject
    {
        #region Constructeur

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Player()
        {
            this.Sprite = TextureManager.Textures["Player"];
            this.Position = new Vector2(Constantes.WindowWidth/2, Constantes.WindowHeight - this.Origin.Y);
            this.Color = Color.White;
        }

        #endregion Constructeur

        #region Draw & Update

        /// <summary>
        /// Met à jour la logique de l'objet.
        /// </summary>
        /// <param name="gameTime">Représente le temps à l'instant T.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.Speed = Vector2.Zero;

            // Gére l'input de déplacement vers la gauche.
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.Speed = new Vector2(-5, 0);
            }

            // Gére l'input de déplacement vers la droite.
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.Speed = new Vector2(5, 0);
            }

            // Gére la collision avec le mur gauche.
            if (this.Position.X - this.Origin.X < 0)
            {
                this.Position = new Vector2(this.Origin.X, this.Position.Y);
            }

            // Gére la collision avec le mur droit.
            if (this.Position.X > Constantes.WindowWidth - this.Origin.X)
            {
                this.Position = new Vector2(Constantes.WindowWidth - this.Origin.X, this.Position.Y);
            }
        }

        #endregion Draw & Update
    }
}

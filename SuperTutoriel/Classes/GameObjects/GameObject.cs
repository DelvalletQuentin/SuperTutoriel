using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperTutoriel.Classes.GameObjects
{
    /// <summary>
    /// Représente une entité abstraite de jeu.
    /// </summary>
    public abstract class GameObject : IMonogameObject
    {
        #region Propriétés

        /// <summary>
        /// Texture qui sera affichée.
        /// </summary>
        protected Texture2D Sprite { get; set; }

        /// <summary>
        /// Point d'origine de la texture, placé au milieu de la texture.
        /// </summary>
        protected Vector2 Origin { get; set; }

        /// <summary>
        /// Rectangle de collision de l'objet.
        /// </summary>
        public Rectangle Rectangle { get; set; }

        /// <summary>
        /// Position actuelle de l'objet. Correspond au point en haut à gauche du rectangle.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Correspond à la vitesse actuelle de l'objet.
        /// </summary>
        public Vector2 Speed { get; set; }

        /// <summary>
        /// Angle de rotation de l'entité.
        /// </summary>
        public float Angle { get; set; }

        /// <summary>
        /// Couleur d'affichage de la texture.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Indique si l'objet doit être supprimé ou non.
        /// </summary>
        public bool HasToBeDeleted { get; set; }

        #endregion Propriétés

        #region Méthodes

        /// <summary>
        /// Met à jour la logique de l'objet.
        /// </summary>
        /// <param name="gameTime">Représente le temps à l'instant T.</param>
        public virtual void Update(GameTime gameTime)
        {
            this.Position += this.Speed;
            this.Rectangle = new Rectangle((int)(Position.X - Origin.X), (int)(Position.Y - Origin.Y), Sprite.Width, Sprite.Height);
            this.Origin = new Vector2(Sprite.Width / 2, Sprite.Height / 2);
        }

        /// <summary>
        /// Affiche l'objet.
        /// </summary>
        /// <param name="spriteBatch">Permet de regrouper l'affichage de texture ou de texte.</param>
        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Sprite, Position, null, Color, Angle, Origin, 1, SpriteEffects.None, 1);
        }

        #endregion Méthodes
    }
}

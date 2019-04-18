using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperTutoriel.Classes.GameObjects
{
    /// <summary>
    /// Interface pour les deux méthodes essentielle à Monogame : Draw & Update.
    /// </summary>
    public interface IMonogameObject
    {
        #region Draw & Update
        
        /// <summary>
        /// Met à jour la logique de l'objet.
        /// </summary>
        /// <param name="gameTime">Représente le temps à l'instant T.</param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Affiche l'objet.
        /// </summary>
        /// <param name="spriteBatch">Permet de regrouper l'affichage de texture ou de texte.</param>
        void Draw(SpriteBatch spriteBatch);

        #endregion Draw & Update
    }
}

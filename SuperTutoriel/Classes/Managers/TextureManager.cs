using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SuperTutoriel.Classes.Managers
{
    /// <summary>
    /// Contient les textures utilisées par le jeu.
    /// </summary>
    public static class TextureManager
    {
        #region Propriétés

        /// <summary>
        /// Contient toutes les textures du jeu.
        /// </summary>
        public static Dictionary<string, Texture2D> Textures;

        #endregion Propriétés

        #region Méthodes

        /// <summary>
        /// Permet de charger toutes les textures.
        /// </summary>
        /// <param name="content">Le manageur de contenu.</param>
        public static void LoadContent(ContentManager content)
        {
            Textures = new Dictionary<string, Texture2D>();

            Textures.Add("Player", content.Load<Texture2D>("Player"));
            Textures.Add("Brick", content.Load<Texture2D>("Brick"));
            Textures.Add("Ball", content.Load<Texture2D>("Ball"));
        }

        #endregion Méthodes
    }
}

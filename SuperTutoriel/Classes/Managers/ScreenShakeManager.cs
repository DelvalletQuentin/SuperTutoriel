using Microsoft.Xna.Framework;

namespace SuperTutoriel.Classes.Managers
{
    /// <summary>
    /// Gére le screenshake.
    /// </summary>
    public static class ScreenShakeManager
    {
        #region Propriétés

        /// <summary>
        /// La valeur du tremblement d'écran actuel.
        /// </summary>
        public static Vector2 ScreenShake { get; set; }

        #endregion Propriétés

        #region Méthodes

        /// <summary>
        /// Permet d'initialiser le manager.
        /// </summary>
        public static void Initialize()
        {
            ScreenShake = Vector2.Zero;
        }

        /// <summary>
        /// Met à jour la logique de l'objet.
        /// </summary>
        /// <param name="gameTime">Représente le temps à l'instant T.</param>
        public static void Update(GameTime gameTime)
        {
            ScreenShake /= 2;
        }

        /// <summary>
        /// Permet d'augmenter le tremblement d'écran.
        /// </summary>
        public static void AddScreenShake(int value)
        {
            ScreenShake += new Vector2(value);
        }

        #endregion Méthodes
    }
}

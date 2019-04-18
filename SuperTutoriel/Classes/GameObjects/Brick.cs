using Microsoft.Xna.Framework;
using SuperTutoriel.Classes.Managers;

namespace SuperTutoriel.Classes.GameObjects
{
    /// <summary>
    /// Représente une brique.
    /// </summary>
    public class Brick : GameObject
    {
        #region Constructeur

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Brick()
        {
            Sprite = TextureManager.Textures["Brick"];
            Color = new Color(RandomManager.RandomInteger(150, 255), RandomManager.RandomInteger(150, 255), RandomManager.RandomInteger(150, 255));
        }

        #endregion Constructeur

        #region Méthodes
        
        /// <summary>
        /// Permet de détruire la brique.
        /// </summary>
        public void Destroy()
        {
            this.HasToBeDeleted = true;
            ScreenShakeManager.AddScreenShake(RandomManager.RandomInteger(-5, 5));
        }

        #endregion Méthodes
    }
}

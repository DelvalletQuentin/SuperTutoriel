using System;

namespace SuperTutoriel.Classes.Managers
{
    /// <summary>
    /// Permet de gérer tout les éléments aléatoire du jeu.
    /// </summary>
    public static class RandomManager
    {
        #region Propriétés
        
        /// <summary>
        /// Gére l'aléatoire.
        /// </summary>
        public static Random Random { get; set; }

        #endregion Propriétés

        #region Méthodes

        /// <summary>
        /// Permet d'initialiser le manager.
        /// </summary>
        public static void Initialize()
        {
            Random = new Random();
        }
        
        /// <summary>
        /// Permet d'obtenir une valeur entière aléatoire.
        /// </summary>
        /// <param name="minValue">Valeur minimale de l'entier.</param>
        /// <param name="maxValue">Valeur maximal de l'entier.</param>
        /// <returns>Une valeur entière aléatoire entre {minValue} et {maxValue}</returns>
        public static int RandomInteger(int minValue, int maxValue)
        {
            return Random.Next(minValue, maxValue);
        }

        #endregion Méthodes
    }
}

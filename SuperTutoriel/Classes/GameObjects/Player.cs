using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperTutoriel.Classes.Managers;
using System;

namespace SuperTutoriel.Classes.GameObjects
{
    /// <summary>
    /// Représente un joueur.
    /// </summary>
    public class Player : GameObject
    {
        #region Propriétés

        /// <summary>
        /// Vitesse maximal.
        /// </summary>
        protected Vector2 MaxSpeed { get; set; }
        
        /// <summary>
        /// Coefficient d'acceleration.
        /// </summary>
        protected float Acceleration { get; set; }
        
        /// <summary>
        /// Coefficient de friction, correspond au ralentissement du joueur sans inputs.
        /// </summary>
        protected float Friction { get; set; }

        #endregion Propriétés

        #region Constructeur

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Player()
        {
            this.Sprite = TextureManager.Textures["Player"];
            this.Position = new Vector2(Constantes.WindowWidth/2, Constantes.WindowHeight - this.Origin.Y);
            this.Color = Color.White;
            this.MaxSpeed = new Vector2(7, 0);
            this.Acceleration = 0.25f
            this.Friction = 0.25f
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


            // Gére l'input de déplacement vers la gauche.
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                // Si la vitesse n'est pas à sa valeur maximal, on accélere.
                if (Math.Abs(this.Speed.X) < this.MaxSpeed.X) this.Speed += new Vector2(-Acceleration, 0);
            }
            else
            {
                // On réduit la vitesse du joueur, si elle n'est pas déjà au minimum.
                if(this.Speed.X < 0) this.Speed -= new Vector2(-Friction, 0);
            }

            // Gére l'input de déplacement vers la droite.
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                // Si la vitesse n'est pas à sa valeur maximal, on accélere.
                if (Math.Abs(this.Speed.X) < this.MaxSpeed.X) this.Speed += new Vector2(Acceleration, 0);
            }
            else
            {
                // On réduit la vitesse du joueur, si elle n'est pas déjà au minimum.
                if (this.Speed.X > 0) this.Speed -= new Vector2(Friction, 0);
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

            // On change l'angle du joueur en fonction de sa vitesse, pour que ça soit plus sympa visuellement.
            this.Angle = this.Speed.X * 0.03f;
        }

        #endregion Draw & Update
    }
}

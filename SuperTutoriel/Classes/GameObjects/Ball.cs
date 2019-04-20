using Microsoft.Xna.Framework;
using SuperTutoriel.Classes.Managers;
using System;

namespace SuperTutoriel.Classes.GameObjects
{
    /// <summary>
    /// Représente une balle.
    /// </summary>
    public class Ball : GameObject
    {
        #region Constructeur

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public Ball()
        {
            this.Sprite = TextureManager.Textures["Ball"];
            this.Speed = new Vector2(4, -4);
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

            // Vérifie la collision avec le mur gauche.
            if (this.Position.X < this.Origin.X)
            {
                this.Speed = new Vector2(Math.Abs(this.Speed.X), this.Speed.Y);
            }

            // Vérifie la collision avec le mur droit.
            if (this.Position.X > Constantes.WindowWidth - this.Origin.X)
            {
                this.Speed = new Vector2(-Math.Abs(this.Speed.X), this.Speed.Y);
            }

            // Vérifie la collision avec le mur haut.
            if (this.Position.Y < this.Origin.Y)
            {
                this.Speed = new Vector2(this.Speed.X, -this.Speed.Y);
            }

            // Vérifie la collision avec le mur bas.
            if (this.Position.Y > Constantes.WindowHeight - this.Origin.Y)
            {
                this.HasToBeDeleted = true;
            }
        }

        #endregion Draw & Update

        #region Méthodes

        /// <summary>
        /// Gère les collision avec l'entité passée en paramètre, ici une brique.
        /// </summary>
        /// <param name="brick">La brique dont il faut vérifier si elle est en collision.</param>
        public void ManageCollision(Brick brick)
        {
            // J'utilise la formule trouvée ici : https://gamedev.stackexchange.com/a/29796
            // Cette formule utilise ceci :  https://fr.wikipedia.org/wiki/Somme_de_Minkowski
            float width = 0.5f * (brick.Rectangle.Width + this.Rectangle.Width);
            float height = 0.5f * (brick.Rectangle.Height + this.Rectangle.Height);
            float distanceX = brick.Rectangle.Center.X - this.Rectangle.Center.X;
            float distanceY = brick.Rectangle.Center.Y - this.Rectangle.Center.Y;

            // On regarde s'il y a collision.
            if (Math.Abs(distanceX) <= width && Math.Abs(distanceY) <= height)
            {
                // On demande la destruction de la brique.
                brick.Destroy();

                float widthY = width * distanceY;
                float heightX = height * distanceX;

                if (widthY > heightX)
                {
                    if (widthY > -heightX)
                    {
                        // Collision sur le côté haut de la brique.
                        this.Speed = new Vector2(this.Speed.X, -Math.Abs(this.Speed.Y));
                    }
                    else
                    {
                        // Collision sur le côté droit de la brique.
                        this.Speed = new Vector2(Math.Abs(this.Speed.X), this.Speed.Y);
                    }
                }
                else
                {
                    if (widthY > -heightX)
                    {
                        // Collision sur le côté gauche de la brique.
                        this.Speed = new Vector2(-Math.Abs(this.Speed.X), this.Speed.Y);
                    }
                    else
                    {
                        // Collision sur le côté bas de la brique.
                        this.Speed = new Vector2(this.Speed.X, Math.Abs(this.Speed.Y));
                    }
                }
            }
        }

        /// <summary>
        /// Gère les collision avec l'entité passée en paramètre, ici le joueur.
        /// </summary>
        /// <param name="brick">Le joueur dont il faut vérifier si elle est en collision.</param>
        public void ManageCollision(Player player)
        {
            // J'utilise la formule trouvée ici : https://gamedev.stackexchange.com/a/29796
            // Cette formule utilise ceci :  https://fr.wikipedia.org/wiki/Somme_de_Minkowski
            float width = 0.5f * (player.Rectangle.Width + this.Rectangle.Width);
            float height = 0.5f * (player.Rectangle.Height + this.Rectangle.Height);
            float distanceX = player.Rectangle.Center.X - this.Rectangle.Center.X;
            float distanceY = player.Rectangle.Center.Y - this.Rectangle.Center.Y;

            // On regarde s'il y a collision.
            if (Math.Abs(distanceX) <= width && Math.Abs(distanceY) <= height)
            {
                float widthY = width * distanceY;
                float heightX = height * distanceX;

                if (widthY > heightX)
                {
                    // Collision sur le côté haut du joueur.

                    // On change la vitesse horizontale de la balle en fonction de la distance
                    // du centre du joueur et de la vitesse du joueur.
                    this.Speed = new Vector2(-distanceX / 10f + player.Speed.X/2, -this.Speed.Y);
                }
            }
        }

        #endregion Méthodes
    }
}

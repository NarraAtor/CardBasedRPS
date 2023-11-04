using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game
{
    public enum CardType
    {
        Rock,
        Paper,
        Scissors
    }

    /// <summary>
    /// Card Script.
    /// </summary>
    public class Card : Script
    {
        private CardType cardType;
        private Image image;
        public CardType CardType { get { return cardType; } set { cardType = value; } }

        /// <inheritdoc/>
        public override void OnStart()
        {
            image = Actor.GetScript<Image>();
            // Here you can add code that needs to be called when script is created, just before the first game update
            SetCardColor();
        }
        
        /// <inheritdoc/>
        public override void OnEnable()
        {
            // Here you can add code that needs to be called when script is enabled (eg. register for events)
        }

        /// <inheritdoc/>
        public override void OnDisable()
        {
            // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
        }

        /// <inheritdoc/>
        public override void OnUpdate()
        {
            // Here you can add code that needs to be called every frame

        }

        private void SetCardColor()
        {
            switch (cardType)
            {
                case CardType.Rock:
                    image.Color = Color.Green;

                    break;
                case CardType.Paper:
                    image.Color = Color.Green;
                    break;
                case CardType.Scissors:
                    image.Color = Color.Green;

                    break;
            }
        }
    }
}

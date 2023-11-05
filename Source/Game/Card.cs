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
        public UIControl UIEle;
        public CardType CardType { get { return _cardType; } set { _cardType = value; } }
        public Texture rockTexture;
        public Texture paperTexture;
        public Texture scissorsTexture;
        public Texture cardbackTexture;

        private CardType _cardType;
        private Button _button;

        /// <inheritdoc/>
        public override void OnStart()
        {
            // Here you can add code that needs to be called when script is created, just before the first game update

            // Is this the only way of doing this? There should be a way for me to pass in/refer to this image directly
            _button = UIEle.Get<Button>();
            _button.ButtonClicked += OnButtonClicked;
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
            //SetCardColor();
        }

        private void OnButtonClicked(Button button)
        {
            Debug.Log($"Hovered over card: {button}");
        }

        private void SetCardColor()
        {
            switch (_cardType)
            {
                case CardType.Rock:
                    //_image.Color = Color.Red;

                    break;
                case CardType.Paper:
                    //_image.Color = Color.Green;
                    break;
                case CardType.Scissors:
                    //_image.Color = Color.Blue;

                  break;
            }
        }

    }
}

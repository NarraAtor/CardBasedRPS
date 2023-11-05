using System;
using System.Collections.Generic;
using FlaxEngine;

namespace Game
{
    /// <summary>
    /// AudioManager Script.
    /// </summary>
    public class AudioManager : Script
    {

        public AudioSource Source;

        /// <inheritdoc/>
        public override void OnStart()
        {
            //Source.Play();
            // Here you can add code that needs to be called when script is created, just before the first game update
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

        public void PlaySound(CardType cardType)
        {
            switch (cardType)
            {
                case CardType.Rock:
                    break;
                case CardType.Paper:
                    break;
                case CardType.Scissors:
                    break;
            }
        }
    }
}

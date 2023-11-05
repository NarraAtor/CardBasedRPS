using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game
{
    /// <summary>
    /// GameManager Script.
    /// </summary>
    public class GameManager : Script
    {
        public Prefab cardPrefab;

        private List<Card> _deck;
        private List<Card> _playerHand;
        private List<Card> _aiHand;

        /// <inheritdoc/>
        public override void OnStart()
        {
            _deck = new List<Card>();
            _playerHand = new List<Card>();
            _aiHand = new List<Card>();

            PrefabManager.SpawnPrefab(cardPrefab);
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
    }
}

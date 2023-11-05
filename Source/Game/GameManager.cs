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
        public Actor deckActor;

        private List<Card> _deck;
        private List<Card> _playerHand;
        private List<Card> _aiHand;

        /// <inheritdoc/>
        public override void OnStart()
        {
            _deck = new List<Card>();
            Card card = new Card();
            _playerHand = new List<Card>();
            _aiHand = new List<Card>();

            GenerateDeck();
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

        public void GenerateDeck()
        {
            _deck.Clear();
            _playerHand.Clear();
            _aiHand.Clear();

            // create three cards of each type (rock, paper, scissors) and shuffle them into the deck
            for (int i = 0; i < 3; i++)
            {
                _deck.Add(PrefabManager.SpawnPrefab(cardPrefab, deckActor).GetScript<Card>());
            }
        }
    }
}

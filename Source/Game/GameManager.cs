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
        public Actor playerHandActor;
        public Actor aiHandActor;

        private List<Card> _deck;
        private List<Card> _playerHand;
        private List<Card> _aiHand;

        private readonly int NUM_OF_EACH_CARD_IN_DECK = 3;

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

        private void InitGame()
        {
            GenerateDeck();

            // draw the player and AI hands

        }

        private void GenerateDeck()
        {
            _deck.Clear();
            _playerHand.Clear();
            _aiHand.Clear();

            // create three cards of each type (rock, paper, scissors) and shuffle them into the deck
            // Rock cards
            for (int i = 0; i < NUM_OF_EACH_CARD_IN_DECK; i++)
            {
                Card newCard = PrefabManager.SpawnPrefab(cardPrefab, deckActor).GetScript<Card>();
                newCard.CardType = CardType.Rock;
                _deck.Add(newCard);
            }
            // Paper cards
            for (int i = 0; i < NUM_OF_EACH_CARD_IN_DECK; i++)
            {
                Card newCard = PrefabManager.SpawnPrefab(cardPrefab, deckActor).GetScript<Card>();
                newCard.CardType = CardType.Paper;
                _deck.Add(newCard);
            }
            // Scissor cards
            for (int i = 0; i < NUM_OF_EACH_CARD_IN_DECK; i++)
            {
                Card newCard = PrefabManager.SpawnPrefab(cardPrefab, deckActor).GetScript<Card>();
                newCard.CardType = CardType.Scissors;
                _deck.Add(newCard);
            }

            // shuffle deck later
        }
    }
}

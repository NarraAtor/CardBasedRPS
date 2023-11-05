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

        private int _playerScore = 0;
        private int _aiScore = 0;

        private readonly int NUM_OF_EACH_CARD_IN_DECK = 4;
        private readonly int HAND_SIZE = 3;

        /// <inheritdoc/>
        public override void OnStart()
        {
            _deck = new List<Card>();
            Card card = new Card();
            _playerHand = new List<Card>();
            _aiHand = new List<Card>();

            InitGame();
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

            // draw the player hand from the deck
            for (int i = 0; i < HAND_SIZE; i++)
            {
                Card card = _deck[i];
                _deck.Remove(card);
                _playerHand.Add(card);
                card.Actor.SetParent(playerHandActor, false);
                card.UIEle.Get<Button>().Enabled = true;
            }

            // draw the ai hand from the deck
            for (int i = 0; i < HAND_SIZE; i++)
            {
                Card card = _deck[i];
                _deck.Remove(card);
                _aiHand.Add(card);
                card.Actor.SetParent(aiHandActor, false);
            }
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
                newCard.AudioManager = Actor.FindActor("Audio Manager").GetScript<AudioManager>();
                newCard.CardType = CardType.Rock;
                newCard.UIEle.Get<Button>().Enabled = false;
                _deck.Add(newCard);
            }
            // Paper cards
            for (int i = 0; i < NUM_OF_EACH_CARD_IN_DECK; i++)
            {
                Card newCard = PrefabManager.SpawnPrefab(cardPrefab, deckActor).GetScript<Card>();
                newCard.AudioManager = Actor.FindActor("Audio Manager").GetScript<AudioManager>();
                newCard.CardType = CardType.Paper;
                newCard.UIEle.Get<Button>().Enabled = false;
                _deck.Add(newCard);
            }
            // Scissor cards
            for (int i = 0; i < NUM_OF_EACH_CARD_IN_DECK; i++)
            {
                Card newCard = PrefabManager.SpawnPrefab(cardPrefab, deckActor).GetScript<Card>();
                newCard.AudioManager = Actor.FindActor("Audio Manager").GetScript<AudioManager>();
                newCard.CardType = CardType.Scissors;
                newCard.UIEle.Get<Button>().Enabled = false;
                _deck.Add(newCard);
            }

            // shuffle the deck
            Utilities.Shuffle(_deck);
        }

        public void TakePlayerTurn(Card cardToPlay)
        {
            // get the card the ai is gonna play
            Card aiCard = _aiHand[(int) (RandomUtil.Rand() * _aiHand.Count)];
            Debug.Log(aiCard.CardType);

            // rock paper scissors logic
            switch (GetRPSWinner(cardToPlay, aiCard))
            {
                case RoundResult.PlayerWin:
                    Debug.Log("Player won");
                    break;
                case RoundResult.PlayerLose:
                    Debug.Log("Player lost");
                    break;
                case RoundResult.Tie:
                    Debug.Log("Round tie");
                    break;
            }
        }

        /// <summary>
        /// Returns the results of a round.
        /// </summary>
        /// <param name="playerCard"></param>
        /// <param name="otherCard"></param>
        /// <returns>The result of the round</returns>
        private RoundResult GetRPSWinner(Card playerCard,  Card otherCard)
        {
            if (playerCard.CardType == otherCard.CardType)
                return RoundResult.Tie;
            if (playerCard.CardType == otherCard.CardType + 1 % 2)
                return RoundResult.PlayerWin;
            else
                return RoundResult.PlayerLose;
        }

        private enum RoundResult
        {
            PlayerWin,
            PlayerLose,
            Tie
        }
    }
}

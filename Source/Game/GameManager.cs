using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game
{
    enum RoundResult
    {
        PlayerWin,
        PlayerLose,
        Draw
    }

    /// <summary>
    /// GameManager Script.
    /// </summary>
    public class GameManager : Script
    {
        public Prefab cardPrefab;
        public Actor deckActor;
        public Actor playerHandActor;
        public Actor aiHandActor;
        public AudioManager audioManager;

        public AudioClip playerPlayedRockClip;
        public AudioClip playerPlayedPaperClip;
        public AudioClip playerPlayedScissorsClip;
        
        public AudioClip aiPlayedRockClip;
        public AudioClip aiPlayedPaperClip;
        public AudioClip aiPlayedScissorsClip;

        public AudioClip playerWonRoundClip;
        public AudioClip playerLostRoundClip;
        public AudioClip roundDrawClip;

        public AudioClip playerWonGameClip;
        public AudioClip playerLostGameClip;
        public AudioClip gameDrawClip;

        private List<Card> _deck;
        private List<Card> _playerHand;
        private List<Card> _aiHand;

        private int _playerScore = 0;
        private int _aiScore = 0;
        private bool _gameOver = false;

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
                newCard.GameManager = this;
                newCard.CardType = CardType.Rock;
                newCard.UIEle.Get<Button>().Enabled = false;
                _deck.Add(newCard);
            }
            // Paper cards
            for (int i = 0; i < NUM_OF_EACH_CARD_IN_DECK; i++)
            {
                Card newCard = PrefabManager.SpawnPrefab(cardPrefab, deckActor).GetScript<Card>();
                newCard.AudioManager = Actor.FindActor("Audio Manager").GetScript<AudioManager>();
                newCard.GameManager = this;
                newCard.CardType = CardType.Paper;
                newCard.UIEle.Get<Button>().Enabled = false;
                _deck.Add(newCard);
            }
            // Scissor cards
            for (int i = 0; i < NUM_OF_EACH_CARD_IN_DECK; i++)
            {
                Card newCard = PrefabManager.SpawnPrefab(cardPrefab, deckActor).GetScript<Card>();
                newCard.AudioManager = Actor.FindActor("Audio Manager").GetScript<AudioManager>();
                newCard.GameManager = this;
                newCard.CardType = CardType.Scissors;
                newCard.UIEle.Get<Button>().Enabled = false;
                _deck.Add(newCard);
            }

            // shuffle the deck
            Utilities.Shuffle(_deck);
        }

        public void TakePlayerTurn(Card playerCardToPlay)
        {
            List<AudioClip> clips = new List<AudioClip>();
            // get the card the ai is gonna play
            Card aiCard = _aiHand[(int) (RandomUtil.Rand() * _aiHand.Count)];
            clips.AddRange(GetPlayedCardsAudioClips(playerCardToPlay, aiCard));            

            // rock paper scissors logic
            switch (GetRoundResult(playerCardToPlay, aiCard))
            {
                case RoundResult.PlayerWin:
                    clips.Add(playerWonRoundClip);
                    _playerScore++;
                    break;
                case RoundResult.PlayerLose:
                    clips.Add(playerLostRoundClip);
                    _aiScore++;
                    break;
                case RoundResult.Draw:
                    clips.Add(roundDrawClip);
                    break;
            }

            // remove from hands
            _playerHand.Remove(playerCardToPlay);
            _aiHand.Remove(aiCard);
            playerCardToPlay.Actor.IsActive = false;
            aiCard.Actor.IsActive = false;
            // draw to hands from the deck
            if (_playerHand.Count == 0)
            {
                GameOver();
                clips.Add(GetEndGameAudioClip());
            }
            if (_deck.Count > 0) 
            {
                DrawCards();
            }

            audioManager.PlaySoundContinuously(clips);
        }

        private void DrawCards()
        {
            Debug.Log("Drawing Cards...");
            Card drawnPlayerCard = _deck[_deck.Count-1];
            Debug.Log(drawnPlayerCard);
            _deck.Remove(drawnPlayerCard);
            _playerHand.Add(drawnPlayerCard);
            drawnPlayerCard.Actor.SetParent(playerHandActor, false);
            drawnPlayerCard.UIEle.Get<Button>().Enabled = true;

            Card drawnAiCard = _deck[_deck.Count-1];
            _deck.Remove(drawnAiCard);
            _aiHand.Add(drawnAiCard);
            drawnAiCard.Actor.SetParent(aiHandActor, false);
        }

        /// <summary>
        /// Returns the results of a round.
        /// </summary>
        /// <param name="playerCard"></param>
        /// <param name="otherCard"></param>
        /// <returns>The result of the round</returns>
        private RoundResult GetRoundResult(Card playerCard,  Card otherCard)
        {
            if (playerCard.CardType == otherCard.CardType)
                return RoundResult.Draw;
            if (playerCard.CardType == otherCard.CardType + 1 % 2)
                return RoundResult.PlayerWin;
            else
                return RoundResult.PlayerLose;
        }

        private void GameOver()
        {
            _gameOver = true;
            Debug.Log("Last round played. Ending game.");

            
        }

        private List<AudioClip> GetPlayedCardsAudioClips(Card playerCard, Card aiCard)
        {
            List<AudioClip> clips = new List<AudioClip>();
            switch (playerCard.CardType)
            {
                case CardType.Rock:
                    clips.Add(playerPlayedRockClip);
                    break;
                case CardType.Paper:
                    clips.Add(playerPlayedPaperClip);
                    break;
                case CardType.Scissors:
                    clips.Add(playerPlayedScissorsClip);
                    break;
            }

            switch (aiCard.CardType)
            {
                case CardType.Rock:
                    clips.Add(aiPlayedRockClip);
                    break;
                case CardType.Paper:
                    clips.Add(aiPlayedPaperClip);
                    break;
                case CardType.Scissors:
                    clips.Add(aiPlayedScissorsClip);
                    break;
            }

            return clips;
        }

        private AudioClip GetEndGameAudioClip()
        {
            if (_playerScore > _aiScore)
            {
                return playerWonGameClip;
            }
            else if (_playerScore < _aiScore)
            {
                return playerLostGameClip;
            }
            else
            {
                return gameDrawClip;
            }
        }
    }
}

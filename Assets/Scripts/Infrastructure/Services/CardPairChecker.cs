using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardPairChecker
{
    private readonly ICoroutineRunner coroutineRunner;
    private readonly GameFactory gameFactory;
    private readonly Card[] flippedCards = new Card[2];
    private int flippedCardsCount;
    
    public static event Action WonGame;
    
    public CardPairChecker(ICoroutineRunner coroutineRunner, GameFactory gameFactory)
    {
        this.coroutineRunner = coroutineRunner;
        this.gameFactory = gameFactory;
        CardAnimator.CardBackFlipped += RegisterFlippedCard;
    }
    

    public bool CanFlipCard(Card card)
    {
        return flippedCardsCount != 2 && !card.IsHinted;
    }


    private void RegisterFlippedCard(Card card)
    {
        if (CanFlipCard(card))
        {
            flippedCards[flippedCardsCount] = card;
            flippedCardsCount++;

            if (flippedCardsCount == 2)
            {
                coroutineRunner.StartCoroutine(CheckMatch());
            }
        }
    }


    private IEnumerator CheckMatch()
    {
        if (flippedCards[0].CardType == flippedCards[1].CardType)
        {
            flippedCards[0].IsMatched = true;
            flippedCards[1].IsMatched = true;
            
            CheckForWinCondition();
        }
        else
        {
            yield return new WaitForSeconds(1);

            flippedCards[0].FlipCard();
            flippedCards[1].FlipCard();
        }

        flippedCardsCount = 0;
    }
    
    
    private void CheckForWinCondition()
    {
        bool allCardsMatched = true;

        foreach (Card card in gameFactory.SpawnedCards)
        {
            if (!card.IsMatched)
            {
                allCardsMatched = false;
                break;
            }
        }

        if (allCardsMatched)
        {
            WonGame?.Invoke();
            Debug.Log("Win");
        }
    }
}
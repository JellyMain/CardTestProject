using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;


public class HintButton : MonoBehaviour
{
    private Coroutine showAndHideCoroutine;
    private GameFactory gameFactory;


    [Inject]
    private void Construct(GameFactory gameFactory)
    {
        this.gameFactory = gameFactory;
    }


    private void Start()
    {
        StartShowAndHideCards();
    }



    public void ShuffleAndShowCards()
    {
        if (showAndHideCoroutine == null)
        {
            ShuffleInHierarchy();
            StartShowAndHideCards();
        }
    }


    private void StartShowAndHideCards()
    {
        showAndHideCoroutine = StartCoroutine(ShowAndHideCards());
    }


    private IEnumerator ShowAndHideCards()
    {
        yield return new WaitForSeconds(0.1f);

        foreach (Card card in gameFactory.SpawnedCards)
        {
            if(card.IsMatched) continue;
            
            card.IsHinted = true;
            card.FlipCard();
        }

        yield return new WaitForSeconds(1);


        foreach (Card card in gameFactory.SpawnedCards)
        {
            if(card.IsMatched) continue;
            
            card.FlipCard();
            card.IsHinted = false;
        }

        yield return new WaitForSeconds(0.6f);

        showAndHideCoroutine = null;
    }


    private void ShuffleInHierarchy()
    {
        foreach (Card cardObject in gameFactory.SpawnedCards)
        {
            if (!cardObject.IsMatched)
            {
                int randomIndex = Random.Range(0, gameFactory.SpawnedCards.Count);
                cardObject.transform.SetSiblingIndex(randomIndex);
            }
        }
    }
}

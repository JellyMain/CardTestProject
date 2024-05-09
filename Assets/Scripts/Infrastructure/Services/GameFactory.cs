using System.Collections.Generic;
using Zenject;
using UnityEngine;



public class GameFactory
{
    private readonly DeckCreator deckCreator;
    private readonly AssetProvider assetProvider;
    private readonly DiContainer diContainer;
    private RectTransform cardsContainer;

    public List<Card> SpawnedCards { get; private set; }



    public GameFactory(DeckCreator deckCreator, AssetProvider assetProvider, DiContainer diContainer)
    {
        this.deckCreator = deckCreator;
        this.assetProvider = assetProvider;
        this.diContainer = diContainer;
    }

    
    
    public void CreateCards()
    {
        deckCreator.CreateStartingDeck();
        
        SpawnedCards = new List<Card>();
        
        foreach (Card card in deckCreator.StartingDeck)
        {
            Card spawnedCard = diContainer.InstantiatePrefabForComponent<Card>(card, cardsContainer);
            SpawnedCards.Add(spawnedCard);
        }
    }


    public void CreateCardsContainer()
    {
        cardsContainer = assetProvider.Instantiate(AssetPaths.CARDS_CANVAS).transform.GetChild(0)
            .GetComponent<RectTransform>();
    }

    
}

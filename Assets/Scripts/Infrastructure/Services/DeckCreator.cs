using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class DeckCreator 
{
    private readonly AssetProvider assetProvider;
    private readonly GameSettings gameSettings;
    public List<Card> StartingDeck { get; private set; }

    
    public DeckCreator(AssetProvider assetProvider, GameSettings gameSettings)
    {
        this.assetProvider = assetProvider;
        this.gameSettings = gameSettings;
    }


    public void CreateStartingDeck()
    {
        List<Card> allCardVariants = assetProvider.LoadCardVariantsPrefabs();

        List<Card> selectedCardVariants = allCardVariants.Take(gameSettings.GameSettingsData.availableCardPairs).ToList();
        
        List<Card> cardsClone = selectedCardVariants.ToList();

        StartingDeck = selectedCardVariants.Concat(cardsClone).ToList();

        ShuffleDeck();
    }


    private void ShuffleDeck()
    {
        for (int i = 0; i < StartingDeck.Count; i++)
        {
            Card card = StartingDeck[i];
            int randomIndex = Random.Range(i, StartingDeck.Count);
            StartingDeck[i] = StartingDeck[randomIndex];
            StartingDeck[randomIndex] = card;
        }
    }
}
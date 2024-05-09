using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using Zenject;


public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CardType cardType;
    public CardType CardType => cardType;

    private CardPairChecker cardPairChecker;
    public bool IsFlipped { get; set; }
    public bool IsMatched { get; set; }
    public bool IsHinted { get; set; }

    public event Action CardFlipped;


    [Inject]
    private void Construct(CardPairChecker cardPairChecker)
    {
        this.cardPairChecker = cardPairChecker;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (!IsFlipped && !IsMatched && cardPairChecker.CanFlipCard(this))
        {
            FlipCard();
        }
    }


    public void FlipCard()
    {
        CardFlipped?.Invoke();
    }
}

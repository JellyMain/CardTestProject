using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class CardAnimator : MonoBehaviour
{
    [SerializeField] private float animationDuration = 0.5f;
    [SerializeField] private Sprite frontSide;
    [SerializeField] private Sprite backSide;
    private RectTransform rectTransform;
    private Card card;
    private Image cardImage;
    
    private bool isChangedSprite;

    public static event Action<Card> CardBackFlipped;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        cardImage = GetComponent<Image>();
        card = GetComponentInParent<Card>();
    }


    private void Start()
    {
        card.CardFlipped += OnCardFlipped;
    }


    private void OnCardFlipped()
    {
        StartCoroutine(FlipAnimation());
    }


    IEnumerator FlipAnimation()
    {
        float elapsedTime = 0f;
        Quaternion startRotation = rectTransform.rotation;
        Quaternion endRotation;

        if (!card.IsFlipped)
        {
            endRotation = Quaternion.Euler(rectTransform.rotation.x, 180, rectTransform.rotation.z);
            CardBackFlipped?.Invoke(card);
        }
        else
        {
            endRotation = Quaternion.Euler(rectTransform.rotation.x, 0, rectTransform.rotation.z);
        }

        Sprite cardSprite = card.IsFlipped ? backSide : frontSide;
        card.IsFlipped = !card.IsFlipped;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animationDuration;
            rectTransform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            
            if (t>0.5f && !isChangedSprite)
            {
                cardImage.sprite = cardSprite;
                isChangedSprite = true;
            }
            
            yield return null;
        }

        rectTransform.rotation = endRotation;
        isChangedSprite = false;
    }
}

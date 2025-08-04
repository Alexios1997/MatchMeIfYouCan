using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private CardType _cardType;
    [SerializeField] private Image _imageCard;
    
    
    public void PopulateCard(CardType cardType)
    {
        _cardType =  cardType;
        Debug.Log(_cardType.name + " has been populated");
        _imageCard.sprite = _cardType.cardFront;
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private float _durationToFlipAll;
    [SerializeField] private GameEvent _OnCardClicked;
    [SerializeField] private SelectedCardListVariable _selectedCardList;
    [SerializeField] private Image _imageCard;
    [SerializeField] private Button _buttonCard;
    
    private CardType _currentCardType;
    private bool _isFlipped;
    private RectTransform _currentCardRect;
    private void Start()
    {
        _currentCardRect = this.gameObject.GetComponent<RectTransform>();
    }

    private IEnumerator Initialize()
    {
        _isFlipped = true;
        yield return new WaitForSeconds(_durationToFlipAll);
        FlipCard();
        _buttonCard.onClick.RemoveAllListeners();
        _buttonCard.onClick.AddListener(OnCardClicked);
    }
    
    private void OnCardClicked()
    {
        if (_selectedCardList.SelectedCards.Count > 1) return;
        if (_isFlipped) return;
        FlipCard();
        _selectedCardList.Add(this.gameObject);
        _OnCardClicked.Raise();
    }

    public void FlipCard()
    {
        if (_isFlipped)
        {
            _isFlipped = false;
            StartCoroutine(StartFlipping());
        }
        else
        {
            _isFlipped = true;
            StartCoroutine(StartFlipping());
        }
    }

    private IEnumerator StartFlipping()
    {
        
        yield return AnimationUI.TweenVec3(
            _currentCardRect.localScale,
            new Vector3(0f, 1f, 1f),
            0.15f,
            val => _currentCardRect.localScale = val,
            AnimationUI.EaseInOutSine
        );

        
        _imageCard.sprite = _isFlipped ? _currentCardType.cardFront : _currentCardType.cardBack;

        
        yield return AnimationUI.TweenVec3(
            new Vector3(0f, 1f, 1f),
            new Vector3(1f, 1f, 1f),
            0.15f,
            val => _currentCardRect.localScale = val,
            AnimationUI.EaseInOutSine
        );
    }

    public CardType GetCurrentCardType()
    {
        return _currentCardType;
    }
    
    public void PopulateCard(CardType cardType)
    {
        _currentCardType =  cardType;
        _imageCard.sprite = _currentCardType.cardFront;
        StartCoroutine(Initialize());
    }

    public void DisableCard()
    {
        this.gameObject.SetActive(false);
    }
    
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [Header("Injected Dependencies")]
    [Space]
    [Header("Events")]
    [SerializeField] private GameEvent _OnCardClicked;
    [Space]
    [Header("Variables")]
    [SerializeField] private float _durationToFlipAll;
    [SerializeField] private SelectedCardListVariable _selectedCardList;
    [Space]
    [Header("GameObjects")]
    [SerializeField] private Image _imageCard;
    [SerializeField] private Button _buttonCard;
    
    // Private and NOT serialized variables
    private CardType _currentCardType;
    private bool _isFlipped;
    private RectTransform _currentCardRect;
    
    private void Start()
    {
        _currentCardRect = this.gameObject.GetComponent<RectTransform>();
    }

    // At first wait and FlipCards
    private IEnumerator Initialize()
    {
        _isFlipped = true;
        yield return new WaitForSeconds(_durationToFlipAll);
        FlipCard();
        _buttonCard.onClick.RemoveAllListeners();
        _buttonCard.onClick.AddListener(OnCardClicked);
    }
    
    // ON card clicked Add this card clicked on selected cards List
    // and fire the Corresponded Event
    private void OnCardClicked()
    {
        if (_selectedCardList.SelectedCards.Count > 1) return;
        if (_isFlipped) return;
        FlipCard();
        _selectedCardList.Add(this.gameObject);
        _OnCardClicked.Raise();
    }

    // Flip card according to if it is flipped or not
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

    // Tweening the Flipping by
    // 1. Scale it down to X 
    // 2. Change the sprite accordingcly 
    // 3. Scale it up to X 
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

    // Get Current Card Type
    public CardType GetCurrentCardType()
    {
        return _currentCardType;
    }
    
    // Populate Card
    public void PopulateCard(CardType cardType)
    {
        _currentCardType =  cardType;
        _imageCard.sprite = _currentCardType.cardFront;
        StartCoroutine(Initialize());
    }

    // Disable Card NOT DESTROYED!
    public void DisableCard()
    {
        this.gameObject.SetActive(false);
    }
    
    
}

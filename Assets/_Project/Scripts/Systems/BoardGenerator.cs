using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implementing the IGenerator As it is A generator Class
public class BoardGenerator : MonoBehaviour, IGenerator
{
    [Header("Injected Dependencies")]
    [Space]
    [Header("Events")]
    [SerializeField] private GameEvent _OnBoardGenerated;
    [Space]
    [Header("Variables")]
    [SerializeField] private CardListVariable _cardList;
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private IntVariable _currentLevel;
    [SerializeField] private float _cardPreferedSizeWidth;
    [SerializeField] private float _cardPreferedSizeHeight;
    [Space]
    [Header("GameObjects")]
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private RectTransform _tableRectTransform;
    
    // Private and NOT serialized variables
    private float _rows;
    private float _cols;
    private float _calculatedCardWidth;
    private float _calculatedCardHeight;
    private float _sizeWidth;
    private float _sizeHeight;
    private float _finalCardWidth;
    private float _finalCardHeight;
    

    void Start()
    {
        if (_currentLevel.value > _gameConfig.leveConfigs.Count - 1) return;
        
        // Initialize Variables
        Initialize();
        // Generate Cards
        Generate();
    }

    // First Initialize our variables 
    private void Initialize()
    {
        
        
        // Rows and cols according to current level Config
        _rows = _gameConfig.leveConfigs[_currentLevel.value].rows;
        _cols = _gameConfig.leveConfigs[_currentLevel.value].cols;
        
        // Clear List
        _cardList.Clear();
        
        // Calculate the ideal card width and height
        _calculatedCardWidth = _tableRectTransform.rect.width / _cols;
        _calculatedCardHeight = _tableRectTransform.rect.height / _rows;
        
        // Set Sizes the same as Cards
        _sizeWidth = _cardPreferedSizeWidth;
        _sizeHeight = _cardPreferedSizeHeight;
    }

    // Start Generating Cards
    public void Generate()
    {
        if ((_rows * _cols) % 2 != 0)
        {
            Debug.LogError("In order to create a card grid for a matching game, it needs to be EVEN number.");
            return;
        }
        
        // Check if the calculated Card width is less than 
        // the fixed Width Preferred size width we have set
        if (_calculatedCardWidth < _cardPreferedSizeWidth)
        {
            _finalCardWidth = _calculatedCardWidth;
            _sizeWidth = _calculatedCardWidth;
        }
        else
        {
            _finalCardWidth = _calculatedCardWidth;
            _sizeWidth = _cardPreferedSizeWidth;
        }
        
        // Check if the calculated Card height is less than 
        // the fixed Height Preferred size width we have set
        if (_calculatedCardHeight < _cardPreferedSizeHeight)
        {
            _finalCardHeight = _calculatedCardHeight;
            _sizeHeight = _calculatedCardHeight;
        }
        else
        {
            _finalCardHeight = _calculatedCardHeight;
            _sizeHeight = _cardPreferedSizeHeight;
        }

        
        List<GameObject> generatedCards = new List<GameObject>();
        
        // Create the Grid
        for (int row = 0; row < _rows; row++)
        {
            for (int col = 0; col < _cols; col++)
            {
                GameObject card = Instantiate(_cardPrefab, _tableRectTransform, false);
                RectTransform cardRect = card.GetComponent<RectTransform>();

                // Always set anchors of the created card to Upper Left
                cardRect.anchorMin = new Vector2(0, 1);
                cardRect.anchorMax = new Vector2(0, 1);
                cardRect.pivot = new Vector2(0, 1);

                // Set the Size of the created card
                cardRect.sizeDelta = new Vector2(_sizeWidth, _sizeHeight);

                // Calculate the position through Card sizes and Card Width|Height
                // And Divide by 2 to center it
                float posX = col * _finalCardWidth + (_finalCardWidth - _sizeWidth) / 2f;
                float posY = -row * _finalCardHeight - (_finalCardHeight - _sizeHeight) / 2f;

                // Finally set the Position of the cards
                cardRect.anchoredPosition = new Vector2(posX, posY);
                
                // Add them to the List 
                _cardList.Add(card);
            }
        }
        _OnBoardGenerated.Raise();
    }
}

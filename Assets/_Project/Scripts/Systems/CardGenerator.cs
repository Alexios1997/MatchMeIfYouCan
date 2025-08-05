using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Implementing the IGenerator As it is A generator Class
public class CardGenerator : MonoBehaviour, IGenerator
{
    [Header("Injected Dependencies")]
    [Space]
    [Header("Variables")]
    [SerializeField] private CardListVariable _cardList;
    [SerializeField] private IntVariable _currentLevel;
    [SerializeField] private GameConfig _gameConfig;
    [Space]
    [Header("Events")]
    [SerializeField] private GameEvent _OnCardsPopulated;

    // Private and NOT serialized variables
    private List<int> _uniqueCardTypesCounter = new List<int>();
    private int _pairs;
    
    // Start Making Pairs and populating cards
    public void Generate()
    {
       // Total pairs that you will need
       _pairs = _cardList.Cards.Count / 2;
       
       // Pairs should be the number of unique Ids you have in your card config Always 
       if (_pairs !=  _gameConfig.leveConfigs[_currentLevel.value]._uniqueCardTypes.Count)
       {
           Debug.LogError(" You cannot have more number of pairs than the unique Card Types");
           return;
       }

       // In this List Counter add Zeros 
       for (int i = 0; i < _gameConfig.leveConfigs[_currentLevel.value]._uniqueCardTypes.Count; i++)
       {
           _uniqueCardTypesCounter.Add(0);
       }

       // random number
       int rand;
       
       // For every Card now We need:
       // 1. To pick a random number and check through List Counter if it is more than 2 which means Pair for this has already been created
       // 2. Populate card if not 2
       for (int i = 0; i < _cardList.Cards.Count; i++)
       {
           while (true)
           {
               rand = Random.Range(0,_gameConfig.leveConfigs[_currentLevel.value]._uniqueCardTypes.Count);
               if (_uniqueCardTypesCounter[rand] < 2)
               {
                   _uniqueCardTypesCounter[rand]++;
                   break;
               }
           }
           _cardList.Cards[i].GetComponent<Card>().PopulateCard(_gameConfig.leveConfigs[_currentLevel.value]._uniqueCardTypes[rand]);
       }
       
       _OnCardsPopulated.Raise();
    }
}

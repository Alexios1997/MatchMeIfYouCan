using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour, IGenerator
{
    [Space]
    [Header("Values")]
    
    [SerializeField] private GameEvent _OnCardsPopulated;
    [SerializeField] private CardListVariable _cardList;
    [SerializeField] private CardConfig _cardConfig;


    private List<int> _uniqueCardTypesCounter = new List<int>();
    private int _pairs;
    public void Generate()
    {
       
       // Total pairs that you will need
       _pairs = _cardList.Cards.Count / 2;
       
       // Pairs should be the number of unique Ids you have in your card config Always 
       if (_pairs !=  _cardConfig._uniqueCardTypes.Count)
       {
           Debug.LogError(" You cannot have more number of pairs than the unique Card Types");
           return;
       }

       for (int i = 0; i < _cardConfig._uniqueCardTypes.Count; i++)
       {
           _uniqueCardTypesCounter.Add(0);
       }
       
       Debug.Log(_uniqueCardTypesCounter.Count);

       int rand;
       for (int i = 0; i < _cardList.Cards.Count; i++)
       {
           while (true)
           {
               rand = Random.Range(0,_cardConfig._uniqueCardTypes.Count);
               if (_uniqueCardTypesCounter[rand] < 2)
               {
                   _uniqueCardTypesCounter[rand]++;
                   break;
               }
           }
           _cardList.Cards[i].GetComponent<Card>().PopulateCard(_cardConfig._uniqueCardTypes[rand]);
       }
       
       _OnCardsPopulated.Raise();
    }
}

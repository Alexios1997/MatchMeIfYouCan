using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptables/Card Type")]
public class CardType : ScriptableObject
{
    public string name;
    public Sprite cardFront;
    public Sprite cardBack;
    public AudioClip flipSound;
}

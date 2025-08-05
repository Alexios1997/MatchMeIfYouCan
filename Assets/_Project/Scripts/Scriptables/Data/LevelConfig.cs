using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/Config/Level Config")]
public class LevelConfig : ScriptableObject
{
   public int rows;
   public int cols;
   public List<CardType> _uniqueCardTypes;
}

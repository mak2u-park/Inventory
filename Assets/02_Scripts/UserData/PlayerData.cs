using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int level;
    public int gold;
    public float strength;
    public float defense;
    public float health;
    public float critical;
    public List<string> equippedItemNames;
    
}

using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Weapon,
    Armor,
    Ring
}

public enum StatType
{
    strength,
    defense,
    health,
    critical
}

// Dictionary는 직렬화 불가능, list 형태로 저장
[System.Serializable]
public class StatEntry
{
    public StatType type;
    public int value;
}

public class ItemData : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite image;
    public ItemType itemType;
    public List<StatEntry> stats;
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public string playername;
    public int level;
    public int gold;

    public void Init(string name, int level, float strength, float defense, float health, float critical, int gold)
    {
        playername = name;
        this.level = level;
        this.strength = strength;
        this.defense = defense;
        this.health = health;
        this.critical = critical;
        this.gold = gold;
    }
}

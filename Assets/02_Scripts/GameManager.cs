using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Player Knight;
    public Player Dwarf;
    public Player Wizzard;

    public List<ItemData> allItemDatas; // 전체 아이템 데이터 리스트

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        // 모든 플레이어 데이터 적용
        List<PlayerData> playerDatas = LoadAllPlayerData();
        
        Knight.LoadData(LoadAllPlayerData()[0], allItemDatas);
        Dwarf.LoadData(LoadAllPlayerData()[1], allItemDatas);
        Wizzard.LoadData(LoadAllPlayerData()[2], allItemDatas);
    }

    
    public List<PlayerData> LoadAllPlayerData()
    {
        return new List<PlayerData>
        {
            new PlayerData { playerName = "Knight", level = 10, gold = 5000, strength = 30, defense = 20, health = 200, critical = 10, equippedItemNames = new List<string>{"Sword"} },
            new PlayerData { playerName = "Dwarf", level = 10, gold = 2000, strength = 40, defense = 25, health = 120, critical = 20, equippedItemNames = new List<string>{"Axe"} },
            new PlayerData { playerName = "Wizzard", level = 10, gold = 500, strength = 10, defense = 20, health = 80, critical = 50, equippedItemNames = new List<string>{"Staff"} }
        };
    }
    
}

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
        // 전체 아이템 리스트에 Resources 폴더를 이용해 전부 추가하기
        ItemData[] items = Resources.LoadAll<ItemData>("ScriptableObjects");
        allItemDatas.AddRange(items);
        
        Knight.LoadData(LoadAllPlayerData()[0], allItemDatas);
        Dwarf.LoadData(LoadAllPlayerData()[1], allItemDatas);
        Wizzard.LoadData(LoadAllPlayerData()[2], allItemDatas);
    }

    
    public List<PlayerData> LoadAllPlayerData()
    {
        return new List<PlayerData>
        {
            new PlayerData { playerName = "Knight", level = 10, gold = 5000, strength = 45, defense = 20, health = 200, critical = 10, equippedItemNames = new List<string>{"Sword"} },
            new PlayerData { playerName = "Dwarf", level = 15, gold = 10000, strength = 50, defense = 25, health = 120, critical = 20, equippedItemNames = new List<string>{"Axe"} },
            new PlayerData { playerName = "Wizzard", level = 8, gold = 500, strength = 30, defense = 20, health = 80, critical = 60, equippedItemNames = new List<string>{"Staff"} }
        };
    }
    
}

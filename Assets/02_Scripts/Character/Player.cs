using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Character
{
    public string playerName;
    public int level;
    public int gold;
    
    // player 인스턴스에 데이터를 적용, 불러오기 기능
    public void LoadData(PlayerData data, List<ItemData> allItemDatas)
    {
        // 변수 명이 같아 구분하기 위해 this 작성
        this.playerName = data.playerName;
        this.level = data.level;
        this.gold = data.gold;
        this.strength = data.strength;
        this.defense = data.defense;
        this.health = data.health;
        this.critical = data.critical;
        this.equippedItems.Clear();

        foreach (var name in data.equippedItemNames)
        {
            // 불러오기를 진행할 경우, 아이템의 이름으로는 ItemData ScriptableObject를 만들 수 없다.
            // 따라서 게임 내에 존재하는 모든 ItemData 리스트에서 해당 이름을 가진 아이템을 찾아와
            // equippedItems에 직접 추가
            ItemData item = allItemDatas.Find(x => x.itemName == name);
            if (item != null)
                equippedItems.Add(item);
        }
    }
    
    // player 인스턴스의 현재 정보를 PlayerData로 변환, 저장 기능
    public PlayerData SaveData()
    {
        // lInQ를 활용해 아이템 이름만을 추출
        List<string> equippedItemNames = equippedItems.Select(item 
            => item.itemName).ToList();
        
        return new PlayerData
        {
            playerName = playerName,
            level = level,
            gold = gold,
            strength = strength,
            defense = defense,
            health = health,
            critical = critical,
            equippedItemNames = equippedItemNames
        };
    }
}

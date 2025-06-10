using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<ItemData> equippedItems = new List<ItemData>(); // 장착된 아이템 목록
    
    public bool IsEquipped(ItemData item) => equippedItems.Contains(item);

    public float strength { get; protected set; } = 35f;
    public float defense { get; protected set; } = 40f;
    public float health { get; protected set; } = 100f;
    public float critical { get; protected set; } = 25f;

    
    
    
    // 아이템 장착 시 모든 스텟 적용
    public void EquipItem(ItemData item)
    {
        if (!equippedItems.Contains(item))
        {
            // 장착 리스트에 추가
            equippedItems.Add(item);
            
            foreach (var stat in item.stats)
            {
                switch (stat.type)
                {
                    case StatType.strength:
                        strength += stat.value;
                        break;
                    case StatType.defense:
                        defense += stat.value;
                        break;
                    case StatType.health:
                        health += stat.value;
                        break;
                    case StatType.critical:
                        critical += stat.value;
                        break;
                }
            }
        }
        

        // UIManager.instance._uiStatus.UpdateStatusUI();
    }
    
    // 아이템 해제 시 모든 스탯 제거
    public void UnequipItem(ItemData item)
    {
        if (equippedItems.Contains(item))
        {
            // 장착 리스트에서 제거
            equippedItems.Remove(item);
            
            foreach (var stat in item.stats)
            {
                switch (stat.type)
                {
                    case StatType.strength:
                        strength -= stat.value;
                        break;
                    case StatType.defense:
                        defense -= stat.value;
                        break;
                    case StatType.health:
                        health -= stat.value;
                        break;
                    case StatType.critical:
                        critical -= stat.value;
                        break;
                }
            }
        }
        
        
        // UIManager.instance._uiStatus.UpdateStatusUI();
    }
}

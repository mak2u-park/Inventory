using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button _statusButton;
    [SerializeField] private Button _inventoryButton;
    
    

    public void OnInventoryUI()
    {
        UIManager.instance._uiInventory.gameObject.SetActive(true);
    }

    public void OnStatusUI()
    {
        UIManager.instance._uiStatus.gameObject.SetActive(true);
        UIManager.instance._uiStatus.UpdateStatusUI();
    }
}

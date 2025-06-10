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
        bool isActive = UIManager.instance._uiInventory.gameObject.activeSelf;
        UIManager.instance._uiInventory.gameObject.SetActive(!isActive);
        if (!isActive)
        {
            UIManager.instance._uiInventory.RefreshUI();
        }
    }

    public void OnStatusUI()
    {
        bool isActive = UIManager.instance._uiStatus.gameObject.activeSelf;
        UIManager.instance._uiStatus.gameObject.SetActive(!isActive);
        if (!isActive)
        {
            UIManager.instance._uiStatus.UpdateStatusUI();
        }
    }

    
}

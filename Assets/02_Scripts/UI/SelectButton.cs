using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    public Player _player;
    [SerializeField] private GameObject _mainUI;
    
    public void TakePlayerData()
    {
        UIManager.instance._player = _player;
        _mainUI.SetActive(true);
        UIManager.instance.UpdateUI();                  // UIMainMenu 업데이트
        UIManager.instance._uiStatus.UpdateStatusUI();  // UIStatus 업데이트
        UIManager.instance._uiInventory.RefreshUI();    // UIInventory 업데이트
    }
}

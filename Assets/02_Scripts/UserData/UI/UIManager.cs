using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    public UIMainMenu _uiMainMenu;
    public UIInventory _uiInventory;
    public UIStatus _uiStatus;
    public Character _character;

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
        _uiMainMenu = GetComponentInChildren<UIMainMenu>(true);
        _uiInventory = GetComponentInChildren<UIInventory>(true);
        _uiStatus = GetComponentInChildren<UIStatus>(true);
    }

}

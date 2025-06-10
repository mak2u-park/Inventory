using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    public UIMainMenu _uiMainMenu;
    public UIInventory _uiInventory;
    public UIStatus _uiStatus;
    public Player _player;
    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _gold;

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

    public void UpdateUI()
    {
        _playerName.text = _player.playerName;
        _level.text = _player.level.ToString();
        _gold.text = _player.gold.ToString();
    }

}

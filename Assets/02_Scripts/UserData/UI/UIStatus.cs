using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _strength;
    [SerializeField] private TextMeshProUGUI _defense;
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _critical;
    [SerializeField] private Button _backButton;
    
    public Character character;

    public void Start()
    {
        UpdateStatusUI();
    }
    
    public void UpdateStatusUI()
    {
        character = UIManager.instance._character;
        _strength.text = character.strength.ToString();
        _defense.text = character.defense.ToString();
        _health.text = character.health.ToString();
        _critical.text = character.critical.ToString();
    }

    public void OnBackButton()
    {
        UpdateStatusUI();
        this.gameObject.SetActive(false);
    }
}

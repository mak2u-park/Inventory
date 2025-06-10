using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private UIInventory _uiInventory;
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private Outline _outline;
    [SerializeField] private TextMeshProUGUI _equip;
    [SerializeField] private int _index;
    
    public ItemData data;
    public Player player;
    public bool isEquipped = false;

    private void Start()
    {
        _uiManager = UIManager.instance;
        _uiInventory = UIManager.instance._uiInventory;
        _uiInventory._tooltipUI.gameObject.SetActive(false);
        player = _uiInventory.player;
    }
    private void Update()
    {
        // 마우스 위치에 맞춰 툴팁 위치 조정
        if (_uiInventory._tooltipUI.activeSelf)
        {
            Vector2 mousePos = Input.mousePosition;
            _uiInventory._tooltipUI.transform.position = mousePos + Vector2.left + Vector2.up;
        }
        
    }
    
    public void Set()
    {
        if (data == null)
        {
            Clear();
        }
        else
        {
            _image.gameObject.SetActive(true);
            _image.sprite = data.image;
            _equip.gameObject.SetActive(isEquipped);
        }
    }
    
    public void Clear()
    {
        data = null;
        _image.gameObject.SetActive(false);
        UIManager.instance._uiInventory._itemName.text = "";
        UIManager.instance._uiInventory._itemDescription.text = "";
    }
    
    public void OnClickButton()
    {
        // 현재 슬롯을 선택된 슬롯으로 설정
        _uiInventory.selectedSlot = this; 
        _uiInventory.UpdateOutlines();
        
        // 슬롯 클릭시 장착 또는 해제 버튼을 생성
        _uiInventory.UpdateEquipControllButton();
    }
    
    // 마우스를 갖다 대면 툴팁 활성화
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.instance._uiInventory._itemName.text = data.itemName;
        UIManager.instance._uiInventory._itemDescription.text = data.itemDescription;
        _uiInventory._tooltipUI.SetActive(true);
    }
    
    // 마우스를 떼면 툴팁 비활성화
    public void OnPointerExit(PointerEventData eventData)
    {
        _uiInventory._tooltipUI.SetActive(false);
    }
    
    // 아이템 장착 / 해체
    public void EquipItem()
    {
        player.EquipItem(data);
        // isEquipped = !isEquipped;
        Debug.Log(isEquipped);
        _equip.gameObject.SetActive(isEquipped);
    }

    public void UnequipItem()
    {
        player.UnequipItem(data);
        isEquipped = !isEquipped;
        _equip.gameObject.SetActive(isEquipped);
    }
    
    // 아웃라인 활성화 / 비활성화
    public void ActiveOutline(bool isActive)
    {
        if (_outline != null)
            _outline.enabled = isActive;
    }
}

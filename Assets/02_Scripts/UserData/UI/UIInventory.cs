using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public GameObject _tooltipUI;
    public TextMeshProUGUI _itemName;
    public TextMeshProUGUI _itemDescription;
    public Player player;
    public Button _equipButton;
    public Button _unequipButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private GameObject _slotPrefabs;
    [SerializeField] private Transform _slotsParent;
    
    [Header("Selected Item")]
    public InventorySlot selectedSlot;
    
    private List<InventorySlot> _slots = new List<InventorySlot>();
    [SerializeField] private List<ItemData> _itemList = new List<ItemData>();
    
    private void Start()
    {
        player = UIManager.instance._player;
        RefreshUI();
    }

    public void AddItem(ItemData data)
    {
        _itemList.Add(data);
        RefreshUI();
    }

    public void RemoveItem(ItemData data)
    {
        _itemList.Remove(data);
        RefreshUI();
    }

    public void RefreshUI()
    {
        player = UIManager.instance._player;
        
        // 이전에 선택된 아이템 기억 (존재한다면)
        ItemData prevSelectedData = selectedSlot != null ? selectedSlot.data : null;
        
        // 슬롯 초기화
        foreach (var slot in _slots)
        {
            Destroy(slot.gameObject);
        }
        _slots.Clear();
        selectedSlot = null;

        // 필요한 만큼 슬롯 생성
        for (int i = 0; i < _itemList.Count; i++)
        {
            GameObject newSlotObj = Instantiate(_slotPrefabs, _slotsParent);
            InventorySlot newSlot = newSlotObj.GetComponent<InventorySlot>();
            newSlot.data = _itemList[i];
            newSlot.isEquipped = player.IsEquipped(newSlot.data);
            newSlot.Set();
            
            // 이전에 선택했던 아이템이면 selectedSlot으로 다시 지정
            if (prevSelectedData != null && newSlot.data == prevSelectedData)
            {
                selectedSlot = newSlot;
            }

            _slots.Add(newSlot);
        }

        UpdateOutlines();
    }

    public void UpdateOutlines()
    {
        // selectedSlot이 아닌 경우 OutLine 전부 비활성화
        foreach (var slot in _slots)
        {
            slot.ActiveOutline(slot == selectedSlot);
        }
            
    }
    
    // 뒤로가기 버튼
    public void OnBackButton()
    {
        selectedSlot = null;
        RefreshUI();
        this.gameObject.SetActive(false);
    }

    // 장착 / 장착 해제 컨트롤 버튼
    public void EquipControllButton()
    {
        if (selectedSlot != null)
        {
            if (!selectedSlot.isEquipped)
            {
                selectedSlot.EquipItem();
            }
            else
            {
                selectedSlot.UnequipItem();
            }
            RefreshUI(); 
            UpdateEquipControllButton();
        }
    }
    
    // 버튼 상태 갱신 ( 장착 시 / 해제 시 ) 
    public void UpdateEquipControllButton()
    {
        if (selectedSlot != null)
        {
            _equipButton.gameObject.SetActive(!selectedSlot.isEquipped);
            _unequipButton.gameObject.SetActive(selectedSlot.isEquipped);
        }
        else
        {
            _equipButton.gameObject.SetActive(false);
            _unequipButton.gameObject.SetActive(false);
        }
    }
    
    
}

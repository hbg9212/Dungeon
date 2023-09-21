using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ItemSlot
{
    public EquipItem equipItem;
    public bool equip;
}

public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlots;
    public ItemSlot[] slots;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public GameObject equipButton;
    public GameObject unEquipButton;

    private int curEquipIndex;

    [Header("Events")]
    public UnityEvent onOpenInventory;
    public UnityEvent onCloseInventory;

    public static Inventory instance;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        slots = new ItemSlot[uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }

        ClearSeletecItemWindow();
    }

    public void AddItem(EquipItem item)
    {

        ItemSlot emptySlot = GetEmptySlot();
        if (emptySlot != null)
        {
            emptySlot.equipItem = item;
            UpdateUI();
            return;
        }

    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].equipItem != null)
                uiSlots[i].Set(slots[i]);
            else
                uiSlots[i].Clear();
        }
    }

    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].equipItem == null)
                return slots[i];
        }

        return null;
    }

    public void SelectItem(int index)
    {
        if (slots[index].equipItem == null)
            return;

        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.equipItem.displayName;

        string str = "";
        str = selectedItem.equipItem.description + "\n";
        for (int i = 0; i < selectedItem.equipItem.stats.Length; i++)
        {
            str += selectedItem.equipItem.stats[i].type.ToString();
            str += selectedItem.equipItem.stats[i].value.ToString() + "\n";
        }
        selectedItemDescription.text = str;

        equipButton.SetActive(!uiSlots[index].equipped);
        unEquipButton.SetActive(uiSlots[index].equipped);

    }

    private void ClearSeletecItemWindow()
    {
        selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
    }


    public void OnEquipButton()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(slots[i].equipItem != null)
            {

                if (slots[i].equipItem.type == slots[selectedItemIndex].equipItem.type)
                {
                    slots[i].equip = false;
                    uiSlots[i].equipped = false;
                }

            }

        }
        slots[selectedItemIndex].equip = true;
        uiSlots[selectedItemIndex].equipped = true;

        EquipManager.instance.EquipNew(selectedItem.equipItem);
        UpdateUI();

        SelectItem(selectedItemIndex);
    }

    void UnEquip(int index)
    {
        slots[index].equip = false;
        uiSlots[index].equipped = false;
        EquipManager.instance.UnEquip((int)selectedItem.equipItem.type);
        UpdateUI();

        if (selectedItemIndex == index)
            SelectItem(index);
    }

    public void OnUnEquipButton()
    {
        UnEquip(selectedItemIndex);
    }

}
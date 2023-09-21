using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public TextMeshProUGUI textMeshPro;
    private ItemSlot curSlot;
    private Outline outline;

    public int index;
    public bool equipped;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }


    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.equipItem.icon;
        if(outline != null)
        {
            outline.enabled = slot.equip;
            textMeshPro.enabled = slot.equip;
        }

    }

    public void Clear()
    {
        curSlot = null;
        icon.gameObject.SetActive(false);
        textMeshPro.enabled = false;
    }

    public void OnButtonClick()
    {
        Inventory.instance.SelectItem(index);
    }
}
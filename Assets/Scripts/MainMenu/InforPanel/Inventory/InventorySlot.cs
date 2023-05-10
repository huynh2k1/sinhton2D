using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Image image;
    [SerializeField] Text nameItem;
    [SerializeField] Text atkText;
    [SerializeField] Text hpText;
    public event Action<BaseItem> OnLeftClickEvent;
    private BaseItem _item;
    public BaseItem Item{
        get{return _item;}
        set{
            _item = value;
            if(_item == null)
            {
                image.enabled = false;
                nameItem.enabled = false;
                atkText.enabled = false;
                hpText.enabled = false;
                
            }
            else{
                image.sprite = _item.itemImage;
                image.enabled = true;
                nameItem.text = _item.itemName;
                nameItem.enabled = true;
                atkText.text = "ATK + " + _item.AttackBonus.ToString();
                atkText.enabled = true;
                hpText.text = "HP + " + _item.HealthBonus.ToString();
                hpText.enabled = true;

            }
        }
    }
    protected virtual void OnValidate() {
        if(image == null)
        {
            image = GetComponent<Image>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if(Item != null && OnLeftClickEvent != null)
            {
                OnLeftClickEvent(Item);
            }
        }
    }
}

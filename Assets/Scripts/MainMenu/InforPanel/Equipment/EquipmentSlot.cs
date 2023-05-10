using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{
    public ItemType ItemType;
    public Image image;
    public event Action<BaseItem> OnLeftClickEvent;
    private BaseItem _item;
    public BaseItem Item{
        get{return _item;}
        set{
            _item = value;
            if(_item == null)
            {
                image.enabled = false;
                
            }
            else{
                image.sprite = _item.itemImage;
                image.enabled = true;

            }
        }
    }
    private void OnValidate() {
        if(image == null)
        {
            image = GetComponent<Image>();
        }
        gameObject.name = ItemType.ToString() + "Slot";
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

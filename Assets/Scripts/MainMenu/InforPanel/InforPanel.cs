using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InforPanel : MonoBehaviour
{
    public static InforPanel Instance;
    public Inventory inventory;
    public Equipment equipment;
    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }

        inventory.OnItemLeftClickedEvent += EquipFromInventory;
        equipment.OnItemLeftClickedEvent += UnEquipFromEquipment;
    }
    private void EquipFromInventory(BaseItem item)
    {
        if(item is BaseItem)
        {
            Equip((BaseItem)item);
        }
    }
    private void UnEquipFromEquipment(BaseItem item)
    {
        if(item is BaseItem)
        {
            UnEquip((BaseItem)item);
        }
    }
    private void Equip(BaseItem item)
    {
        if(inventory.RemoveItem(item))
        {
            BaseItem preItem;
            if(equipment.AddItem(item, out preItem))
            {
                if(preItem != null)
                {
                    inventory.AddItem(preItem);
                }
            }
            else{
                inventory.AddItem(item);
            }
        }
    }
    private void UnEquip(BaseItem item)
    {
        if(!inventory.IsFull() && equipment.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }
}

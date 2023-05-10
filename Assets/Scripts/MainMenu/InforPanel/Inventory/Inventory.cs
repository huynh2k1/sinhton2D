using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public ListItemInventory listItemInventories;
    public Transform inventoryParent;
    public InventorySlot[] inventorySlots;
    public event Action<BaseItem> OnItemLeftClickedEvent;

    private void Awake() {
        instance = this;
    }
    private void Start() {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].OnLeftClickEvent += OnItemLeftClickedEvent;
        }
        RefreshUI();
    }
    private void OnEnable() {
        RefreshUI();
    }
    private void OnValidate() {
        if(inventoryParent != null)
        {
            inventorySlots = inventoryParent.GetComponentsInChildren<InventorySlot>();

        }
        RefreshUI();
    }
    public void RefreshUI(){
        int i = 0;
        for(; i < listItemInventories.inventoryList.Count && i < inventorySlots.Length; i++)
        {
            inventorySlots[i].Item = listItemInventories.inventoryList[i];
        }
        for(; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].Item = null;
        }
    }
    public bool IsFull()
    {
        return listItemInventories.inventoryList.Count >= inventorySlots.Length;
    }
    public bool AddItem(BaseItem item)
    {
        if(IsFull())
        {
            return false;
        }
        listItemInventories.inventoryList.Add(item);
        RefreshUI();
        return true;
    }
    public bool RemoveItem(BaseItem item)
    {
        if(listItemInventories.inventoryList.Remove(item))
        {
            RefreshUI();
            return true;
        }
        return false;
    }
}

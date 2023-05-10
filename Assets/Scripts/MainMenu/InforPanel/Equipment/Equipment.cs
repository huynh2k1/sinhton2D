using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Equipment : MonoBehaviour
{
    public ListItemEquipment listItemEquipment;
    public Transform equipmentParent;
    public EquipmentSlot[] equipmentSlots;
    public Text atkText;
    public Text hpText;

    public event Action<BaseItem> OnItemLeftClickedEvent;
    private void Start()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnLeftClickEvent += OnItemLeftClickedEvent;
        }
    }

    private void OnValidate(){
        if(equipmentParent != null)
        {
            equipmentSlots = equipmentParent.GetComponentsInChildren<EquipmentSlot>();
        }
        RefreshUI();
    }
    //Làm mới giao diện trang bị
    private void RefreshUI(){
        for(int i = 0; i < equipmentSlots.Length; i++)
        {
            if(listItemEquipment.equipmentList.Count > 0)
            {
                for(int j = 0; j < listItemEquipment.equipmentList.Count; j++)
                {
                    if(equipmentSlots[i].ItemType == listItemEquipment.equipmentList[j].ItemType)
                    {
                        equipmentSlots[i].Item = listItemEquipment.equipmentList[j];
                        break;
                    }
                    else{
                        equipmentSlots[i].Item = null;
                    }
                }
            }
            else{
                equipmentSlots[i].Item = null;
            }
        }
        RefreshStat();
    }
    //Làm mới chỉ số
    private void RefreshStat(){
        Prefs.Attack = 5;
        Prefs.Health = 20;
        foreach(BaseItem item in listItemEquipment.equipmentList)
        {
            Prefs.Attack += item.AttackBonus;
            Prefs.Health += item.HealthBonus;
        }
        UpdateStat();
    }
    public void UpdateStat()
    {
        atkText.text = "ATK: " + Prefs.Attack.ToString();
        hpText.text = "HP: " + Prefs.Health.ToString();
    }
    //Gắn trang bị
    public bool AddItem(BaseItem newItem, out BaseItem preItem)
    {
        for(int i = 0; i < equipmentSlots.Length; i++)
        {
            if(equipmentSlots[i].ItemType == newItem.ItemType)
            {
                preItem = equipmentSlots[i].Item;
                listItemEquipment.equipmentList.Remove(preItem);

                equipmentSlots[i].Item = newItem;
                listItemEquipment.equipmentList.Add(newItem);

                RefreshStat();
                return true;
            }
        }
        RefreshUI();
        preItem = null;
        return false;
    }
    //Gỡ trang bị
    public bool RemoveItem(BaseItem item){
        for(int i = 0; i < equipmentSlots.Length; i++)
        {
            if(equipmentSlots[i].Item == item)
            {
                equipmentSlots[i].Item = null;
                listItemEquipment.equipmentList.Remove(item);

                RefreshStat();
                return true;
            }
        }
        return false;
    }
}

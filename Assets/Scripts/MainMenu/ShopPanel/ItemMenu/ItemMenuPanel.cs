using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemMenuPanel : MonoBehaviour
{
    public static ItemMenuPanel instance;
    public ListItemInventory _shopItemList;
    public ListItemInventory _inventoryList;
    public Transform itemsParent;
    public ShopSlot[] shopSlots;
    public Text notificationText;
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void OnValidate(){
        if(shopSlots != null)
        {
            shopSlots = itemsParent.GetComponentsInChildren<ShopSlot>();
        }
        RefreshUI();
    }
    private void Start() {
        notificationText.enabled = false;
        
    }
    private void RefreshUI()
    {
        int i = 0;
        for(; i < _shopItemList.inventoryList.Count && i < shopSlots.Length; i++)
        {
            shopSlots[i].Item = _shopItemList.inventoryList[i];
        }
        for(; i < shopSlots.Length; i++)
        {
            shopSlots[i].Item = null;
        }
    }
    
    
    public void OnClick(int index){
        for(int i = 0; i < _shopItemList.inventoryList.Count; i++) {
            if(i == index && Prefs.Gold >= _shopItemList.inventoryList[i].Price)
            {
                Prefs.Gold -= _shopItemList.inventoryList[i].Price; //trừ gold khi mua item
                _inventoryList.inventoryList.Add(_shopItemList.inventoryList[i]); // thêm item vào túi
                UIHomeManager.instance.UpdateGold();
                StartCoroutine(Success());
            }
            else if(i == index && Prefs.Gold < _shopItemList.inventoryList[i].Price){
                StartCoroutine(Failed());
            }
        }
    }
    IEnumerator Success(){
        notificationText.text = "Mua thành công!!!";
        notificationText.color = Color.red;
        notificationText.enabled = true;
        yield return new WaitForSeconds(0.8f);
        notificationText.enabled = false;
    }
    IEnumerator Failed(){
        notificationText.text = "Không đủ vàng!!!";
        notificationText.color = Color.grey;
        notificationText.enabled = true;
        yield return new WaitForSeconds(0.8f);
        notificationText.enabled = false;
    }
}

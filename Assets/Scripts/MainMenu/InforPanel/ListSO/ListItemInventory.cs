using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "InventoryList", menuName = "ListSO/InventoryList")]
public class ListItemInventory : ScriptableObject
{
    public List<BaseItem> inventoryList;
}

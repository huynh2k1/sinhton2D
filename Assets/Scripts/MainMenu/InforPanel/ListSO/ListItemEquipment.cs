using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EquipmentList", menuName = "ListSO/EquipmentList")]
public class ListItemEquipment : ScriptableObject
{
    public List<BaseItem> equipmentList;
}

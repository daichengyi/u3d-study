using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 数据资源文件*/
[CreateAssetMenu(fileName = "ItemDataList_SO", menuName = "Inventory/ItemDataList")]
public class ItemDataList_SO : ScriptableObject
{
    public List<ItemDetails> itemDetailsList;
}

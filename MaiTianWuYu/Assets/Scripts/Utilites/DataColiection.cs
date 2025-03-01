using UnityEngine;

//序列化
[System.Serializable]
public class ItemDetails
{
    public int itemID;
    public string itemName;
    public ItemType itemType;
    public Sprite itemIcon;
    public Sprite itemOnWorldSprite;//世界地图产生时用
    public string itemDescription;//详情

    public int itemUseRadius;
    public bool canPickedup;//可拾取
    public bool canDropped;//可丢弃
    public bool canCarried;//可携带

    public int itemPrice;//价格
    [Range(0, 1)]
    public float sellPercentage;//出售百分比

}

/** 
 *结构体
 * struct 和 class 的区别： class需要判断数据为空，struct只需要关心id是否为0
*/
[System.Serializable]
public struct InventoryItem
{
    public int itemID;

    public int itemAmount;
}
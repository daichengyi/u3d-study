using UnityEngine;

[System.Serializable]//序列化
public class ItemDetails {
    public int itemID;
    public string name;
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
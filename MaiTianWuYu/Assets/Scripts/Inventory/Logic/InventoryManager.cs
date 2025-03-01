using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFarm.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        [Header("物品数据")]
        public ItemDataList_SO itemDataList_SO;
        [Header("背包数据")]
        public InventoryBag_SO playerBag;

        public ItemDetails GetItemDetails(int itemID)
        {
            return itemDataList_SO.itemDetailsList.Find(i => i.itemID == itemID);
        }


        /// <summary>
        /// 添加物品到背包
        /// </summary>
        /// <param name="item"></param>
        /// <param name="toDestroy"></param>
        public void AddItem(Item item, bool toDestroy)
        {
            InventoryItem newItem = new InventoryItem();
            newItem.itemID = item.itemID;
            newItem.itemAmount = 1;

            playerBag.itemList[0] = newItem;

            Debug.Log(string.Format("获得物品{0}", item.itemID));
            if (toDestroy)
            {
                Destroy(item.gameObject);
            }
        }
    }

}
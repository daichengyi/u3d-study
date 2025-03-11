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

        private void Start()
        {
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
        }

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
            int index = GetItemIndexInBag(item.itemID);
            AddItemAtIndex(item.itemID, index, 1);

            Debug.Log(string.Format("获得物品{0}", item.itemID));
            if (toDestroy)
            {
                Destroy(item.gameObject);
            }

            //更新UI
            EventHandler.CallUpdateInventoryUI(InventoryLocation.Player, playerBag.itemList);
        }

        private int GetItemIndexInBag(int ID)
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemID == ID)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 检查背包容量
        /// </summary>
        /// <returns></returns>
        private bool CheckBagCapacity()
        {
            for (int i = 0; i < playerBag.itemList.Count; i++)
            {
                if (playerBag.itemList[i].itemID == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 指定位置添加物品
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="index"></param>
        /// <param name="amount"></param>
        private void AddItemAtIndex(int ID, int index, int amount)
        {
            if (index == -1 && CheckBagCapacity())
            {
                InventoryItem item = new() { itemID = ID, itemAmount = amount };
                for (int i = 0; i < playerBag.itemList.Count; i++)
                {
                    if (playerBag.itemList[i].itemID == 0)
                    {
                        playerBag.itemList[i] = item;
                        break;
                    }
                }
            }
            else
            {
                int currentAmount = playerBag.itemList[index].itemAmount + amount;
                InventoryItem item = new() { itemID = ID, itemAmount = currentAmount };
                playerBag.itemList[index] = item;
            }
        }
    }

}
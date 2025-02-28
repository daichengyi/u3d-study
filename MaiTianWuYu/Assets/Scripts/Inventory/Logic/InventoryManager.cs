using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFarm.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        public ItemDataList_SO itemDataList_SO;

        public ItemDetails GetItemDetails(int itemID)
        {
            return itemDataList_SO.itemDetailsList.Find(i => i.itemID == itemID);
        }

        
        public void AddItem(Item item, bool toDestroy)
        {
            Debug.Log(string.Format("获得物品{0}",item.itemID));
            if (toDestroy) { 
                Destroy(item.gameObject);
            }
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFarm.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        public ItemDataList_SO itemDataList_SO;

        public ItemDetails GetItemDetails(int itemID){
            return itemDataList_SO.itemDetailsList.Find(i => i.itemID == itemID);
        }
    }
    
}
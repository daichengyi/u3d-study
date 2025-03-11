using System;
using System.Collections.Generic;
public static class EventHandler
{
    /** 注册事件*/
    public static event Action<InventoryLocation, List<InventoryItem>> UpdateInventoryUI;

    /** 调用事件*/
    public static void CallUpdateInventoryUI(InventoryLocation location, List<InventoryItem> list)
    {
        UpdateInventoryUI?.Invoke(location, list);
    }
}

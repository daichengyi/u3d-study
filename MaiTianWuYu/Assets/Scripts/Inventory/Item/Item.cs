using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFarm.Inventory
{
    public class Item : MonoBehaviour
    {
        public int itemID;

        private SpriteRenderer spriteRenderer;
        private BoxCollider2D coll;
        private ItemDetails itemDetails;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            coll = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            if (itemID != 0)
            {
                Init(itemID);
            }
        }

        public void Init(int ID)
        {
            itemID = ID;
            //InventoryManager 获得当前数据
            itemDetails = InventoryManager.Instance.GetItemDetails(itemID);
            if (itemDetails != null)
            {
                spriteRenderer.sprite = !itemDetails.itemOnWorldSprite ? itemDetails.itemOnWorldSprite : itemDetails.itemIcon;

                //碰撞区域 动态适配物品尺寸
                Vector2 newSize = new Vector2(spriteRenderer.sprite.bounds.size.x, spriteRenderer.sprite.bounds.size.y);
                coll.size = newSize;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFarm.Inventory
{
    public class Item : MonoBehaviour
    {
        public int itemID;

        private SpriteRenderer spriteRenderer;
        private ItemDetails itemDetails;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start(){
            if(itemID != 0){
                Init(itemID);
            }
        }

        public void Init(int ID){
            itemID = ID;

            itemDetails = InventoryManager.Instance.GetItemDetails(itemID);
            if(itemDetails != null){
                spriteRenderer.sprite = itemDetails.itemOnWorldSprite  !=null ?itemDetails.itemOnWorldSprite:itemDetails.itemIcon;
            }
        }
    }
    
}

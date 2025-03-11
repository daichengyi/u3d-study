using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [Header("组件获取")]
    [SerializeField] private Image slotImage;
    [SerializeField] private TextMeshProUGUI amountText;
    [SerializeField] private Image slotHightlight;
    [SerializeField] private Button button;
    [Header("格子类型")]
    public SlotType slotType;

    public bool isSelected;

    public int slotIndex;

    //物品信息
    public ItemDetails itemDetails;
    public int itemAmount;

    private void Start()
    {
        isSelected = false;
        if (itemDetails.itemID == 0)
        {
            UpdateEmptySlot();
        }
    }

    /// <summary>
    /// 更新格子UI和信息
    /// </summary>
    /// <param name="item"></param>
    /// <param name="amount"></param>
    public void UpdateSlot(ItemDetails item, int amount)
    {
        itemDetails = item;
        itemAmount = amount;
        slotImage.enabled = true;
        slotImage.sprite = item.itemIcon;
        amountText.text = amount.ToString();
        button.interactable = true;
    }

    public void UpdateEmptySlot()
    {
        if (isSelected)
        {
            isSelected = false;
        }
        slotImage.enabled = false;
        amountText.text = string.Empty;
        button.interactable = false;
    }
}

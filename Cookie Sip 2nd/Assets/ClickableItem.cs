using UnityEngine;

public enum ClickItemType {Pastry, Drink}

public class ClickableItem : MonoBehaviour
{
   public ClickItemType type;

    [Tooltip("Use the same strings Orderlist expects, e.g. 'cookie', 'chai latte'.")]
    public string itemName;

    public void Click(Orderlist orderlist)
    {
        if (orderlist == null) return;
        
        if (type == ClickItemType.Drink)
            orderlist.ShowOrder(itemName, "");
        else
            orderlist.ShowOrder("", itemName);
    }
}


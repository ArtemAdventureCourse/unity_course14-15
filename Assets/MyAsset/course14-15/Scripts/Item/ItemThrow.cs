using UnityEngine;

public class ItemThrow : Item
{
    protected override void ThrowItem(Item item)
    {
        _itemCollector.Collection.Clear();
        transform.SetParent(null);
        _itemCollector.ThrowItemWithForce(item);
        _timer.StartDestroyTime = true;
        _itemCollector.Collection.Remove(item);
        Debug.Log(base.InfoItem());
        Debug.Log(InfoItem());
    }

    protected override string InfoItem() => "брошен";

    protected override void ItemDelete(Item item)
    {
        Debug.Log($"{item.gameObject.name} исчезает!");
        item.gameObject.SetActive(false);
        _timer.Reset();
    }

}

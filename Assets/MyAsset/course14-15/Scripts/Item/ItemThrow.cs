using UnityEngine;

public class ItemThrow : Item
{
    protected override void ThrowItem()
    {
        _itemCollector.Collection.Clear();
        transform.SetParent(null);
        _itemCollector.ThrowItemWithForce();
        _timer.StartDestroyTime = true;
        //_itemCollector.Collection.Remove(item);
        Debug.Log(base.InfoItem());
        Debug.Log(InfoItem());
    }

    protected override string InfoItem() => "брошен";

    protected override void ItemDelete()
    {
        Debug.Log($"{gameObject.name} исчезает!");
        gameObject.SetActive(false);
        _timer.Reset();
    }

}

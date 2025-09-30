using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected ItemCollector _itemCollector;
    [SerializeField] protected Timer _timer;

    public bool IsReadyItemClear=false;
    

    protected virtual void DoEffect(Player player) { }

    public void Use(Player player) => DoEffect(player);

    protected virtual void ThrowItem() { }

    public void Throw() => ThrowItem();

    public void Delete() => ItemDelete();

    protected virtual void ItemDelete() { }

    protected virtual void ItemDestroy() { }

    protected virtual string InfoItem() => "предмет:";

}

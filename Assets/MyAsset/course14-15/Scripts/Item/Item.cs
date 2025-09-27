using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected ItemCollector _itemCollector;
    [SerializeField] protected Timer _timer;
    protected float _increaseSpeed = 0.2f;
    protected int _increaseHealth = 2;

    protected virtual void DoEffect(Player player) { }

    public void Use(Player player) => DoEffect(player);

    protected virtual void ThrowItem(Item item) { }

    public void Throw(Item item) => ThrowItem(item);

    public void Delete(Item item) => ItemDelete(item);

    protected virtual void ItemDelete(Item item) { }

    protected virtual void ItemDestroy() { }

    protected virtual string InfoItem() => "предмет:";

}

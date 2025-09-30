using UnityEngine;

public class ItemSpeed : Item
{
    private float _increaseSpeed = 0.2f;
    protected override void DoEffect(Player player)
    {
        player._rigidBody.mass -= _increaseSpeed;
        Debug.Log(InfoItem());
        ItemDestroy();
    }

    protected override void ItemDestroy()
    {
        Debug.Log($"{base.InfoItem()} исчезает!");
        Destroy(gameObject);
    }

    protected override string InfoItem()
    {
        return $"использован {base.InfoItem()} зелье скорости";
    }

}

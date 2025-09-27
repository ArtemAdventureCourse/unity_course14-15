using UnityEngine;

public class ItemHealth : Item
{
    protected override void DoEffect(Player player)
    {
        player.CurrentHealth += _increaseHealth;
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
        return $"использован {base.InfoItem()} зелье здоровья";
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public float value;
    public Sprite icon;
    public ItemType itemType;
    public string message;

    public bool isReusable;

    public enum ItemType
    {
        HP,
        Stamina,
        Projectile,
        Information
    }
}
 
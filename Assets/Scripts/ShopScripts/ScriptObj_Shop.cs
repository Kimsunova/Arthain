using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item")]
public class ScriptObj_Shop : ScriptableObject
{
    public ScriptObj_InvItem invItem; //The item to spawn
    public enum Tag { Weapon, Heal, Buff, PermBuff }; //InventoryType denotes the type of object (pet, hat, etc). The inventory menu sorts items by type. Add more types as needed.

    public Tag itemType;
    public string itemName; //the name of the item, for display and such
    public string description; //description of the object
    public Sprite itemImage; //an image of the item to display on the inventory menu
    public int price;

    private void Awake()
    {
        itemType = (Tag) invItem.itemTag;
        itemName = invItem.itemName;
        description = invItem.description;
        itemImage = invItem.itemImage;
        price = invItem.itemPrice;
    }
}



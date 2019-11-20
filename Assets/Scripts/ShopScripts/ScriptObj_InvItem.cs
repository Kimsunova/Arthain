using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item")]
public class ScriptObj_InvItem : ScriptableObject
{
    public enum Tag { Weapon, Heal, Buff, PermBuff }; //Tag denotes the type of object (buff, heal, etc). Add more types as needed.
    public Tag itemTag;
    public string itemName; //the name of the item, for display and such
    public Sprite itemImage; //an image of the item to display on the inventory menu
    public string description; //the description of the object for the shop or if player looks at the item

    public int itemPrice;
    public int itemSell;
    public float incrementValue; //most items will be healing items or buffs of some sort

}

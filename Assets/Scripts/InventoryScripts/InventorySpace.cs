using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySpace : MonoBehaviour
{
    public static InventorySpace instance;
    public ScriptObj_InvItem[] allInventoryItems;
    public ScriptObj_ItemSlot[] allInvSlots; //all of the inventory slots. All of these must be manually assigned
    int numInvSlots;
    public int pageNum = 0;

    public Text description;

    ScriptObj_InvItem.Tag newInvType;

    private void Awake() { instance = this; }

    private void Start() {
        numInvSlots = allInvSlots.Length;

        for (int i = numInvSlots * pageNum; i < numInvSlots * (pageNum + 1); i++)
        {
            // do this if the itemList has at least i items
            if (allInventoryItems.Length > i)
            {
                //assign items to an inventory slot
                allInvSlots[i % numInvSlots].inventoryItem = allInventoryItems[i]; //(10 % 8 = 2 = 2nd slot)
                allInvSlots[i % numInvSlots].NewItemAssigned();
            }
            // do this if itemList doesn't have at least i items
            else
            {
                //remove the current item in the slot (if any) and make it null
                allInvSlots[i % numInvSlots].inventoryItem = null;
                allInvSlots[i % numInvSlots].ItemRemoved();
            }
        }
    }

    //here, the inventory will be redisplayed using items of type "Tag" (if you want to view all weapons or potions, i.e.)
    public void ChangeInventory(ScriptObj_InvItem.Tag itemType)
    {
        List<ScriptObj_InvItem> itemList = GetAllItems(itemType);

        //this "for" loop designates the numbers that we will take from the allInvSlots list
        //example: page 0 will display allInvSlots items 0 - 7, page 1 will display 8 - 15, etc
        for (int i = numInvSlots * pageNum; i < numInvSlots * (pageNum + 1); i++)
        {
            // do this if the itemList has at least i items
            if (itemList.Count > i)
            {
                //assign items to an inventory slot
                allInvSlots[i % numInvSlots].inventoryItem = itemList[i]; //(10 % 8 = 2 = 2nd slot)
                allInvSlots[i % numInvSlots].NewItemAssigned();
            }
            // do this if itemList doesn't have at least i items
            else
            {
                //remove the current item in the slot (if any) and make it null
                allInvSlots[i % numInvSlots].inventoryItem = null;
                allInvSlots[i % numInvSlots].ItemRemoved();
            }
        }
    }

    public void ChangeInventory()
    {
        //this "for" loop designates the numbers that we will take from the allInvSlots list
        //example: page 0 will display allInvSlots items 0 - 7, page 1 will display 8 - 15, etc
        for (int i = numInvSlots * pageNum; i < numInvSlots * (pageNum + 1); i++)
        {
            // do this if the itemList has at least i items
            if (allInventoryItems.Length > i)
            {
                //assign items to an inventory slot
                allInvSlots[i % numInvSlots].inventoryItem = allInventoryItems[i]; //(10 % 8 = 2 = 2nd slot)
                allInvSlots[i % numInvSlots].NewItemAssigned();
            }
            // do this if itemList doesn't have at least i items
            else
            {
                //remove the current item in the slot (if any) and make it null
                allInvSlots[i % numInvSlots].inventoryItem = null;
                allInvSlots[i % numInvSlots].ItemRemoved();
            }
        }
    }

    //takes a parameter of ScriptObj_InvItem.InventoryType and returns a list of all InventoryItems of that Tag
    List<ScriptObj_InvItem> GetAllItems(ScriptObj_InvItem.Tag searchForInvType)
    {
        List<ScriptObj_InvItem> newInvItemList = new List<ScriptObj_InvItem>();

        foreach (ScriptObj_InvItem item in allInventoryItems)
        {
            if (item.itemTag == searchForInvType)
            {
                newInvItemList.Add(item);
            }
        }

        return newInvItemList;
    }

    //function for the Next Page button
    public void NextPage()
    {
        //if the current inventory boxes * the next page number would be
        //greater than all of the items on the page, then skip this
        //if ((allInvSlots.Length * (pageNum + 1)) < GetAllItems(newInvType).Count)
        if ((allInvSlots.Length * (pageNum + 1)) < allInventoryItems.Length)
        {
            pageNum++;
            ChangeInventory();
        }
    }

    //function for the Previous Page button
    public void PreviousPage()
    {
        if (pageNum > 0) //if it is the last page (page 0), skip this
        {
            pageNum--;
            ChangeInventory();
        }
    }
}

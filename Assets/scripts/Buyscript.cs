using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyScript : MonoBehaviour
{
    public GameObject shopUI;
    //Arrays
    public int[] amt;
    public int[] cost;
    public int[] iconNum;
    public int[] inventoryItems;
    public Text[] itemAmtText;
    public Text currencyText;
    private Text compare;
    public bool tavern = false;
    private int max = 0;
    private bool canClick = true ;
    void Start()
    {
        max = itemAmtText.Length;//Sets the initial max value based on number of shop items.
        currencyText.text = InventoryItems.gold.ToString();//Updates gold display when the shop opens.
    }
    public void CloseShop()
    {
        shopUI.SetActive(false);//Hides the shop UI when player closes the shop.
    }
    public void BuyButton()
    {
        if (canClick == true)//Check if purchase is allowed:
        {

            for (int i = 0; i < max; i++)// Loop through all shop items:
            {
                if (itemAmtText[i] == compare)//Match current selection:
                {
                    max = i;
                    if (amt[i] > 0)//only amount of goods is over 0 ,I can buy itmes 
                    {
                        if (tavern == true)
                        {
                            UpdateTavernAmt();
                        }
                        if (InventoryItems.gold >= cost[i])// the gold is more than the cost of one item,i can buy it.
                        {
                            if (inventoryItems[i] == 0)//If the player doesn't already have this item, it sets a new icon and flags that the icon needs to be updated (probably on the UI).
                            {
                                InventoryItems.newIcon = iconNum[i];
                                InventoryItems.iconUpdate = true;
                            }
                            InventoryItems.gold -= cost[i];//Subtracts the item's cost from the player's total gold.
                            if (tavern == true)
                            {
                                SetTavernAmt(i);


                            }
                        }
                    }
                }
            }
        }
    }

void UpdateTavernAmt()
{
    inventoryItems[0] = InventoryItems.bread;//opies the actual item counts (InventoryItems.bread, etc.) into the inventoryItems[] array.
                                             //This makes it easier to check if the player owns something using inventoryItems[i].
        inventoryItems[1] = InventoryItems.cheese;
    inventoryItems[2] = InventoryItems.meat;
}
    public void updateGold()
    {
        currencyText.text =InventoryItems.gold.ToString();//Refreshes the gold display in the UI.
    }
void SetTavernAmt(int item)
{
    if (item == 0)
    {
        InventoryItems.bread++;
    }
    if (item == 1)
    {
        InventoryItems.cheese++;
    }
    if (item == 2)
    {
        InventoryItems.meat++;
    }
    amt[item]--;
    itemAmtText[item].text = amt[item].ToString();
    currencyText.text = InventoryItems.gold.ToString();
    max = itemAmtText.Length;
}
       public void bread ()//When the player clicks an item button in the UI,
                           //this sets compare to that item’s UI text and calls check() to validate if it's available for purchase.
    {
        compare = itemAmtText[0];
        check(0);
    }
    public void cheese()
    {
        compare = itemAmtText[1];
        check(1);
    }
    public void meat()
    {
        compare = itemAmtText[2];
        check(2);
    }
    void check(int b)//Enables or disables the buy button based on item stock.
    {
        if (amt[b] > 0)
        {
        canClick = true;    
        
        }
        else 
        {  
            canClick = false;
        } 
         
    }
}

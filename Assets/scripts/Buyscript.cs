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
        max = itemAmtText.Length;
        currencyText.text = InventoryItems.gold.ToString();
    }
    public void CloseShop()
    {
        shopUI.SetActive(false);
    }
    public void BuyButton()
    {
        if (canClick == true)
        {

            for (int i = 0; i < max; i++)
            {
                if (itemAmtText[i] == compare)
                {
                    max = i;
                    if (amt[i] > 0)
                    {
                        if (tavern == true)
                        {
                            UpdateTavernAmt();
                        }
                        if (InventoryItems.gold >= cost[i])
                        {
                            if (inventoryItems[i] == 0)
                            {
                                InventoryItems.newIcon = iconNum[i];
                                InventoryItems.iconUpdate = true;
                            }
                            InventoryItems.gold -= cost[i];
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
    inventoryItems[0] = InventoryItems.bread;
    inventoryItems[1] = InventoryItems.cheese;
    inventoryItems[2] = InventoryItems.meat;
}
    public void updateGold()
    {
        currencyText.text =InventoryItems.gold.ToString();
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
       public void bread ()
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
    void check(int b)
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

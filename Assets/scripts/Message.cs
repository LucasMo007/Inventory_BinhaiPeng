using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Message : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Text buttonText;
    public Text shopOwnerMessage;
    public Color32 messageOff;
    public Color32 messageOn;
    public GameObject shopUI;
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = messageOn;
        PlayerMove.canMove = false;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color -= messageOff;
        PlayerMove.canMove = true;
        if (shopUI != null)
        {
            shopUI.SetActive(false);
        }
    }
    
 
    
    void Start()
    {
        shopOwnerMessage.text = "hello"  +  Save.pname + "how can I help you";
    }

   public void Message1()
    {
        shopOwnerMessage.text = " not much going on around here";
    }
    public void Message2()
    {
        shopOwnerMessage.text = " select items from the list ";
        shopUI.SetActive(true);
        shopUI.GetComponent<BuyScript>().updateGold();
    }

}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
   
{
    private NavMeshAgent nav;
    private Ray ray; 
    private Animator anim;
    private RaycastHit hit;
    public static bool canMove = true;
  
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canMove == true)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    nav.destination = hit.point;
                }
            }




        }
    }
}

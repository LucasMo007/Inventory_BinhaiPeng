using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{   public static int pchar = 0;
    public static string pname = "Lucas";
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}

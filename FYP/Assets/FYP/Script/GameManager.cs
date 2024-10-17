using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hideMouse;
    void Start()
    {
        if (hideMouse)
        {
            MouseControl(false);
        }
        else
        {
            MouseControl(true);
        }

    }

    void Update()
    {
       

        
    }

    public void MouseControl(bool YN)
    {
        if (YN)
        {
            
            //Display Mouse
            //MouseControl(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

        }
        else
        {
            //Hide Mouse
            //MouseControl(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


    }
    
   

    

}

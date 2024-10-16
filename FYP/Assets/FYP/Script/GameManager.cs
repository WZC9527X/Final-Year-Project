using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        

    }


    void Update()
    {

    }

    public void MouseControl(bool YN)
    {
        if (YN)
        {
            //Hide Mouse
            //MouseControl(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;

        }
        else
        {
            //Display Mouse
            //MouseControl(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }


    }
    
   

    

}

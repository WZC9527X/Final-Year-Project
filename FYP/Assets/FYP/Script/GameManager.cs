using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        MouseControl(false);





    }


    void Update()
    {

    }

    public void MouseControl(bool YN)
    {
        if (YN)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }


    }
    
   

    

}

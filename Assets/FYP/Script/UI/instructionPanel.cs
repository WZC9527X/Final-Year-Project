using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionPanel : MonoBehaviour
{
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Panel.SetActive(false);
        }
    }
}

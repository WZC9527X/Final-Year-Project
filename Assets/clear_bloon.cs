using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class clear_bloon : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Color color = spriteRenderer.color;
        color.a = 0f; // 透明度设为0
        spriteRenderer.color = color;
 
    }


}

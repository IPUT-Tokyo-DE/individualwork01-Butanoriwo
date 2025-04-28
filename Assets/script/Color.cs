using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.Clamp01(GameManager.damage / 15f); 

        float red = 1.0f;
        float green = 1.0f - t; 
        float blue = 1.0f - t;

        Color newColor = new Color(red, green, blue);
        rend.color = newColor;
    }
}

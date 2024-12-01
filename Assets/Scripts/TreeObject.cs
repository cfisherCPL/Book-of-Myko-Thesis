using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObject : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer { get; set; }
    private Color defaultColor;
    private Color fadedColor;




    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = mySpriteRenderer.color;
        fadedColor = defaultColor;
        fadedColor.a = 0.5f;
    }

    public void FadeOut()
    {
        mySpriteRenderer.color = fadedColor;
    }

    public void FadeIn()
    { 
        mySpriteRenderer.color = defaultColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FadeOut();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FadeIn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

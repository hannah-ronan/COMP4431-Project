using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour

{
    public bool isButtonPressed = false;
    public Sprite UnpressedSprite;
    public Sprite PressedSprite;
    public SpriteRenderer spriteRenderer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isButtonPressed = true;
        Debug.Log("Button is pressed ");
        spriteRenderer.sprite = PressedSprite;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isButtonPressed = false;
        Debug.Log("Leaving button");
        spriteRenderer.sprite = UnpressedSprite;
    }

    public bool isPressed()
    {
        return isButtonPressed;
    }
}

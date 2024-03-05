using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour

{
    public bool isButtonPressed = false;
    public int count = 0;

    public Sprite UnpressedSprite;
    public Sprite PressedSprite;
    public SpriteRenderer spriteRenderer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        isButtonPressed = true;
        count += 1;
        spriteRenderer.sprite = PressedSprite;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        count -= 1;
        if (count == 0)
        {
            isButtonPressed = false;
            spriteRenderer.sprite = UnpressedSprite;
        }
    }

    public bool isPressed()
    {
        return isButtonPressed;
    }
}

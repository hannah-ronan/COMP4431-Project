using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour

{
    public bool isButtonPressed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       
        isButtonPressed = true;
        Debug.Log("Button is pressed ");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isButtonPressed = false;
        Debug.Log("Leaving button");
    }

    public bool isPressed()
    {
        return isButtonPressed;
    }
}

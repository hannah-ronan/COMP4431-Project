using UnityEngine;

public class ButtonPushedDoor : MonoBehaviour
{
    GameObject button1, button2, door;
    ButtonPress buttonScript1, buttonScript2;

    // Start is called before the first frame update
    void Start()
    {
        button1 = GameObject.Find("Button1");
        button2 = GameObject.Find("Button2");

        door = GameObject.Find("Door");

        buttonScript1 = button1.GetComponent<ButtonPress>();
        buttonScript2 = button2.GetComponent<ButtonPress>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonScript1.isPressed() || buttonScript2.isPressed())
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
    }
}

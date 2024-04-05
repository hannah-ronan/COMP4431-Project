using UnityEngine;

public class DoorScript : MonoBehaviour
{

    GameObject square1 = null, square2 = null, square3 = null, square4 = null, door = null;
    ButtonPress script1 = null, script2 = null, script3 = null, script4 = null;
    bool count;
    // Start is called before the first frame update
    void Start()
    {
        square1 = GameObject.Find("Square1");
        square2 = GameObject.Find("Square2");
        square3 = GameObject.Find("Square3");
        square4 = GameObject.Find("Square4");
        door = GameObject.Find("Door");
        script1 = square1.GetComponent<ButtonPress>();
        script2 = square2.GetComponent<ButtonPress>();
        script3 = square3.GetComponent<ButtonPress>();
        script4 = square4.GetComponent<ButtonPress>();
    }

    // Update is called once per frame
    void Update()
    {
        if(script1.isPressed() && script2.isPressed() && script3.isPressed() && script4.isPressed())
        {
            door.SetActive(false);
        }
    }
}
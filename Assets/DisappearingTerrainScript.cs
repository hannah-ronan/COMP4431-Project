using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingTerrainScript : MonoBehaviour
{
    public GameObject leftTerrain, rightTerrain;
    GameObject leftButton, rightButton;
    ButtonPress leftButtonScript, rightButtonScript;

    // Start is called before the first frame update
    void Start()
    {
        leftTerrain = GameObject.Find("LeftTerrain");
        rightTerrain = GameObject.Find("RightTerrain");
        leftButton = GameObject.Find("LeftButton");
        rightButton = GameObject.Find("RightButton");
        leftTerrain.SetActive(false);
        rightTerrain.SetActive(false);

        leftButtonScript = leftButton.GetComponent<ButtonPress>();
        rightButtonScript = rightButton.GetComponent<ButtonPress>();
    }

    // Update is called once per frame
    void Update()
    {
        if (leftButtonScript.isPressed())
        {
            leftTerrain.SetActive(true);
        }
        else
        {
            leftTerrain.SetActive(false);
        }
        if (rightButtonScript.isPressed())
        {
            rightTerrain.SetActive(true);
        }
        else
        {
            rightTerrain.SetActive(false);
        }
    }
}

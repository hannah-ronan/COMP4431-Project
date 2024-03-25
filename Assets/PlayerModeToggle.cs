using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerModeToggle : MonoBehaviour
{
    public Sprite OnSprite;
    public Sprite OffSprite;

    private Toggle toggle;
    private Image checkBoxImage;
    // Start is called before the first frame update
    void Start()
    {
        toggle = gameObject.GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggle);
        });
        PlayerPrefs.SetInt("TwoPlayerModeOn",(toggle.isOn?1:0));
        checkBoxImage = GetComponentInChildren<Image>();
    }

    void ToggleValueChanged(Toggle change)
    {
        checkBoxImage.sprite = toggle.isOn ? OnSprite : OffSprite;
        PlayerPrefs.SetInt("TwoPlayerModeOn",(toggle.isOn?1:0));
    }


}

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
        var PlayerModePref = PlayerPrefs.GetInt("TwoPlayerModeOn", -1);
        if(PlayerModePref == -1){
            //if the preference has never been set, then set it to false
            PlayerPrefs.SetInt("TwoPlayerModeOn",0);
        }
        var TwoPlayerModeOn = PlayerModePref == 1;

        toggle = gameObject.GetComponent<Toggle>();
        toggle.isOn = TwoPlayerModeOn;
        toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggle);
        });

        checkBoxImage = GetComponentInChildren<Image>();
        checkBoxImage.sprite = toggle.isOn ? OnSprite : OffSprite;
    }

    void ToggleValueChanged(Toggle change)
    {
        checkBoxImage.sprite = toggle.isOn ? OnSprite : OffSprite;
        PlayerPrefs.SetInt("TwoPlayerModeOn",(toggle.isOn?1:0));
    }


}
